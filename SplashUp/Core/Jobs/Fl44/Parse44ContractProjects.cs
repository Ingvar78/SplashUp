using SplashUp.Data.DB;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using SplashUp.Models.Enum;
using SplashUp.Models.Zakupki_gov_ru.Fl44;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace SplashUp.Core.Jobs.Fl44
{
    partial class Parse44FilesJob
    {
        void ParseContractProjects(List<FileCashes> FileCashes)
        {

            //Parallel.ForEach(FileCashes,
            //    new ParallelOptions { MaxDegreeOfParallelism = _fzSettings44.Parallels },
            //    (nFile) =>
            foreach (var nFile in FileCashes)
            {
                string zipPath = (_fzSettings44.WorkPath + nFile.Full_path);
                string extractPath = (_fzSettings44.WorkPath + "/extract" + nFile.Full_path);
                var cproject = new List<ContractProject>();

                if (Directory.Exists(extractPath))
                {
                    Directory.Delete(extractPath, true);
                }
                //и создаём её заново
                Directory.CreateDirectory(extractPath);
                if (File.Exists(zipPath))
                {
                    using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                            {
                                entry.ExtractToFile(Path.Combine(extractPath, entry.FullName), true);
                                string xml_f_name = entry.FullName;
                                string xmlin = (extractPath + "/" + entry.FullName);
                                _logger.LogInformation("xmlin parse Protocols: " + xmlin);

                                FileInfo infoCheck = new FileInfo(xmlin);
                                if (infoCheck.Length != 0)
                                {
                                    try
                                    {
                                        string read_xml_text;
                                        using (var streamReader = new StreamReader(xmlin, Encoding.UTF8, false))
                                        {
                                            read_xml_text = streamReader.ReadToEnd();
                                        }

                                        var strBuilder = new StringBuilder();
                                        using (var hash = SHA256.Create())
                                        {
                                            //Getting hashed byte array
                                            var result = hash.ComputeHash(Encoding.UTF8.GetBytes(read_xml_text));
                                            foreach (var b in result)
                                                strBuilder.Append(b.ToString("x2")); //Byte as hexadecimal format
                                        }

                                        var hashstr = strBuilder.ToString();

                                        var djson = _dataServices.XmlToJson(xmlin);

                                        string jsonpath = (_commonSettings.DebugPath + "/Json");

                                        using (StreamReader reader = new StreamReader(xmlin, Encoding.UTF8, false))
                                        {
                                            XmlSerializer serializer = new XmlSerializer(typeof(export));

                                            XmlSerializer xmlser = new XmlSerializer(typeof(export));
                                            export exportd = xmlser.Deserialize(reader) as export;
                                            //Console.WriteLine($"{exportd.ItemsElementName[0].ToString()}");



                                            var settings = new JsonSerializerSettings()
                                            {
                                                Formatting = Newtonsoft.Json.Formatting.Indented,
                                                TypeNameHandling = TypeNameHandling.Auto
                                            };

                                            switch (exportd.ItemsElementName[0].ToString())
                                            {
                                                case "ProtocolCancel_tets": //
                                                    {
                                                        //var cpContractProject = exportd.Items[0] as cpContractProject;
                                                        ////string unf_json = JsonConvert.SerializeObject(epProtocolCancel);

                                                        //var frpotocols = new Protocols();
                                                        //frpotocols.Purchase_num = epProtocolCancel.commonInfo.purchaseNumber;
                                                        //frpotocols.Protocol_num = epProtocolCancel.commonInfo.canceledProtocolNumber;
                                                        //frpotocols.R_body = djson; //unf_json; // frpotocols.R_body = unf_json;
                                                        //frpotocols.Hash = hashstr;
                                                        //frpotocols.Zip_file = nFile.Full_path;
                                                        //frpotocols.File_name = entry.FullName;
                                                        //frpotocols.Fz_type = 44;
                                                        //frpotocols.Type_protocol = exportd.Items[0].GetType().Name;
                                                        //frpotocols.PublishDate = epProtocolCancel.commonInfo.publishDTInEIS;
                                                        //cproject.Add(frpotocols);
                                                        break;
                                                    }

                                                default:
                                                    {

                                                        if (exportd.Items.Length > 1)
                                                        {
                                                            Console.WriteLine("More one");
                                                            _logger.LogWarning($"More then one Items in file: {infoCheck.FullName} ");
                                                        }
                                                        string exp_json = JsonConvert.SerializeObject(exportd);
                                                        var EData = JsonConvert.DeserializeObject<export>(exp_json);
                                                        string eltype = $"{exportd.ItemsElementName[0].ToString()};{exportd.Items[0].GetType().Name}";
                                                        string fnel = $"{exportd.ItemsElementName[0].ToString()}";

                                                        var ppath = Path.Combine(_commonSettings.DebugPath, "Protocols");

                                                        if (!Directory.Exists(ppath))
                                                        {
                                                            Directory.CreateDirectory(ppath);
                                                        }
                                                        using (StreamWriter sw1 = new StreamWriter(@$"{ppath}\\{fnel}", true, System.Text.Encoding.Default))
                                                        {
                                                            sw1.WriteLine(eltype);
                                                        };

                                                        break;
                                                    }
                                            }

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.LogError(ex, "Error parse ParseProtocols");
                                        _logger.LogError(ex, ex.Message);
                                        string errfile = (_commonSettings.DebugPath + nFile.Full_path);
                                        if (!Directory.Exists(errfile)) Directory.CreateDirectory(errfile);
                                        System.IO.File.Copy(xmlin, _commonSettings.DebugPath + nFile.Full_path + '/' + entry.FullName, true);


                                    }
                                }
                            }
                        }

                    _logger.LogInformation($"Всего добавляется Protocols записей в БД: {cproject.Count}");
                    //_dataServices.SaveProtocols(protocols);
                    //nFile.Status = Status.Processed;
                    //nFile.Modifid_date = DateTime.Now;
                    //_dataServices.UpdateCasheFiles(nFile);
                    //Чистим после себя
                    try
                    {
                        if (File.Exists(zipPath) && nFile.Date < DateTime.Now.AddDays(-_commonSettings.KeepDay)) File.Delete(zipPath);
                        Directory.Delete(extractPath, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Файл заблокирован Protocols: {zipPath}");
                        _logger.LogError(ex, ex.Message);
                    }
                }
                else
                {
                    _logger.LogError($"Файл не найден Protocols: {zipPath}");
                    //Меняем и пробуем загрузить заново
                    nFile.Status = Status.Exist;
                    _dataServices.UpdateCasheFiles(nFile);
                }

            }
        }
    }
    
}

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

        void ParseContracts(List<FileCashes> FileCashes)
        {

            Parallel.ForEach(FileCashes,
                new ParallelOptions { MaxDegreeOfParallelism = _fzSettings44.Parallels },
                (nFile) =>
                //foreach (var nFile in FileCashes)
                {
                string zipPath = (_fzSettings44.WorkPath + nFile.Full_path);
                string extractPath = (_fzSettings44.WorkPath + "/extract" + nFile.Full_path);
                var contracts = new List<Contracts>();

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
                                entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                                string xml_f_name = entry.FullName;
                                string xmlin = (extractPath + "/" + entry.FullName);
                                _logger.LogInformation("xmlin parse: " + xmlin);

                                FileInfo infoCheck = new FileInfo(xmlin);
                                if (infoCheck.Length != 0)
                                {
                                    try
                                    {
                                            var djson = _dataServices.XmlToJson(xmlin);

                                            string jsonpath = (_commonSettings.DebugPath + "/Json");

                                            //if (!Directory.Exists(jsonpath))
                                            //{
                                            //    Directory.CreateDirectory(jsonpath);
                                            //}
                                            ////и создаём её заново
                                            

                                            //var savepath= Path.Combine(jsonpath, entry.FullName);
                                            //using (StreamWriter sw1 = new StreamWriter(savepath, true, System.Text.Encoding.Default))
                                            //{

                                            //    sw1.WriteLine(djson);

                                            //};


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

                                        //Console.WriteLine($"{hashstr}");

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
                                                case "contract": //contract;zfcs_contract2015Type - Информация (проект информации) о заключенном контракте;
                                                    {
                                                        zfcs_contract2015Type contract = exportd.Items[0] as zfcs_contract2015Type;
                                                        string unf_json = JsonConvert.SerializeObject(contract);

                                                        var fcontract = new Contracts();

                                                        //fscn.Wname = "";
                                                        fcontract.Contract_num = contract.regNum;
                                                        //fcontract.Purchase_num = contract.foundation.Item
                                                        //zfcs_contract2015TypeFoundationOosOrderOrder tt = contract.foundation.Item as zfcs_contract2015TypeFoundationOosOrderOrder;
                                                        fcontract.R_body = djson;// fcontract.R_body = unf_json;
                                                        //fcontract.Xml_body = read_xml_text;
                                                        fcontract.Hash = hashstr;
                                                        fcontract.Zip_file = nFile.Full_path;
                                                        fcontract.File_name = entry.FullName;
                                                        fcontract.Fz_type = 44;
                                                        fcontract.PublishDate = contract.publishDate;
                                                        fcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                        contracts.Add(fcontract);
                                                        //_dataServices.SaveNotification(notifications);
                                                        break;
                                                    }
                                                case "contractCancel": //contractCancel;zfcs_contractCancel2015Type - Информация об анулировании контракта;
                                                    {
                                                        zfcs_contractCancel2015Type contractCancel = exportd.Items[0] as zfcs_contractCancel2015Type;
                                                        string unf_json = JsonConvert.SerializeObject(contractCancel);

                                                        var fcontract = new Contracts();

                                                        //fscn.Wname = "";
                                                        fcontract.Contract_num = contractCancel.regNum;
                                                        fcontract.R_body = djson;// fcontract.R_body = unf_json;
                                                        //fcontract.Xml_body = read_xml_text;
                                                        fcontract.Hash = hashstr;
                                                        fcontract.Zip_file = nFile.Full_path;
                                                        fcontract.File_name = entry.FullName;
                                                        fcontract.Fz_type = 44;
                                                        fcontract.PublishDate = contractCancel.publishDate;
                                                        fcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                        contracts.Add(fcontract);
                                                        //_dataServices.SaveNotification(notifications);
                                                        break;
                                                    }
                                                case "contractProcedure": //contractProcedure;zfcs_contractProcedure2015Type - Информация об исполнении (расторжении) контракта;
                                                    {
                                                        zfcs_contractProcedure2015Type contractProcedure = exportd.Items[0] as zfcs_contractProcedure2015Type;
                                                        string unf_json = JsonConvert.SerializeObject(contractProcedure);

                                                        var fcontract = new Contracts();

                                                        //fscn.Wname = "";
                                                        fcontract.Contract_num = contractProcedure.regNum;
                                                        fcontract.R_body = djson;// fcontract.R_body = unf_json;
                                                        //fcontract.Xml_body = read_xml_text;
                                                        fcontract.Hash = hashstr;
                                                        fcontract.Zip_file = nFile.Full_path;
                                                        fcontract.File_name = entry.FullName;
                                                        fcontract.Fz_type = 44;
                                                        fcontract.PublishDate = contractProcedure.publishDate;
                                                        fcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                        contracts.Add(fcontract);
                                                        //_dataServices.SaveNotification(notifications);
                                                        break;
                                                    }
                                                case "contractProcedureCancel": //contractProcedureCancel;zfcs_contractProcedureCancel2015Type - Сведения об отмене информации об исполнении (расторжении) контракта;
                                                    {
                                                        zfcs_contractProcedureCancel2015Type contractProcedureCancel = exportd.Items[0] as zfcs_contractProcedureCancel2015Type;
                                                        string unf_json = JsonConvert.SerializeObject(contractProcedureCancel);

                                                        var fcontract = new Contracts();

                                                        //fscn.Wname = "";
                                                        fcontract.Contract_num = contractProcedureCancel.regNum;
                                                        fcontract.R_body = djson;// fcontract.R_body = unf_json;
                                                        fcontract.Hash = hashstr;
                                                        fcontract.Zip_file = nFile.Full_path;
                                                        fcontract.File_name = entry.FullName;
                                                        fcontract.Fz_type = 44;
                                                        //fcontract.PublishDate = contractProcedureCancel.;
                                                        fcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                        contracts.Add(fcontract);
                                                        //_dataServices.SaveNotification(notifications);
                                                        break;
                                                    }

                                                    case "contractAvailableForElAct": //contractAvailableForElAct;zfcs_contractAvailableForElAct - Квитанция о доступности формирования документов электронного актирования по контракту;
                                                        {
                                                            zfcs_contractAvailableForElAct zfcs_contractAvailableForElAct = exportd.Items[0] as zfcs_contractAvailableForElAct;
                                                            string unf_json = JsonConvert.SerializeObject(zfcs_contractAvailableForElAct);

                                                            var fcontract = new Contracts();

                                                            //fscn.Wname = "";
                                                            fcontract.Contract_num = zfcs_contractAvailableForElAct.regNum;
                                                            fcontract.R_body = djson;// fcontract.R_body = unf_json;
                                                            fcontract.Hash = hashstr;
                                                            fcontract.Zip_file = nFile.Full_path;
                                                            fcontract.File_name = entry.FullName;
                                                            fcontract.Fz_type = 44;
                                                            fcontract.PublishDate = zfcs_contractAvailableForElAct.availableDT;
                                                            fcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                            contracts.Add(fcontract);
                                                            //_dataServices.SaveNotification(notifications);
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

                                                            var npath = Path.Combine(_commonSettings.DebugPath, "Contracts");

                                                            if (!Directory.Exists(npath))
                                                            {
                                                                Directory.CreateDirectory(npath);
                                                            }
                                                            using (StreamWriter sw1 = new StreamWriter(@$"{npath}\\{fnel}", true, System.Text.Encoding.Default))
                                                            {
                                                                sw1.WriteLine(eltype);
                                                            };

                                                        break;
                                                    }
                                            }


//#if true && DEBUG
//                                                if (!Directory.Exists(jsonpath))
//                                                {
//                                                    Directory.CreateDirectory(jsonpath);

//                                                }
//                                                var jsonpath_1 = Path.Combine(jsonpath, exportd.ItemsElementName[0].ToString());
//                                                if (!Directory.Exists(jsonpath_1))
//                                                {
//                                                    Directory.CreateDirectory(jsonpath_1);
//                                                }
//                                                //и создаём её заново


//                                                var savepath = Path.Combine(jsonpath_1, entry.Name);
//                                                using (StreamWriter sw1 = new StreamWriter(savepath, true, System.Text.Encoding.Default))
//                                                {

//                                                    sw1.WriteLine(djson);

//                                                };

//#endif
                                                //#if true && DEBUG
                                                //                                            var json = JsonConvert.SerializeObject(exportd.item);
                                                //#endif
                                            }
                                        }
                                    catch (Exception ex)
                                    {
                                        _logger.LogError(ex, "Error parse");
                                        _logger.LogError(ex, ex.Message);
                                        string errfile = (_commonSettings.DebugPath + nFile.Full_path);
                                        if (!Directory.Exists(errfile)) Directory.CreateDirectory(errfile);
                                        System.IO.File.Copy(xmlin, _commonSettings.DebugPath + nFile.Full_path + '/' + entry.FullName, true);


                                    }
                                }
                            }
                        }
                }

                
                    Console.WriteLine($"Всего добавляется записей Contracts в БД: {contracts.Count}");
                    _dataServices.SaveContracts(contracts);
                    nFile.Status = Status.Processed;
                    nFile.Modifid_date = DateTime.Now;
                    _dataServices.UpdateCasheFiles(nFile);

                Directory.Delete(extractPath, true);
            });


        }
    }
}

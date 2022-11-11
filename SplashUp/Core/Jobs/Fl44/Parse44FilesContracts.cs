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
using System.Globalization;
using System.Diagnostics.Contracts;

namespace SplashUp.Core.Jobs.Fl44
{
    partial class Parse44FilesJob
    {

        void ParseContracts(List<FileCashes> FileCashes)
        {

            //Parallel.ForEach(FileCashes,
            //    new ParallelOptions { MaxDegreeOfParallelism = _fzSettings44.Parallels },
            //    (nFile) =>              
            foreach (var nFile in FileCashes)
                {
                string zipPath = (_fzSettings44.WorkPath + nFile.Full_path);
                string extractPath = (_fzSettings44.WorkPath + "/extract" + nFile.Full_path);
                var contracts = new List<Contracts>();
                var contractsProc = new List<ContractsProcedures>();
                var csuppler = new List<Suppliers>();

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
                                entry.ExtractToFile(Path.Combine(extractPath, entry.FullName),true);
                                string xml_f_name = entry.FullName;
                                string xmlin = (extractPath + "/" + entry.FullName);
                                _logger.LogInformation("xmlin parse Contracts: " + xmlin);

                                FileInfo infoCheck = new FileInfo(xmlin);
                                if (infoCheck.Length != 0)
                                {
                                    try
                                    {
                                            //var djson = _dataServices.XmlToJson(xmlin);

                                            string jsonpath = (_commonSettings.DebugPath + "/Json");
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
                                            using (StreamReader reader = new StreamReader(xmlin, Encoding.UTF8, false))
                                            {
                                                XmlSerializer serializer = new XmlSerializer(typeof(export));
                                                XmlSerializer xmlser = new XmlSerializer(typeof(export));
                                                export exportd = xmlser.Deserialize(reader) as export;
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
                                                            //fcontract.R_body = djson;
                                                            fcontract.R_body = unf_json;
                                                            fcontract.Xml_body = read_xml_text;
                                                            fcontract.Hash = hashstr;
                                                            fcontract.Zip_file = nFile.Full_path;
                                                            fcontract.File_name = entry.FullName;
                                                            fcontract.Fz_type = 44;
                                                            fcontract.PublishDate = contract.publishDate;
                                                            fcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                            contracts.Add(fcontract);

                                                        //Разбор участников контракта
                                                        if (contract.suppliers != null)
                                                        {
                                                            foreach (var cs in contract.suppliers)
                                                            {
                                                                foreach (var st in cs.Items)
                                                                {
                                                                    var TypeName = st.GetType().Name;

                                                                    switch (TypeName)
                                                                    {
                                                                        case "zfcs_contract2015SupplierTypeLegalEntityRF":
                                                                            {
                                                                                var s = st as zfcs_contract2015SupplierTypeLegalEntityRF;
                                                                                var suppler = new Suppliers();
                                                                                suppler.Inn = s.INN;
                                                                                suppler.Kpp = s.KPP;
                                                                                suppler.Okpo = s.OKPO;
                                                                                suppler.Oktmo = JsonConvert.SerializeObject(s.OKTMO);
                                                                                suppler.FullName = s.fullName;
                                                                                suppler.ContactPhone = s.contactPhone;
                                                                                //suppler.LegalForm = JsonConvert.SerializeObject(s.legalForm.code);
                                                                                suppler.Okopf = s.legalForm.code;

                                                                                var postAdressInfo = new zfcs_contract2015SupplierInfoTypeLegalEntityRFOtherInfoPostAdressInfo();
                                                                                if (s.postAdressInfo != null)
                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.postAdressInfo.mailingAdress ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = s.postAdressInfo.postBoxNumber ?? String.Empty;
                                                                                    postAdressInfo.mailFacilityName = s.postAdressInfo.mailFacilityName ?? String.Empty;
                                                                                }
                                                                                else

                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.address ?? s.postAddress ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = String.Empty;
                                                                                    postAdressInfo.mailFacilityName = String.Empty;
                                                                                }


                                                                                suppler.PostAddress = JsonConvert.SerializeObject(postAdressInfo);

                                                                                
                                                                                suppler.RegistrationDate = s.registrationDate;
                                                                                csuppler.Add(suppler);
                                                                                break;
                                                                            }
                                                                        case "zfcs_contract2015SupplierTypeIndividualPersonRF":
                                                                            {
                                                                                var s = st as zfcs_contract2015SupplierTypeIndividualPersonRF;
                                                                                var suppler = new Suppliers();
                                                                                suppler.Inn = s.INN;
                                                                                suppler.Kpp = String.Empty;
                                                                                suppler.Okpo = String.Empty;
                                                                                suppler.Oktmo = JsonConvert.SerializeObject(s.OKTMO);
                                                                                var fullname = $"{s.firstName} {s.lastName} {s.middleName}";
                                                                                suppler.FullName = fullname;
                                                                                suppler.ContactPhone = s.contactPhone;
                                                                                suppler.Okopf = String.Empty;
                                                                                //suppler.LegalForm = JsonConvert.SerializeObject("{IndividualPersonRF=true}");
                                                                                var postAdressInfo = new zfcs_contract2015SupplierInfoTypeLegalEntityRFOtherInfoPostAdressInfo();
                                                                                if (s.postAddressInfo != null)
                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.postAddressInfo.mailingAdress ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = s.postAddressInfo.postBoxNumber ?? String.Empty;
                                                                                    postAdressInfo.mailFacilityName = s.postAddressInfo.mailFacilityName ?? String.Empty;
                                                                                }
                                                                                else

                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.address ?? s.postAddress ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = String.Empty;
                                                                                    postAdressInfo.mailFacilityName = String.Empty;
                                                                                }


                                                                                suppler.PostAddress = JsonConvert.SerializeObject(postAdressInfo);
                                                                                //suppler.PostAddress = s.postAddress;
                                                                                suppler.RegistrationDate = s.registrationDate;
                                                                                csuppler.Add(suppler);
                                                                                break;
                                                                            }
                                                                        case "zfcs_contract2015SupplierInfoTypeLegalEntityForeignState":
                                                                            {
                                                                                var s = st as zfcs_contract2015SupplierInfoTypeLegalEntityForeignState;
                                                                                var suppler = new Suppliers();
                                                                                suppler.Inn = String.Empty;
                                                                                suppler.Kpp = String.Empty;
                                                                                suppler.Okpo = String.Empty;
                                                                                suppler.Oktmo = String.Empty;
                                                                                suppler.FullName = s.fullName;
                                                                                suppler.ContactPhone = String.Empty;
                                                                                suppler.Okopf = String.Empty;
                                                                                //suppler.LegalForm = JsonConvert.SerializeObject("{IndividualPersonRF=true}");
                                                                                //suppler.LegalForm = JsonConvert.SerializeObject(s.);
                                                                                var postAdressInfo = new zfcs_contract2015SupplierInfoTypeLegalEntityRFOtherInfoPostAdressInfo();
                                                                                if (s.placeOfStayInRF.postAdressInfo != null)
                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.placeOfStayInRF.postAdressInfo.mailingAdress ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = s.placeOfStayInRF.postAdressInfo.postBoxNumber ?? String.Empty;
                                                                                    postAdressInfo.mailFacilityName = s.placeOfStayInRF.postAdressInfo.mailFacilityName ?? String.Empty;
                                                                                }
                                                                                else

                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.placeOfStayInRegCountry.postAddress ?? s.placeOfStayInRegCountry.address;
                                                                                    postAdressInfo.postBoxNumber = String.Empty;
                                                                                    postAdressInfo.mailFacilityName = String.Empty;
                                                                                }


                                                                                suppler.PostAddress = JsonConvert.SerializeObject(postAdressInfo);

                                                                                //suppler.PostAddress = JsonConvert.SerializeObject(s.placeOfStayInRegCountry);
                                                                                csuppler.Add(suppler);
                                                                                break;
                                                                            }
                                                                            default:
                                                                            {
                                                                                Console.WriteLine(TypeName);
                                                                                break;
                                                                            }
                                                                    }

                                                                    //Console.WriteLine(st.ToString());
                                                                    //zfcs_contract2015SupplierTypeIndividualPersonRF

                                                                }
                                                            }
                                                        }

                                                        if (contract.suppliersInfo != null)
                                                        {
                                                            foreach (var cs in contract.suppliersInfo)
                                                            {
                                                                foreach (var st in cs.Items)
                                                                {
                                                                    var TypeName = st.GetType().Name;

                                                                    switch (TypeName)
                                                                    {        
                                                                        case "zfcs_contract2015SupplierInfoTypeLegalEntityRF":
                                                                            {
                                                                                var s = st as zfcs_contract2015SupplierInfoTypeLegalEntityRF;
                                                                                var suppler = new Suppliers();
                                                                                suppler.Inn = s.EGRULInfo.INN;
                                                                                suppler.Kpp = s.EGRULInfo.KPP ?? string.Empty;
                                                                                suppler.Okpo = s.otherInfo.OKPO;
                                                                                suppler.Oktmo = JsonConvert.SerializeObject(s.otherInfo.OKTMO);
                                                                                suppler.FullName = s.EGRULInfo.fullName;
                                                                                suppler.ContactPhone = s.otherInfo.contactPhone;
                                                                                suppler.IsIP = false;

                                                                                //suppler.LegalForm = JsonConvert.SerializeObject(s.EGRULInfo.legalForm);
                                                                                suppler.Okopf = s.EGRULInfo.legalForm.code;
                                                                                var postAdressInfo = new zfcs_contract2015SupplierInfoTypeLegalEntityRFOtherInfoPostAdressInfo();
                                                                                if (s.otherInfo.postAdressInfo != null)
                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.otherInfo.postAdressInfo.mailingAdress ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = s.otherInfo.postAdressInfo.postBoxNumber ?? String.Empty;
                                                                                    postAdressInfo.mailFacilityName = s.otherInfo.postAdressInfo.mailFacilityName ?? String.Empty;
                                                                                }
                                                                                else

                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.EGRULInfo.address ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = String.Empty;
                                                                                    postAdressInfo.mailFacilityName = String.Empty;
                                                                                }
                                                                                

                                                                                suppler.PostAddress = JsonConvert.SerializeObject(postAdressInfo);
                                                                                suppler.RegistrationDate = s.EGRULInfo.registrationDate;
                                                                                csuppler.Add(suppler);
                                                                                break;
                                                                            }
                                                                        case "zfcs_contract2015SupplierInfoTypeIndividualPersonRFIndEntr":
                                                                            {
                                                                                var s = st as zfcs_contract2015SupplierInfoTypeIndividualPersonRFIndEntr;
                                                                                var suppler = new Suppliers();
                                                                                suppler.Inn = s.EGRIPInfo.INN;
                                                                                suppler.Kpp = string.Empty;
                                                                                suppler.Okpo = string.Empty;
                                                                                suppler.Oktmo = JsonConvert.SerializeObject(s.otherInfo.OKTMO);
                                                                                var fullname = $"{s.EGRIPInfo.lastName ?? string.Empty} {s.EGRIPInfo.firstName ?? string.Empty} {s.EGRIPInfo.middleName ?? string.Empty}";
                                                                                suppler.FullName = fullname;
                                                                                suppler.ContactPhone = s.otherInfo.contactPhone ?? string.Empty;
                                                                                //suppler.LegalForm = JsonConvert.SerializeObject(s.otherInfo.isIP) ?? string.Empty;
                                                                                //индивидуальные предприниматели (ИП) - код ОКОПФ 5 01 02 (50102)
                                                                                suppler.Okopf = String.Empty;
                                                                                suppler.IsIP = true;

                                                                                var postAdressInfo = new zfcs_contract2015SupplierInfoTypeLegalEntityRFOtherInfoPostAdressInfo();


                                                                                if (s.otherInfo.postAddressInfo != null)
                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.otherInfo.postAddressInfo.mailingAdress ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = s.otherInfo.postAddressInfo.postBoxNumber ?? String.Empty;
                                                                                    postAdressInfo.mailFacilityName = s.otherInfo.postAddressInfo.mailFacilityName ?? String.Empty;
                                                                                }
                                                                                else

                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.EGRIPInfo.address ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = String.Empty;
                                                                                    postAdressInfo.mailFacilityName = String.Empty;
                                                                                }

                                                                                suppler.PostAddress = JsonConvert.SerializeObject(postAdressInfo) ?? string.Empty;
                                                                                
                                                                                suppler.RegistrationDate = s.EGRIPInfo.registrationDate;
                                                                                //Console.WriteLine(st.ToString());
                                                                                csuppler.Add(suppler);
                                                                                break;
                                                                            }
                                                                        case "zfcs_contract2015SupplierInfoTypeIndividualPersonRF":
                                                                            {
                                                                                var s = st as zfcs_contract2015SupplierInfoTypeIndividualPersonRF;
                                                                                var suppler = new Suppliers();
                                                                                suppler.Inn = s.INN;
                                                                                suppler.Kpp = string.Empty;
                                                                                suppler.Okpo = string.Empty;
                                                                                suppler.Oktmo = JsonConvert.SerializeObject(s.OKTMO) ?? string.Empty;
                                                                                var fullname = $"{s.lastName ?? string.Empty} {s.firstName ?? string.Empty} {s.middleName ?? string.Empty}";
                                                                                suppler.FullName = fullname;
                                                                                suppler.ContactPhone = s.contactPhone;
                                                                                //suppler.LegalForm = JsonConvert.SerializeObject(false);
                                                                                //индивидуальные предприниматели (ИП) - код ОКОПФ 5 01 02 (50102)
                                                                                suppler.Okopf = String.Empty;
                                                                                

                                                                                string address = string.Empty;
                                                                                if (s.postAddressInfo != null) 
                                                                                    address = JsonConvert.SerializeObject(s.postAddressInfo);
                                                                                else if (s.address != null) address = s.address;

                                                                                var postAdressInfo = new zfcs_contract2015SupplierInfoTypeLegalEntityRFOtherInfoPostAdressInfo();
                                                                                if (s.postAddressInfo != null)
                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.postAddressInfo.mailingAdress ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = s.postAddressInfo.postBoxNumber ?? String.Empty;
                                                                                    postAdressInfo.mailFacilityName = s.postAddressInfo.mailFacilityName ?? String.Empty;
                                                                                }
                                                                                else

                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.address ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = String.Empty;
                                                                                    postAdressInfo.mailFacilityName = String.Empty;
                                                                                }

                                                                                suppler.PostAddress = JsonConvert.SerializeObject(postAdressInfo) ?? string.Empty;
                                                                                //suppler.PostAddress = address;
                                                                                //Console.WriteLine(st.ToString());
                                                                                suppler.RegistrationDate = s.registrationDate;
                                                                                csuppler.Add(suppler);
                                                                                Console.WriteLine(TypeName);
                                                                                break;
                                                                            }
                                                                        case "zfcs_contract2015SupplierInfoTypeLegalEntityForeignState":
                                                                            {
                                                                                //Иностранцы
                                                                                var s = st as zfcs_contract2015SupplierInfoTypeLegalEntityForeignState;
                                                                                break;
                                                                            }
                                                                        case "zfcs_contract2015SupplierInfoTypeIndividualPersonRFisCulture":
                                                                            {
                                                                                //Индивидуально - без данных.
                                                                                var s = st as zfcs_contract2015SupplierInfoTypeIndividualPersonRFisCulture;
                                                                                break;
                                                                            }
                                                                        case "zfcs_contract2015SupplierInfoTypeIndividualPersonForeignState":
                                                                            {
                                                                                var s = st as zfcs_contract2015SupplierInfoTypeIndividualPersonForeignState;
                                                                                
                                                                                //zfcs_contract2015SupplierInfoTypeIndividualPersonForeignState
                                                                                break;
                                                                            }
                                                                        case "zfcs_contract2015SupplierInfoTypeIndividualPersonRFIndEntrisCulture":
                                                                            {
                                                                                break;
                                                                                var s = st as zfcs_contract2015SupplierInfoTypeIndividualPersonRFIndEntrisCulture;
                                                                                var suppler = new Suppliers();
                                                                                suppler.Inn = s.EGRIPInfo.INN;
                                                                                suppler.Kpp = string.Empty;
                                                                                suppler.Okpo = string.Empty;
                                                                                suppler.Oktmo = string.Empty;
                                                                                var fullname = $"{s.EGRIPInfo.lastName ?? string.Empty} {s.EGRIPInfo.firstName ?? string.Empty} {s.EGRIPInfo.middleName ?? string.Empty}";
                                                                                suppler.FullName = fullname;
                                                                                suppler.ContactPhone = s.otherInfo.contactPhone ?? string.Empty;
                                                                                //suppler.LegalForm = JsonConvert.SerializeObject(s.otherInfo.isIP) ?? string.Empty;
                                                                                suppler.Okopf = String.Empty;
                                                                                suppler.IsIP = true;

                                                                                var postAdressInfo = new zfcs_contract2015SupplierInfoTypeLegalEntityRFOtherInfoPostAdressInfo();


                                                                                if (s.otherInfo.postAddressInfo != null)
                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.otherInfo.postAddressInfo.mailingAdress ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = s.otherInfo.postAddressInfo.postBoxNumber ?? String.Empty;
                                                                                    postAdressInfo.mailFacilityName = s.otherInfo.postAddressInfo.mailFacilityName ?? String.Empty;
                                                                                }
                                                                                else

                                                                                {
                                                                                    postAdressInfo.mailingAdress = s.EGRIPInfo.address ?? String.Empty;
                                                                                    postAdressInfo.postBoxNumber = String.Empty;
                                                                                    postAdressInfo.mailFacilityName = String.Empty;
                                                                                }

                                                                                suppler.PostAddress = JsonConvert.SerializeObject(postAdressInfo) ?? string.Empty;
                                                                                suppler.RegistrationDate = s.EGRIPInfo.registrationDate;
                                                                                //Console.WriteLine(st.ToString());
                                                                                csuppler.Add(suppler);
                                                                                Console.WriteLine(TypeName);
                                                                                break;
                                                                            }
                                                                            default: {
                                                                                Console.WriteLine(TypeName);
                                                                                break;
                                                                            }
                                                                    }
                                                                    //if (TypeName == "zfcs_contract2015SupplierInfoTypeLegalEntityRF")
                                                                    //{
                                                                    //    var s = st as zfcs_contract2015SupplierInfoTypeLegalEntityRF;
                                                                    //    var suppler = new Suppliers();
                                                                    //    suppler.Inn = s.EGRULInfo.INN;
                                                                    //    suppler.Kpp = s.EGRULInfo.KPP ?? string.Empty;
                                                                    //    suppler.Okpo = s.otherInfo.OKPO;
                                                                    //    suppler.Oktmo = JsonConvert.SerializeObject(s.otherInfo.OKTMO);
                                                                    //    suppler.FullName = s.EGRULInfo.fullName;
                                                                    //    suppler.ContactPhone = s.otherInfo.contactPhone;
                                                                    //    suppler.LegalForm = JsonConvert.SerializeObject(s.EGRULInfo.legalForm);
                                                                    //    suppler.PostAddress = JsonConvert.SerializeObject(s.otherInfo.postAdressInfo);
                                                                    //    //Console.WriteLine(st.ToString());
                                                                    //    csuppler.Add(suppler);
                                                                    //}
                                                                    //else
                                                                    //{
                                                                    //    Console.WriteLine(TypeName);
                                                                    //}
                                                                        //var s = st as zfcs_contract2015SupplierInfoTypeIndividualPersonRFIndEntr
                                                                        
                                                                }
                                                            }
                                                        }

                                                        break;
                                                        }
                                                    case "contractCancel": //contractCancel;zfcs_contractCancel2015Type - Информация об анулировании контракта;
                                                        {
                                                        zfcs_contractCancel2015Type contractCancel = exportd.Items[0] as zfcs_contractCancel2015Type;
                                                        string unf_json = JsonConvert.SerializeObject(contractCancel);
                                                        var pcontract = new ContractsProcedures();
                                                        //fscn.Wname = "";
                                                        pcontract.Contract_num = contractCancel.regNum;
                                                        //fcontract.R_body = djson;
                                                        pcontract .R_body = unf_json;
                                                        pcontract.Xml_body = read_xml_text;
                                                        pcontract.Hash = hashstr;
                                                        pcontract.Zip_file = nFile.Full_path;
                                                        pcontract.File_name = entry.FullName;
                                                        pcontract.Fz_type = 44;
                                                        pcontract.PublishDate = contractCancel.publishDate;
                                                        pcontract.CancelDate = contractCancel.cancelDate;
                                                        pcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                        contractsProc.Add(pcontract);
                                                            //_dataServices.SaveNotification(notifications);
                                                            break;
                                                        }
                                                    case "contractProcedure": //contractProcedure;zfcs_contractProcedure2015Type - Информация об исполнении (расторжении) контракта;
                                                        {
                                                            zfcs_contractProcedure2015Type contractProcedure = exportd.Items[0] as zfcs_contractProcedure2015Type;
                                                            string unf_json = JsonConvert.SerializeObject(contractProcedure);
                                                        var pcontract = new ContractsProcedures();
                                                        //fscn.Wname = "";
                                                        pcontract.Contract_num = contractProcedure.regNum;
                                                            //fcontract.R_body = djson;
                                                        pcontract.R_body = unf_json;
                                                        pcontract.Xml_body = read_xml_text;
                                                            pcontract.Hash = hashstr;
                                                            pcontract.Zip_file = nFile.Full_path;
                                                            pcontract.File_name = entry.FullName;
                                                            pcontract.Fz_type = 44;
                                                            pcontract.PublishDate = contractProcedure.publishDate;
                                                            pcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                        contractsProc.Add(pcontract);
                                                            //_dataServices.SaveNotification(notifications);
                                                            break;
                                                        }
                                                    case "contractProcedureCancel": //contractProcedureCancel;zfcs_contractProcedureCancel2015Type - Сведения об отмене информации об исполнении (расторжении) контракта;
                                                        {
                                                            zfcs_contractProcedureCancel2015Type contractProcedureCancel = exportd.Items[0] as zfcs_contractProcedureCancel2015Type;
                                                            string unf_json = JsonConvert.SerializeObject(contractProcedureCancel);
                                                            var pcontract = new ContractsProcedures();
                                                            //fscn.Wname = "";
                                                            pcontract.Contract_num = contractProcedureCancel.regNum;
                                                        //fcontract.R_body = djson;
                                                            pcontract.R_body = unf_json;
                                                        pcontract.Xml_body = read_xml_text;
                                                        pcontract.Hash = hashstr;
                                                            pcontract.Zip_file = nFile.Full_path;
                                                            pcontract.File_name = entry.FullName;
                                                            pcontract.Fz_type = 44;
                                                            try
                                                            {
                                                                pcontract.PublishDate = ObjectToDateTime(contractProcedureCancel.Items[0], DateTime.MaxValue); 
                                                            }
                                                            catch
                                                            { 
                                                            
                                                            }
                                                            
                                                            pcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                        contractsProc.Add(pcontract);
                                                        break;
                                                    }
                                                    case "contractAvailableForElAct": //contractAvailableForElAct;zfcs_contractAvailableForElAct - Квитанция о доступности формирования документов электронного актирования по контракту;
                                                        {
                                                            zfcs_contractAvailableForElAct zfcs_contractAvailableForElAct = exportd.Items[0] as zfcs_contractAvailableForElAct;
                                                            string unf_json = JsonConvert.SerializeObject(zfcs_contractAvailableForElAct);
                                                        var pcontract = new ContractsProcedures();
                                                        //fscn.Wname = "";
                                                        pcontract.Contract_num = zfcs_contractAvailableForElAct.regNum;
                                                            //fcontract.R_body = djson;
                                                        pcontract.R_body = unf_json;
                                                        pcontract.Xml_body = read_xml_text;
                                                        pcontract.Hash = hashstr;
                                                        pcontract.Zip_file = nFile.Full_path;
                                                        pcontract.File_name = entry.FullName;
                                                        pcontract.Fz_type = 44;
                                                        pcontract.PublishDate = zfcs_contractAvailableForElAct.availableDT;
                                                        pcontract.Type_contract = exportd.Items[0].GetType().Name;
                                                        contractsProc.Add(pcontract);
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

                        _logger.LogInformation($"Всего добавляется записей Contracts/ContractsProc в БД: {contracts.Count}/{contractsProc.Count} из {nFile.Zip_file}");
                    _dataServices.SaveSuppliersPoc(csuppler);
                    _dataServices.SaveContracts(contracts);
                    _dataServices.SaveContractsProc(contractsProc);
                    nFile.Status = Status.Processed;
                        nFile.Modifid_date = DateTime.Now;
                        _dataServices.UpdateCasheFiles(nFile);
                        //Чистим после себя
                        try
                        { 
                            if (File.Exists(zipPath) && nFile.Date <= DateTime.Now.AddDays(-_commonSettings.KeepDay)) File.Delete(zipPath);
                            Directory.Delete(extractPath, true);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError($"Файл заблокирован {zipPath}");
                            _logger.LogError(ex, ex.Message);
                        }

                    }
                    else
                    {
                        _logger.LogError($"Файл не найден {zipPath}");
                        //Меняем и пробуем загрузить заново
                        nFile.Status = Status.Exist;
                        _dataServices.UpdateCasheFiles(nFile);
                    }
                }

            //);//end Parallel.ForEach(


        }


        public static DateTime ObjectToDateTime(object o, DateTime defaultValue)
        {
            if (o == null) return defaultValue;

            DateTime dt;
            if (DateTime.TryParse(o.ToString(), out dt))
                return dt;
            else
                return defaultValue;
        }
    }
}

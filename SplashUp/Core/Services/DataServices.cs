﻿using SplashUp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SplashUp.Data.DB;
using SplashUp.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using SplashUp.Data.Extention;
using Newtonsoft.Json;
using SplashUp.Models.Zakupki_gov_ru.Fl44;

namespace SplashUp.Core.Services
{
    internal class DataServices : IDataServices
    {
        private readonly IGovDbManager _govDb;
        private readonly ILogger _logger;


        public DataServices(IGovDbManager govDb, ILogger<DataServices> logger)
        {
            _govDb = govDb;
            _logger = logger;
        }

        #region NSI File Cash

        /// <summary>
        /// Получение списка файлов из кэша.
        /// </summary>
        /// <param name="lim"></param>
        /// <param name="status"></param>
        /// <param name="fz_type"></param>
        /// <param name="basepath"></param>
        /// <param name="dirtype"></param>
        /// <returns></returns>
        public List<NsiFileCashes> GetNsiDBList(int lim, Status status, FLType fz_type, string basepath, string dirtype)
        {
            //throw new NotImplementedException();

            List<NsiFileCashes> data = new List<NsiFileCashes>();

            using (var db = _govDb.GetContext())
            {
                data = db.NsiFileCashes
                    .AsNoTracking()
                    .Where(x => x.Status == status
                    && x.Fz_type == fz_type
                    && x.BaseDir == basepath
                    && x.Dirtype == dirtype)
                    //Выбираем более старые файлы, т.к. важна последовательность загрузки.
                    .OrderBy(x => x.Date)
                    //.OrderByDescending(x => x.Date)
                    .Take(lim)
                    .ToList();
            }
            return data;
        }

        /// <summary>
        /// Обновление статусов кэша файлов 
        /// </summary>
        /// <param name="fileCashes"></param>
        public void UpdateNsiCasheFiles(NsiFileCashes fileCashes)
        {
            using (var db = _govDb.GetContext())
            {
                db.NsiFileCashes.Update(fileCashes);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Сохранение данных организации из справочника.
        /// </summary>
        /// <param name="nsiOrganizations"></param>
        public void SaveNsiOrgList(List<NsiOrganizations> nsiOrganizations)
        {

            foreach (var organization in nsiOrganizations)
            {
                using (var db = _govDb.GetContext())
                {
                    try
                    {
                        var find = db.NsiOrganizations
                        .AsNoTracking()
                        .Where(x => x.RegNumber == organization.RegNumber
                        && x.Fz_type == organization.Fz_type)
                        .OrderByDescending(x=>x.changeESIADateTime)
                        .FirstOrDefault();
                        //.SingleOrDefault();

                        if (find == null)
                        {
                            db.NsiOrganizations.Add(organization);
                            db.SaveChanges();
                        }
                        else
                        if (find.changeESIADateTime <= organization.changeESIADateTime)
                        {
                            find.NsiData = organization.NsiData;
                            find.FullName = organization.FullName;
                            find.IsActual = organization.IsActual;
                            find.NsiData = organization.NsiData;
                            find.Inn = organization.Inn ?? string.Empty;
                            find.Kpp = organization.Kpp ?? string.Empty;
                            find.Ogrn = organization.Ogrn ?? string.Empty;
                            find.RegistrationDate = organization.RegistrationDate;
                            find.changeESIADateTime = organization.changeESIADateTime;
                            find.Accounts = organization.Accounts;
                            db.NsiOrganizations.Update(find);
                            db.SaveChanges();
                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                    }
                }
            }
        }

        #endregion NSI File Cash

        #region Data File Cash
        /// <summary>
        /// Получение списка файлов на загрузку
        /// </summary>
        /// <param name="lim"></param>
        /// <param name="status"></param>
        /// <param name="fz_type"></param>
        /// <returns></returns>
        public List<FileCashes> GetDwList(int lim, Status status, FLType fz_type)
        {
            List<FileCashes> data = new List<FileCashes>();

            using (var db = _govDb.GetContext())
            {
                data = db.FileCashes
                    .AsNoTracking()
                    .Where(x => x.Status == status && x.Fz_type == fz_type)
                    .OrderByDescending(x => x.Date)
                    .Take(lim)
                    .ToList();
            }
            
            return data;
        }

        /// <summary>
        /// Проверка на наличие имеющейся записи о файле
        /// </summary>
        /// <param name="FullPath"></param>
        /// <returns></returns>
        public bool CheckCasheFiles(string FullPath)
        {
            FileCashes find = null;

            using (var db = _govDb.GetContext())
            {
                find = db.FileCashes
                    .AsNoTracking()
                    .Where(x => x.Full_path == FullPath)
                    .OrderByDescending(x => x.Date)
                    .FirstOrDefault();
            }
            if (find == null) return false;
            else return true;
        }

        /// <summary>
        /// Обновление данных по загрузке в кэше
        /// </summary>
        /// <param name="fileCashes"></param>
        public void UpdateCasheFiles(FileCashes fileCashes)
        {
            using (var db = _govDb.GetContext())
            {
                db.FileCashes.Update(fileCashes);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление из кэша несуществующего/недоступного на ftp файла 
        /// </summary>
        /// <param name="fileCashes"></param>
        public void DeleteCasheFiles(FileCashes fileCashes)
        {
            using (var db = _govDb.GetContext())
            {
                db.FileCashes.Remove(fileCashes);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение списка файлов из кэша по извещениям и протоколам.
        /// </summary>
        /// <param name="lim"></param>
        /// <param name="status"></param>
        /// <param name="fz_type"></param>
        /// <param name="basepath"></param>
        /// <param name="dirtype"></param>
        /// <returns></returns>
        public List<FileCashes> GetFileCashesList(int lim, Status status, FLType fz_type, string basepath, string dirtype)
        {
            //throw new NotImplementedException();

            List<FileCashes> data = new List<FileCashes>();

            using (var db = _govDb.GetContext())
            {
                data = db.FileCashes
                    .AsNoTracking()
                    .Where(x => x.Status == status
                    && x.Fz_type == fz_type
                    && x.BaseDir == basepath
                    && x.Dirtype == dirtype)
                    .OrderBy(x => x.Date)
                    //.OrderByDescending(x => x.Date)
                    .Take(lim)
                    .ToList();
            }
            return data;

        }

        /// <summary>
        /// Сохранение данных извещений.
        /// </summary>
        /// <param name="notifications"></param>
        public void SaveNotification(List<Notifications> notifications)
        {

            foreach (var notif in notifications)
            {
                using (var db = _govDb.GetContext())
                {
                    try
                    {
                        //var find = db.Notifications
                        //.AsNoTracking()
                        //.Where(x => x.Purchase_num == notif.Purchase_num
                        //&& x.Fz_type == notif.Fz_type
                        //&& x.PublishDate == notif.PublishDate
                        //&& x.Hash == notif.Hash)
                        //.SingleOrDefault();

                        var find = db.Notifications
                        .AsNoTracking()
                        .Where(x => x.Hash == notif.Hash)
                        .SingleOrDefault();

                        if (find == null)
                        {
                            db.Notifications.Add(notif);
                            db.SaveChanges();
                        }
                        //else
                        //{
                        //    find.R_body = notif.R_body;
                        //    find.ContractConclusion = notif.ContractConclusion;
                        //    find.Wname = notif.Wname;
                        //    find.Inn = notif.Inn ?? string.Empty;
                        //    find.Zip_file = notif.Zip_file;
                        //    find.File_name = notif.File_name;
                        //    db.Notifications.Update(find);
                        //    db.SaveChanges();
                        //}

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Сохранение данных контрактов.
        /// </summary>
        /// <param name="contracts"></param>
        public void SaveContracts(List<Contracts> contracts)
        {
            foreach (var c in contracts)
            {
                using (var db = _govDb.GetContext())
                {
                    try
                    {
                        //var find = db.Contracts
                        //.AsNoTracking()
                        //.Where(x => x.Contract_num == c.Contract_num
                        //&& x.Fz_type == c.Fz_type
                        //&& x.PublishDate == c.PublishDate
                        //&& x.Hash == c.Hash)
                        //.SingleOrDefault();

                        var find = db.Contracts
                        .AsNoTracking()
                        .Where(x => x.Hash == c.Hash)
                        .SingleOrDefault();

                        //var find = db.Contracts
                        //.AsNoTracking()
                        //.Where(x => x.Contract_num == c.Contract_num 
                        //&& x.Type_contract==c.Type_contract)
                        //.SingleOrDefault();

                        if (find == null)
                        {

                            db.Contracts.Add(c);
                            db.SaveChanges();
                        }
                        //else
                        //{
                        //    if (find.PublishDate < c.PublishDate)
                        //    {
                        //        c.Id = find.Id;
                        //        db.Contracts.Update(c);
                        //        db.SaveChanges();
                        //    }
                        //}
                        

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"{c.Id} / {c.Contract_num} /{c.Hash}");
                        _logger.LogError(ex, ex.Message);
                    }
                }
            }
        }


        public void SaveContractsProc(List<ContractsProcedures> pcontracts)
        {
            foreach (var c in pcontracts)
            {
                using (var db = _govDb.GetContext())
                {
                    try
                    {
                        //var find = db.Contracts
                        //.AsNoTracking()
                        //.Where(x => x.Contract_num == c.Contract_num
                        //&& x.Fz_type == c.Fz_type
                        //&& x.PublishDate == c.PublishDate
                        //&& x.Hash == c.Hash)
                        //.SingleOrDefault();

                        var find = db.ContractsProcedures
                        .AsNoTracking()
                        .Where(x => x.Hash == c.Hash)
                        .SingleOrDefault();


                        if (find == null)
                        {

                            db.ContractsProcedures.Add(c);
                            db.SaveChanges();
                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"{c.Id} / {c.Contract_num} /{c.Hash}");
                        _logger.LogError(ex, ex.Message);
                    }
                }
            }
        }
        public void SaveProtocols(List<Protocols> protocols)
        {

            foreach (var p in protocols)
            {
                using (var db = _govDb.GetContext())
                {
                    try
                    {
                        //var find = db.Protocols
                        //.AsNoTracking()
                        //.Where(x => x.Protocol_num == p.Protocol_num
                        //&& x.Fz_type == p.Fz_type
                        //&& x.PublishDate == p.PublishDate
                        //&& x.Hash == p.Hash)
                        //.SingleOrDefault();

                        var find = db.Protocols
                        .AsNoTracking()
                        .Where(x => x.Hash == p.Hash)
                        .SingleOrDefault();

                        if (find == null)
                        {
                            db.Protocols.Add(p);
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                    }
                }
            }

        }
        #endregion Data File Cash

        #region XMLTransform
        public string XmlToJson(string pathxml)
        {
            var json = "";
            Console.WriteLine(pathxml);
            XmlDocument xmldoc = new XmlDocument();
            try
            { 
                xmldoc.Load(pathxml);
                XmlNode xmlNode = xmldoc.DocumentElement;
                var childNode = xmlNode.ChildNodes[0];
                string ns2 = childNode.LocalName;
                string nodeName = childNode.LocalName;
                //ToDo RemoveSig
                RemoveSignatureNodes(childNode);
                var xDoc = xmldoc.ToXDocument();

                RemoveDefNamespace(xDoc.Root);
                var root = xDoc.Root;
                var rElement = root.Element(nodeName);
                rElement.Add(new XElement("_ns2", ns2));
                json = JsonConvert.SerializeXNode(rElement, Newtonsoft.Json.Formatting.Indented, true);

                return json;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message + pathxml);
                json = "";
            }
            //finally
            //{
            //    json = "";
            //}

            return json;
        }

        private static void RemoveDefNamespace(XElement element)
        {
            var defNamespase = element.Attribute("xmlns");
            if (defNamespase != null)
                defNamespase.Remove();


            element.Name = element.Name.LocalName;
            foreach (var child in element.Elements())
            {
                RemoveDefNamespace(child);
            }
        }


        private static void RemoveSignatureNodes(XmlNode xmlNode)
        {
            List<XmlNode> nodesToRemove = new List<XmlNode>();
            foreach (XmlNode childNodes in xmlNode.ChildNodes)
            {
                if (childNodes.Name == "signature" || childNodes.Name == "ns3:signature") nodesToRemove.Add(childNodes);
                else RemoveSignatureNodes(childNodes);
            }
            foreach (var node in nodesToRemove)
            {
                xmlNode.RemoveChild(node);
            }
        }

        #endregion XMLTransform

    }
}

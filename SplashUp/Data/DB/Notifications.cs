using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SplashUp.Data.DB
{
    public class Notifications
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Номер закупки
        /// </summary>
        [Column(TypeName = "varchar(20)")]
        public string Purchase_num { get; set; }
        /// <summary>
        /// Номер протокола
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string ProtocolNum { get; set; }
        /// <summary>
        /// Тело извещения
        /// </summary>
        [Column(TypeName = "jsonb")]
        public string R_body { get; set; }
        ///// <summary>
        ///// Тело извещения XML
        ///// </summary>
        [Column(TypeName = "xml")]
        public string Xml_body { get; set; }
        /// <summary>
        /// ИНН участника
        /// </summary>
        [Column(TypeName = "varchar(12)")]
        public string Inn { get; set; }
        /// <summary>
        /// Полное наименование участника
        /// </summary>
        [Column(TypeName = "varchar(1024)")]
        public string Wname { get; set; }
        /// <summary>
        /// Данные участника аукциона
        /// </summary>
        [Column(TypeName = "jsonb")]
        public string ParticipantInfo { get; set; }
        /// <summary>
        /// Порядковый номер заявки по результатам аукциона. {интересны 1 и 2 }
        /// </summary>
        public short AppRating { get; set; }
        /// <summary>
        /// Заключение контракта по статье 83 ч. 2. Игнорируется при приёме, заполняется при выгрузке.
        /// Для закупок со способом определения поставщика "Электронный аукцион" если признак не заполнен или заполнен false, то по данной закупке от электронной площадки в ЕИС передается документ CоntractSign(как и раньше), 
        /// протоколы ПОК и ППУ формируются на площадке и передаются в ЕИС.
        /// Если признак заполнен в true, то по данной закупке будет формироваться проект контракта, документ CоntractSign от площадки в ЕИС не передается, протоколы ПОК и ППУ формируются в ЕИС
        /// </summary>
       
        public bool contractConclusionOnSt83Ch2 { get; set; }
        /// <summary>
        /// Номер заявки в журнале регистрации
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string JournalNumber { get; set; }
        /// <summary>
        /// Цена победителя. 
        /// </summary>
        [Column(TypeName = "numeric(18,2)")]
        public decimal W_price { get; set; }
        /// <summary>
        /// Хэш XML данных
        /// </summary>
        [Column(TypeName = "varchar(64)")]
        public string Hash { get; set; }
        /// <summary>
        /// Тип извещения
        /// </summary>
        [Column(TypeName = "varchar(64)")]
        public string Type_notif { get; set; }
        /// <summary>
        /// Архив источник
        /// </summary>
        [Column(TypeName = "varchar(256)")]
        public string Zip_file { get; set; }
        /// <summary>
        /// Файл источник
        /// </summary>
        [Column(TypeName = "varchar(128)")]
        public string File_name { get; set; }
        /// <summary>
        /// Тип ФЗ
        /// </summary>
        [Column(TypeName = "smallint")]
        public int Fz_type { get; set; }
        /// <summary>
        /// Дата поведения итогов электронного аукциона + publishDTInETP Дата и время размещения документа на ЭТП
        /// </summary>
        [Column(TypeName = "timestamp without time zone")]
        public DateTime ProtocolDate { get; set; }
        /// <summary>
        /// Дата публикации + publishDTInEIS Дата и время размещения документа в ЕИС. 
        /// При передаче заполняется датой размещения документа в ЕИС
        /// Элемент игнорируется при приёме. 
        /// </summary>

        [Column(TypeName = "timestamp without time zone")]
        public DateTime PublishDate { get; set; }
    }
}

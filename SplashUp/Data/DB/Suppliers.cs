using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace  SplashUp.Data.DB
{
    public class Suppliers
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Номер Поставщика
        /// </summary>
        [Column(TypeName = "varchar(12)")]
        public string Inn { get; set; }
        /// <summary>
        /// КПП поставщика
        /// </summary>
        [Column(TypeName = "varchar(20)")]
        public string Kpp { get; set; }
        /// <summary>
        /// ОГРН поставщика
        /// </summary>
        public string Ogrn { get; set; }
        /// <summary>
        /// ОКТМО
        /// </summary>
        [Column(TypeName = "jsonb")]
        public string Oktmo { get; set; }
        /// <summary>
        /// ОКПО
        /// </summary>
        [Column(TypeName = "varchar(20)")]
        public string Okpo { get; set; }
        
        [Column(TypeName = "varchar(2048)")]
        public string FullName { get; set; }
        /// <summary>
        /// Организационно-правовая форма организации в ОКОПФ. - nsiOKOPF
        /// </summary>
        [Column(TypeName = "varchar(5)")]
        public string Okopf { get; set; }

        /// <summary>
        /// Индивидуальный предприниматель
        /// </summary>
        public bool IsIP { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "varchar(2048)")]
        public string PostAddress { get; set; }

        [Column(TypeName = "varchar(2048)")]
        public string ContactPhone { get; set; }

    }
}

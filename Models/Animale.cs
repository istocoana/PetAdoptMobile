using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

namespace PetAdoptM.Models
{
    public class Animale
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]
        public string Description { get; set; }
        public string Name { get; set; }

        [ForeignKey(typeof(Locatie))]
        public int LocatieID { get; set; }

        [ForeignKey(typeof(Tipuri))]
        public int TipuriID { get; set; }
    }
}
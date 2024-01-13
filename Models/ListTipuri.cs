using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace PetAdoptM.Models
{
    public class ListTipuri
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Animale))]
        public int AnimaleID { get; set; }
        public int TipuriID { get; set; }
    }
}
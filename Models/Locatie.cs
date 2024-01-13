using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace PetAdoptM.Models
{
    public class Locatie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Localitate { get; set; }
        public string Adress { get; set; }
        public string LocatieDetails
        {
            get
            {
                return Localitate + " " + Adress;
            }
        }

        [OneToMany]
        public List<Animale> ShopLists { get; set; }
    }
}
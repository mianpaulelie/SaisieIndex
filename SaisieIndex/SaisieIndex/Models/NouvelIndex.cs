using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaisieIndex.Models
{
    public class NouvelIndex
    {
        [PrimaryKey]
        public int IdClient { get; set; }
        public string Nom { get; set; }
        public string Genre { get; set; }
        public string Souscription { get; set; }


    }
}

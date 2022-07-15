using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace consumo_de_api.Models
{
    public class CharacterModel
    {
        /*
        
        

        */

        public int Id { get; set; }
        public string Name { get; set; }
        public string nickname { get; set; }
        public string birthday { get; set; }
        public List<string> occupation { get; set; }
        public string status { get; set; }
        public string img { get; set; }
    }
}
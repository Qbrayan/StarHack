using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Person
    {

        public int Id { get; set; }
        public string name { get; set; }

        public int height { get; set; }
        public int mass { get; set; }
        public string hair_color { get; set; }

        public string skin_color { get; set; }

        public string eye_color { get; set; }

        public string birth_year { get; set; }

        public string gender { get; set; }

        public string homeworld { get; set; }

        [NotMapped]
        public List<string> films { get; set; }

        [NotMapped]
        public List<string> species { get; set; }

        [NotMapped]
        public List<string> vehicles { get; set; }

        [NotMapped]
        public List<string> starships { get; set; }

        [NotMapped]
        public DateTime created { get; set; }

        [NotMapped]
        public DateTime edited { get; set; }

        [NotMapped]
        public string url { get; set; }



    }
}

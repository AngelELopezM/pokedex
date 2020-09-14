using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
   public class repositorio_pokemon
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string foto { get; set; }
        public int tipo1 { get; set; }
        public int tipo2 { get; set; }
        public int region { get; set; }
    }
}

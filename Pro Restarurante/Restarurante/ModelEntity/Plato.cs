using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class Plato
    {
        public int IdPlato { get; set; }
        public string nombrep { get; set; }
        public string descrip { get; set; }
        public int nivel { get; set; }
        public string foto { get; set; }
        public decimal precio { get; set; }
        public int  idCategoria { get; set; }
    }
}

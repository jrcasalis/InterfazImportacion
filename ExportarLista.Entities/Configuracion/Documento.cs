using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportarLista.Entities
{
    public class Documento
    {
        public String TipoDocumento { get; set; }
        public String FormatoNombre { get; set; }
        public String BuscarPor { get; set; }
        public String BuscarHasta { get; set; }
        public String BuscarEn { get; set; }
        public String Identificacion { get; set; }
    }
}

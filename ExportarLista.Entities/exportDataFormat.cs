using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExportarLista.Entities
{
    public class ExportDataFormat
    {
        public String DataSeparator { get; set; }
        public String IVA { get; set; }
        public String Profit { get; set; }
        public Boolean UseIVA { get; set; }
        public Boolean UseProfit { get; set; }
        public Form Form { get; set; }
        public Boolean FirstLineEmpty { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportarLista.Entities.Exceptions
{
    public class ExportException : Exception
    {
        public ExportException(String message)
        : base(message)
        {
        }
    }
}

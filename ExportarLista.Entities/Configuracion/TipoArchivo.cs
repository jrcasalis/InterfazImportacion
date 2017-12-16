using System;
using System.Collections.Generic;

namespace ExportarLista.Entities.Configuracion
{
    public class TipoArchivo : EntityBase
    {
        public int tipo { get; set; }
        public String rutaOrigen { get; set; }
        public String rutaDestino { get; set; }
        public Boolean enviarMail { get; set; }
        public String directorioEspera { get; set; }
        public String opcionales { get; set; }
        public String clase { get; set; }
        public String metodo { get; set; }
        public String remitenteMail { get; set; }
        public String usuarioMail { get; set; }
        public String passwordMail { get; set; }
        //Datos opcionales a rellenar
        public List<Documento> documentos { get; set; }
        public String mailServer { get; set; }
        public int puerto { get; set; }
        public Boolean ssl { get; set; }


    }
}

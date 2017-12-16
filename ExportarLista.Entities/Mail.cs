using System;
using System.Collections.Generic;

namespace ExportarLista.Entities
{
    public class Mail
    {
        public String remitente { get; set; }
        public List<String> destinatarios { get; set; }
        public String asunto { get; set; }
        public String responderA { get; set; }
        public String cuerpo { get; set; }
        public Boolean cuerpoEsHtml { get; set; }
        public List<String> archivosAdjuntos { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
        
        #region DatosServidor
        public String servidor { get; set; }
        public int puerto { get; set; }
        public Boolean ssl { get; set; }
        #endregion

        public override String ToString()
        {
            return String.Format("De: {0},\nPara: {1},\nAsunto: {2},\nResp A: {3},\n" + 
                "Cuerpo: {4},\nEsHtml?: {5},\nAdjuntos: {6},\nServer: {7},\nPort: {8},\nSSL: {9} ///" +
                "Usuario: {10}",
                remitente, string.Join(",", destinatarios.ToArray()), asunto, responderA, cuerpo,
                Convert.ToBoolean(cuerpoEsHtml), string.Join(",", archivosAdjuntos.ToArray()), servidor,
                puerto, ssl, usuario);
        }
    }
}

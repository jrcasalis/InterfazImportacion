using System;
using System.Configuration;

namespace ExportarLista.Entities.Configuracion
{
    public class TipoArchivoElement : ConfigurationElement
    {
        //Make sure to set IsKey=true for property exposed as the GetElementKey above
        [ConfigurationProperty("Tipo", IsKey = true, IsRequired = true)]
        public Int16 Tipo
        {
            get { return Convert.ToInt16(this["Tipo"]); }
            set { this["Tipo"] = value; }
        }

        [ConfigurationProperty("RutaOrigen")]
        public String RutaOrigen
        {
            get { return this["RutaOrigen"] as String; }
            set { this["RutaOrigen"] = value; }
        }

        [ConfigurationProperty("RutaDestino")]
        public String RutaDestino
        {
            get { return this["RutaDestino"] as String; }
            set { this["RutaDestino"] = value; }
        }

        [ConfigurationProperty("EnviarMail", DefaultValue = false)]
        public Boolean EnviarMail
        {
            get { return Convert.ToBoolean(this["EnviarMail"]); }
            set { this["EnviarMail"] = value; }
        }

        [ConfigurationProperty("DirectorioEspera", DefaultValue = "")]
        public String DirectorioEspera
        {
            get { return this["DirectorioEspera"] as String; }
            set { this["DirectorioEspera"] = value; }
        }
        
        [ConfigurationProperty("Opcionales", DefaultValue = "")]
        public String Opcionales
        {
            get { return this["Opcionales"] as String; }
            set { this["Opcionales"] = value; }
        }

        [ConfigurationProperty("Clase")]
        public String Clase
        {
            get { return this["Clase"] as String; }
            set { this["Clase"] = value; }
        }

        [ConfigurationProperty("Metodo")]
        public String Metodo
        {
            get { return this["Metodo"] as String; }
            set { this["Metodo"] = value; }
        }

        [ConfigurationProperty("RemitenteMail", DefaultValue = "")]
        public String RemitenteMail
        {
            get { return this["RemitenteMail"] as String; }
            set { this["RemitenteMail"] = value; }
        }
        
        [ConfigurationProperty("UsuarioMail", DefaultValue = "")]
        public String UsuarioMail
        {
            get { return this["UsuarioMail"] as String; }
            set { this["UsuarioMail"] = value; }
        }

        [ConfigurationProperty("PasswordMail", DefaultValue = "")]
        public String PasswordMail
        {
            get { return this["PasswordMail"] as String; }
            set { this["PasswordMail"] = value; }
        }




        public TipoArchivo getTipoArchivoFromElement()
        {
            return new TipoArchivo
            {
                tipo = this.Tipo,
                rutaOrigen = this.RutaOrigen,
                rutaDestino = this.RutaDestino,
                enviarMail = this.EnviarMail,
                directorioEspera = this.DirectorioEspera,
                opcionales = this.Opcionales,
                clase = this.Clase,
                metodo = this.Metodo,
                remitenteMail = this.RemitenteMail,
                usuarioMail = this.UsuarioMail,
                passwordMail = PasswordMail
            };
        }
    }
    //public class TipoArchivoElement : ConfigurationElement
    //{
    //    public string InnerText { get; private set; }

    //    protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
    //    {
    //        InnerText = reader.ReadElementContentAsString();
    //    }
    //}
}

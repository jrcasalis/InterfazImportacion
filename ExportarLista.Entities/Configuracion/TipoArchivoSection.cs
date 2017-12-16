using System;
using System.Configuration;

namespace ExportarLista.Entities.Configuracion
{
    public class TipoArchivoSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public TiposArchivoCollection TiposArchivos
        {
            get { return (TiposArchivoCollection)this[""]; }
            set { this[""] = value; }
        }
    }
    
}
/*

[ConfigurationProperty("Tipo")]
public TipoArchivoElement Tipo
{
    get { return this["Tipo"] as TipoArchivoElement; }
    set { this["Tipo"] = value; }
}

[ConfigurationProperty("RutaOrigen")]
public TipoArchivoElement RutaOrigen
{
    get { return this["RutaOrigen"] as TipoArchivoElement; }
    set { this["RutaOrigen"] = value; }
}

[ConfigurationProperty("rutaDestino")]
public TipoArchivoElement rutaDestino
{
    get { return this["rutaDestino"] as TipoArchivoElement; }
    set { this["rutaDestino"] = value; }
}

[ConfigurationProperty("EnviarMail")]
public TipoArchivoElement EnviarMail
{
    get { return this["EnviarMail"] as TipoArchivoElement; }
    set { this["EnviarMail"] = value; }
}

public TipoArchivo CreateTipoArchivoFromConfig()
{
    return new TipoArchivo()
    {
        Tipo = Convert.ToInt32(this.Tipo.InnerText),
        RutaOrigen = this.RutaOrigen.InnerText,
        rutaDestino = this.rutaDestino.InnerText,
        EnviarMail = Convert.ToBoolean(this.EnviarMail.InnerText)
    };
}

}
}
*/

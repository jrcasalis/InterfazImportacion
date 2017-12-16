using System.Configuration;

namespace ExportarLista.Entities.Configuracion
{
    public class TiposArchivoCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TipoArchivoElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            //set to whatever Element Property you want to use for a key
            return ((TipoArchivoElement)element).Tipo;
        }
    }
}

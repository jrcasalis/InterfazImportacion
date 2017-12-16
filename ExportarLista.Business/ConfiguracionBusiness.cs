using ExportarLista.Business.Interfaces;
using ExportarLista.Entities;
using ExportarLista.Entities.Configuracion;
using ExportarLista.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ExportarLista.Business
{
    public class ConfiguracionBusiness : IConfiguracionBusiness
    {
        public List<TipoArchivo> BuscarConfiguracionTipoArchivo()
        {
            List<TipoArchivo> tiposArchivo = new List<TipoArchivo>();
            try
            {
                var config = ConfigurationManager.GetSection("TiposArchivoGroup/TipoArchivo") as TipoArchivoSection;

                foreach (TipoArchivoElement e in config.TiposArchivos)
                {
                    tiposArchivo.Add(e.getTipoArchivoFromElement());
                }
                return tiposArchivo;
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new ExportException("Error al leer la configuración de tipos de archivos");
            }
        }

        public TipoArchivo BuscarConfiguracionTipoArchivoPorTipo(int tipoArchivo)
        {
            List<TipoArchivo> tipos = BuscarConfiguracionTipoArchivo();
            if (tipos.Count > 0)
            {
                foreach (TipoArchivo tipo in tipos)
                {
                    if (tipoArchivo.Equals(tipo.tipo))
                    {
                        return ArmarDatosOpcionales(tipo);
                    }
                }
                throw new ExportException("No se encuentra el tipo de archivo solicitado");
            }
            else
            {
                throw new ExportException("No se encuentra cargado ningún tipo de archivos");
            }
        }

        private TipoArchivo ArmarDatosOpcionales(TipoArchivo tipo)
        {
            try
            {
                switch (tipo.tipo)
                {
                    case 1:
                        //Busca los tipos de documentos y la denominación de los archivos
                        var opcionales = tipo.opcionales.Split(';');
                        tipo.documentos = new List<Documento>();
                        foreach (String par in opcionales)
                        {
                            Documento documento = new Documento();
                            var parSeparado = par.Split(',');
                            if (parSeparado.Length < 6)
                            {
                                throw new ExportException("El configurador de archivos de tipo " + tipo.tipo
                                    + ", posee el valor 'Opcionales' cargado de forma errónea.");
                            }
                            documento.TipoDocumento = parSeparado[0];
                            documento.FormatoNombre = parSeparado[1];
                            documento.BuscarPor = parSeparado[2];
                            documento.BuscarHasta = parSeparado[3];
                            documento.BuscarEn = parSeparado[4];
                            documento.Identificacion = parSeparado[5];
                            tipo.documentos.Add(documento);
                        }
                        return tipo;

                    default:
                        return tipo;
                }
            }
            catch (Exception e)
            {
                throw new ExportException("Error en armado de datos opcionales para tipo " + tipo.tipo.ToString() + 
                    " --> ERROR ORIGINAL; " + e.Message);
            }            
        }
    }
}

using ExportarLista.Business.Interfaces;
using ExportarLista.Entities.Configuracion;
using ExportarLista.Entities.Exceptions;
using ExportarLista.UI.Views;
using Microsoft.Practices.Unity;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ExportarLista.UI
{
    public class Program
    {
        /******************
         * Declaraciones 
         * */
        [Dependency]
        public static IConfiguracionBusiness ConfiguracionBusiness { get; set; }
        [Dependency]
        public static IExportarArchivosBusiness PdfBusiness { get; set; }
        [Dependency]
        public static IMailBusiness MailBusiness { get; set; }

        /******************
         * Fin declaraciones 
         * */
         [STAThread]
        static void Main(string[] args)
        {
            //var container = UnityConfig.RegisterComponents();
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Principal());
                //if (!args.Length.Equals(0))
                //{
                //    int pTipoArchivo = Convert.ToInt16(args[0]);
                //    if (pTipoArchivo.Equals(0))
                //    {
                //        throw new CopiaException("Se debe ingresar un tipo de archivo");
                //    }

                //    ConfiguracionBusiness = container.Resolve<IConfiguracionBusiness>();

                //    MailBusiness = container.Resolve<IMailBusiness>();

                //    //MailBusiness.EnviarMail();

                //    TipoArchivo tipoCopiar = ConfiguracionBusiness.BuscarConfiguracionTipoArchivoPorTipo(pTipoArchivo);
                    
                //    if (tipoCopiar.enviarMail)
                //    {
                //        //Setea los datos de envío de mails de servidor
                //        var appSettings = ConfigurationManager.AppSettings;
                //        var valor = string.IsNullOrEmpty(appSettings["mailServer"]) ? "No encontrado" :appSettings["mailServer"];
                //        tipoCopiar.mailServer = valor;

                //        valor = string.IsNullOrEmpty(appSettings["puerto"]) ? "0": appSettings["puerto"];
                //        tipoCopiar.puerto = Convert.ToInt32(valor);

                //        valor = string.IsNullOrEmpty(appSettings["ssl"]) ? "false" : appSettings["ssl"];
                //        tipoCopiar.ssl = Convert.ToBoolean(valor);
                //    }

                //    //Mail mail = new Mail
                //    //{
                //    //    remitente = tipoCopiar.remitenteMail,
                //    //    destinatarios = new List<String>(new string[] { "soniaafrutos@gmail.com", "jcasalis@yahoo.com.ar" }),
                //    //    asunto = "Enviando desde app",
                //    //    responderA = "jcasalis@gmail.com",
                //    //    cuerpo = "<h1>Enviando correos</h1><p/><h2>José Casalis,</h2>",
                //    //    cuerpoEsHtml = true,
                //    //    archivosAdjuntos = new List<String>(new string[] { @"C:\Users\jrcasalis\Desktop\avatar.jpg",
                //    //        @"C:\Users\jrcasalis\Desktop\NOtas.txt",
                //    //        @"C:\Users\jrcasalis\Desktop\Credito.xlsx" }),
                //    //    servidor = tipoCopiar.mailServer,
                //    //    puerto = tipoCopiar.puerto,
                //    //    ssl = tipoCopiar.ssl,
                //    //    usuario = tipoCopiar.usuarioMail,
                //    //    password = tipoCopiar.passwordMail

                //    //};
                //    ////MailBusiness.EnviarMail(mail);
                //    //Console.WriteLine(mail.ToString());

                //    //Console.WriteLine("Tipo encontrado: {0}, con ruta origen {1} y destino {2}.", tipoCopiar.Tipo,tipoCopiar.RutaOrigen, tipoCopiar.rutaDestino);
                //    try
                //    {
                //        Type tipo = Type.GetType(tipoCopiar.clase);
                //        var methodInfo = tipo.GetMethod(tipoCopiar.metodo);
                //        var instancia = System.Activator.CreateInstance(tipo);
                        
                //        //Es necesario que por estandar, se envíe
                //        //un container del tipo UnityContainer para inyectar los servicios
                //        //y un TipoArchivo para trabajar cada tipo por separado
                //        object[] parametros = new object[] { container, tipoCopiar };
                //        var resultado = methodInfo.Invoke(instancia, parametros);
                //    }
                //    catch (Exception e)
                //    {
                //        throw new CopiaException("Error en la configuración de clase y método de ejecución en la configuración. Datos: " +
                //            tipoCopiar.clase + "." + tipoCopiar.metodo + " --> Error original: " + e.Message);
                //    }
                //}
                //else
                //{
                //        throw new CopiaException("Se debe ingresar un tipo de archivo");
                //    }
                }
            catch (ExportException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
        }
    }
}

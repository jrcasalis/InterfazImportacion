using ExportarLista.Entities;
using ExportarLista.Entities.Configuracion;
using System;
using System.Collections.Generic;

namespace ExportarLista.Business.Interfaces
{
    public interface IMailBusiness
    {
        Boolean EnviarMail(Mail mail);
    }
}

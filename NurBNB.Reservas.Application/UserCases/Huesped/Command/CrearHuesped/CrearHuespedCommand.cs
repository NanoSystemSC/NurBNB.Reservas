using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NurBNB.Reservas.Application.UserCases.Huesped.Command.CrearHuesped;

public class CrearHuespedCommand: IRequest<Guid>
{
    public string Nombre { get;  set; }
    public string Apellidos { get;  set; }
    public string Telefono { get;  set; }
    public string NroDoc { get;  set; }
    public string Email { get;  set; }

    public string Calle { get;  set; }
    public string Ciudad { get;  set; }
    public string Pais { get;  set; }
    public string Codigo_postal { get;  set; }

}

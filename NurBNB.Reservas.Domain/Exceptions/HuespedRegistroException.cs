using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Reservas.Domain.Exceptions
{
    public class HuespedRegistroException : Exception
    {
        public HuespedRegistroException(string reason) : base("Error en el registro por que : "+ reason +"") 
        {

        }
    }
}

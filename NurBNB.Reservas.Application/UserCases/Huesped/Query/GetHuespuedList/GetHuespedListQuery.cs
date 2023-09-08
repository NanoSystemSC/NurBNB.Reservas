using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NurBNB.Reservas.Application.Dto.Huesped;

namespace NurBNB.Reservas.Application.UserCases.Huesped.Query.GetHuespuedList
{
    [ExcludeFromCodeCoverage]
    public class GetHuespedListQuery: IRequest<ICollection<HuespedDto>>
    {
        public string SearchTerm { get; set; }
    }
}

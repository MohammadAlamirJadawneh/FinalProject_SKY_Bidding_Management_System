using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKY_Bidding_Management_System_Library.SKY_Bidding_Management_System_CQRS.Commands.Tender_Commands
{
    public record RefreshToUpdateTenderStatusCommand : IRequest<Unit>;

}

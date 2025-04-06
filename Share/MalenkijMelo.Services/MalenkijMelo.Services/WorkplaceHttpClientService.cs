using MalenkijMelo.Services.Base;
using MalenkijMelo.Services.IHttpClientServices;
using MalenkijMelo.Share.Assemblers;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Services
{
    public class WorkplaceHttpClientService : HttpClientServiceBase<Workplace, WorkplaceDto>, IWorkplaceHttpClientService
    {
        public WorkplaceHttpClientService(WorkplaceAssembler? assembler) : base(assembler)
        {
        }
    }
}

using MalenkijMelo.Share.Converters;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Assemblers
{
    public class JobAssembler : Assembler<Job, JobDto>
    {
        public override JobDto ConvertToDto(Job model)
        {
            return model.ConvertToJobDto();
        }

        public override Job ConvertToModel(JobDto dto)
        {
            return dto.ConvertToJob();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Assemblers
{
    public abstract class Assembler<TModel, TDto>
    {
        public abstract TModel ConvertToModel(TDto dto);
        public abstract TDto ConvertToDto(TModel model);
    }
}

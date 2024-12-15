using ECommerce.Core.Utilities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.ConcreteDto
{
    public abstract class DtoGetBase : IDto
    {
        public ResultStatus ResultStatus { get; set; }
        public string Message { get; set; }
    }
}

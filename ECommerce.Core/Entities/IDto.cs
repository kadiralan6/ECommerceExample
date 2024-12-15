using ECommerce.Core.Utilities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public interface IDto
    {
       ResultStatus ResultStatus { get; }
        string Message { get; }
    }
}

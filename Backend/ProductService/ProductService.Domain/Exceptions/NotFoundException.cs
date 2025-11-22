using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Exceptions
{
    public class NotFoundException:DomainException
    {
        public NotFoundException(string name ,object key):base($"{name} with key '{key}' was not found.") { }
    }
}

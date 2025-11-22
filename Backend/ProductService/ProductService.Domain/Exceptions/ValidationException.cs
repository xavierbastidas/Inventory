using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Exceptions
{
    public class ValidationException:Exception
    {
        public IDictionary<string, string[]>Errors { get; }

        public ValidationException():base ("Validation errors ocurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IDictionary<string, string[]> errors) : this()
        {
            Errors=errors;
        }

    }
}

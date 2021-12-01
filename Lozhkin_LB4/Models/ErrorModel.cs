using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lozhkin_LB4.Models
{
    public class ErrorModel
    {
        public ErrorModel(string error)
        {
            Error = error;
        }

        public string Error { get; set; }
    }
}

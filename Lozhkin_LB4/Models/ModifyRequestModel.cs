using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lozhkin_LB4.Models
{
    public class ModifyRequestModel<T>
    {
        public T Entity { get; set; }

        public int Id { get; set; }
    }
}

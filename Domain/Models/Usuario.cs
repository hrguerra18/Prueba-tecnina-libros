using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Usuario : ModelBase
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}

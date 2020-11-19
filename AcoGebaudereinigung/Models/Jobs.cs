using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoGebaudereinigung.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Alt { get; set; }
        public byte[] Image { get; set; }
    }
}

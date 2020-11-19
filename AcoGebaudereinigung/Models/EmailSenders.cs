using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcoGebaudereinigung.Models.ViewModels
{
    public class EmailSenders
    {
        public int Id { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}

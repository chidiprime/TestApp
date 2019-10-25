using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProj.Models
{
    public class ViewModel
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string scope { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
}

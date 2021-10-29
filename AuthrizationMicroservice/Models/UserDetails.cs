using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthrizationMicroservice.Models
{
    public class UserDetails
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<SelectListItem> roles { get; set; }
        public string roleId {get;set;}
    }
}

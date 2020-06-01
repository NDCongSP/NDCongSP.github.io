using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class LoginModel
    {
        [Required]
        public string userName { set; get; }
        public string password { set; get; }
        public bool rememberMe { set; get; }
    }
}

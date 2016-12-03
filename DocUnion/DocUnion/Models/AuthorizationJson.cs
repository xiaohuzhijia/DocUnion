using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DocUnion.Models
{
  public  class AuthorizationJson
    {
      
        public string code { get; set; }
        public string authorizationcode { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
        public AuthorizationJson()
        {

        }

    }
}

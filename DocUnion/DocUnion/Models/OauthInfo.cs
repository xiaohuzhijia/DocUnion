using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DocUnion.Models
{
   public class OauthInfo
    {

        public OauthInfo()
        {


        }
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        [Unique]
        public string Telephone { get; set; }
        public string AcessToken { get; set; }
        public string RefreshToken { get; set; }
        public bool   IsDefault { get; set; }


        




    }
}

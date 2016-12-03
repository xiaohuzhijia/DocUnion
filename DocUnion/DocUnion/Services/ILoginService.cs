using DocUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocUnion.Services
{
   public interface ILoginService
    {

        //由手机号和密码获得acesstoken和refreshtoken；

        Task<OauthInfo> GetAcessTokenAsync(string Telephone, string Password);

        //由refreshtoken刷新acesstoken和refreshtoken；
        Task<OauthInfo> RefreshAcessTokenAsync(OauthInfo Old);

        bool SaveOauthInfoAsync(OauthInfo info);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocUnion
{
   public class Constants
    {
        public static string AuthorizationCodeUrl = "http://123.206.29.130/oauth2/authorize.php";
        public static string RedirectUrl = "http://123.206.29.130/thinkphp/index.php/home/oauthtoken";
        public static string ResourceUrl = "http://123.206.29.130/oauth2/resource.php";
        public static string AcessTokenUrl = "http://123.206.29.130/oauth2/token.php";
        public static string RfreshTokenUrl = "http://123.206.29.130/oauth2/token.php";
        //注册url
        public static string SignupUrl = "http://123.206.29.130/thinkphp/index.php/home/signup";



        public static string State = "xyz";
        public static string ResponseType = "code";
        public static string ClientId = "testclient";
        public static string ClientSecret = "testpass";
        public static string GrantTypeAuthorizationCode = "authorization_code";
        public static string GrantTypeRfreshToken = "refresh_token";




        //阿里大鱼
        public static string appkey = "23454716";
        public static string secret = "a28559f85b22a1d156a4b9d9ca46a609";
        public static string serverurl= "http://123.206.29.130/oauth2/taobao-sdk-PHP/rest.php";


    }
}

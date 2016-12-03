using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocUnion.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using DocUnion.Services.SQLite;

namespace DocUnion.Services
{
    class LoginService : ILoginService
    {
        HttpClient client;
        public OauthInfo OauthInfos { get; set; }
        public static OathoQuery OathoQuery;

        public LoginService()
        {
            var AuthData = string.Format("{0}:{1}", Constants.ClientId, Constants.ClientSecret);
            var AuthHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(AuthData));
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", AuthHeaderValue);
        }

        //400 账号、密码错误
        //401网络连接错误等
        //402authorization 超时
        public async Task<OauthInfo> GetAcessTokenAsync(string Telephone, string Password)
        {




            OauthInfos = new OauthInfo();
            //string Client_credentialsUrl = "http://123.206.29.130/oauth2/token.php";

            var uri = new Uri(string.Format(Constants.AuthorizationCodeUrl + "?response_type=" + Constants.ResponseType + "&client_id=" + Constants.ClientId + "&state=" + Constants.State + "&redirect_uri=" + Constants.RedirectUrl));


            //string  Telephone1="13240811453";
            //string  Password1="a2678015";
            string Autho = "授权";


            string para = string.Format("telephone={0}&password={1}&authorized={2}", Telephone, Password, Autho);

            // var content = new StringContent(para, Encoding.UTF8, "application/json");
            var content = new StringContent(para, Encoding.UTF8, "application/x-www-form-urlencoded");
            // var content = new StringContent(para, Encoding.UTF8, "multipart/form-data");
            HttpResponseMessage response = null;

            try
            {



                response = await client.PostAsync(uri, content);
                var content11 = await response.Content.ReadAsStringAsync();
                //response.

                //从重定向网址上得到的报文；
                var Authorizationcode = JsonConvert.DeserializeObject<AuthorizationJson>(content11);
                if (Authorizationcode.code == "200")
                {//正确获得Authozrizationcode




                    var uri2 = new Uri(string.Format(Constants.AcessTokenUrl));

                    var para2 = string.Format("grant_type={0}&code={1}&redirect_uri={2}", Constants.GrantTypeAuthorizationCode, Authorizationcode.authorizationcode, Constants.RedirectUrl);

                    var content2 = new StringContent(para2, Encoding.UTF8, "application/x-www-form-urlencoded");
                    HttpResponseMessage response2 = null;
                    try
                    {
                        response2 = await client.PostAsync(uri2, content2);
                        var content22 = await response2.Content.ReadAsStringAsync();
                        //response.

                        //从重定向网址上得到的报文；
                        try
                        {
                            var AcessTokenInfo = JsonConvert.DeserializeObject<AcessTokenInfo>(content22);
                            OauthInfos.Telephone = Telephone;
                            OauthInfos.AcessToken = AcessTokenInfo.access_token;
                            OauthInfos.RefreshToken = AcessTokenInfo.refresh_token;
                            OauthInfos.IsDefault = true;
                          //  return OauthInfos;


                        }
                        catch (Exception ex)
                        {

                            //402 authorization 超时
                            Debug.WriteLine(@"				ERROR {0}", ex.Message);
                            var AcessErrorInfo = JsonConvert.DeserializeObject<AcessErrorInfo>(content22);
                            OauthInfos.Telephone = "402";
                            return OauthInfos;

                        }


                    }
                    catch (Exception ex)
                    {
                        //网络连接错误等
                        Debug.WriteLine(@"				ERROR {0}", ex.Message);
                        OauthInfos.Telephone = "401";
                        return OauthInfos;
                    }







                }
                else if (Authorizationcode.code == "201")
                {

                    //账号、密码错误
                    Debug.WriteLine(@"				ERROR {0}", Authorizationcode.error);
                    OauthInfos.Telephone = "400";
                    return OauthInfos;
                }
            }
            catch (Exception ex)
            {
                //网络连接错误等
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
                OauthInfos.Telephone = "401";
                return OauthInfos;
            }






            return OauthInfos;
            // throw new NotImplementedException();
        }














       //查询acesstoken是否过期
       public async Task<int> IsAcessTokenExpired(string acesstoken)
        {

            //401网络错误
            //1 未过期
            //0过期

            HttpClient client2=new HttpClient();

            var uri = new Uri(string.Format(Constants.ResourceUrl));
            var para = string.Format("access_token={0}", acesstoken);

            var content = new StringContent(para, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = null;
            try
            {

                response = await client2.PostAsync(uri, content);
                var content22 = await response.Content.ReadAsStringAsync();

                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(content22);


                foreach (var kv in dict)
                {
                    if (kv.Key == "success")
                    {
                        return 1;


                    }
                    
                      
                    



                }

                return 0;


            }
            catch (Exception ex)
            {

                //401 网络错误
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
               // OauthInfos.Telephone = "401";

                return 401;
            }





        }


















        public async Task<OauthInfo> RefreshAcessTokenAsync(OauthInfo Old)
        {
            //
            //403    refresh token 不存在(已经使用或者过期)
            //401 网络错误

            OauthInfos = new OauthInfo();
            var uri = new Uri(string.Format(Constants.RfreshTokenUrl));

            var para = string.Format("grant_type={0}&refresh_token={1}", Constants.GrantTypeRfreshToken, Old.RefreshToken);

            var content = new StringContent(para, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = null;
            try
            {
                response = await client.PostAsync(uri, content);
                var content22 = await response.Content.ReadAsStringAsync();
                //response.

                //从重定向网址上得到的报文；


                var AcessTokenInfo = JsonConvert.DeserializeObject<AcessTokenInfo>(content22);

                // var AcessTokenInfo = JsonConvert.DeserializeObject<AcessTokenInfo>(content22);


                if (AcessTokenInfo.access_token != null)
                {
                    OauthInfos.Telephone = Old.Telephone;
                    OauthInfos.UserId = Old.UserId;
                    OauthInfos.AcessToken = AcessTokenInfo.access_token;
                    OauthInfos.RefreshToken = AcessTokenInfo.refresh_token;
                    OauthInfos.IsDefault = true;

                }
                 else
                {
                    // refresh token 不存在(已经使用或者过期)
                    OauthInfos.Telephone = "403";
                    return OauthInfos;
                }


               








                //throw new NotImplementedException();
            }

            catch (Exception ex)
            {

                //401 网络错误
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
                OauthInfos.Telephone = "401";
                return OauthInfos;

            }

            return OauthInfos;

        }








        //查询默认账号的OauthInfos
        public OauthInfo GetDefaltOathinfo()
        {
            OathoQuery = new OathoQuery();
            var tel = OathoQuery.GetDefaltTel();

            var OauthInfo = OathoQuery.GetOathinfo(tel);


            return OauthInfo;


        }


        public bool SaveOauthInfoAsync(OauthInfo info)
        {
            OathoQuery = new OathoQuery();
            try

            {
                var NotTel = OathoQuery.GetOathinfoNotTel(info.Telephone);

                foreach(var s in NotTel)
                {
                    OathoQuery.SetOathNotDefault(s);
                }
                OathoQuery.SaveOath0Info(info);
               //var ee= OathoQuery.IsExitItems();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


            // throw new NotImplementedException();
        }
    }
}

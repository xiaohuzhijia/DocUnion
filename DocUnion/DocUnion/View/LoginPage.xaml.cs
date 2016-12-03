using DocUnion.Models;
using DocUnion.Services;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DocUnion.View
{
    public partial class LoginPage : ContentPage
    {

        LoginService LoginService;

        public LoginPage()
        {
           

           //去掉登陆界面的标题栏;
            InitializeComponent();
            NavigationPage.SetTitleIcon(this, "logo.png");

             NavigationPage.SetHasNavigationBar(this, false);
            //var assembly=typeof(EmbeddedImages)
        }

        private async void Button_Login_OnClicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();


            //DatagramSocket DatagramSocket

            btLogin.IsEnabled = false;

            LoginService = new LoginService();

            UserIdEntry.Keyboard = Keyboard.Telephone;
            var AcessTokenByPasswd= await LoginService.GetAcessTokenAsync(UserIdEntry.Text, PasseordEntry.Text);



            //var ss = await LoginService.IsAcessTokenExpired(AcessTokenByPasswd.AcessToken);
            //AcessTokenByPasswd.RefreshToken = "434234234";
            //var AcessTokenByRefresh= await LoginService.RefreshAcessTokenAsync(AcessTokenByPasswd);
            //正常获得11位手机账号的acesstoken
            if (AcessTokenByPasswd.Telephone.Length == 11)
            {
                var dd = LoginService.SaveOauthInfoAsync(AcessTokenByPasswd);
                await DisplayAlert("Alert", "欢迎"+AcessTokenByPasswd.Telephone, "OK");
                await DisplayAlert("Alert", "登录成功", "OK");
                Debug.WriteLine("登陆成功");
              //  await Navigation.

            }


            else if (AcessTokenByPasswd.Telephone == "401")
            {
                await DisplayAlert("Alert", "网络未连接", "OK");
                Debug.WriteLine("网络未连接");
            }
            else if (AcessTokenByPasswd.Telephone == "400")
            {
                await DisplayAlert("Alert", "账号密码错误", "OK");
                Debug.WriteLine("账号密码错误");
            }
            //else {
            //    Debug.WriteLine("授权码超时");
            //}




            // string LoginUrl =  "http://192.168.1.105/thinkphp/index.php/home/login";


            // string callstring = UserIdEntry.Text;
            // double calldouble = Convert.ToDouble(callstring);

            //// UserIdEntry.Keyboard = Keyboard.Telephone;
            // var passwd = PasseordEntry.Text;
            // var item = new UserLoginInf { call = calldouble, password = passwd };
            // HttpClient client = new HttpClient();
            // var json = JsonConvert.SerializeObject(item);
            // var content = new StringContent(json, Encoding.UTF8, "application/json");
            // HttpResponseMessage response = null;
            // var uri = new Uri(string.Format(LoginUrl, string.Empty));
            // response = await client.PostAsync(uri, content);
            // var content11 = await response.Content.ReadAsStringAsync();


            btLogin.IsEnabled = true;
        }


        public async void Button_Signup_OnClicked(object sender, EventArgs e)
        {
           //  MainPage= new  NavigationPage(new SignUpPage());  
         // throw new NotImplementedException();
              //   new LoginPage();
            await Navigation.PushAsync(new SignUpPage());
            


        }

        

        

        async void Button_Reset_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPasswdPage());
        }
    }
}

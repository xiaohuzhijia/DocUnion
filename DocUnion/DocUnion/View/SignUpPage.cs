using DocUnion.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace DocUnion.View
{
  public  class SignUpPage:ContentPage
    {
        public List<UserLoginInf> Items { get; private set; }
        Entry telEntry,passwordEntry,repasswordEntry,checkEntry;
       Button signUpButton, checkBtn;
        public int Shutdown ;
        HttpClient client;
        public string randomcheck;
        public string telwithcheck;//与验证码绑定的手机号

        public SignUpPage()
      {

            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
           
            NavigationPage.SetTitleIcon(this, "logo.png");
          BackgroundColor = Color.White;
            client = new HttpClient();
            telEntry = new Entry
            {
                Text = "",
                Placeholder = "请输入手机号码",
                PlaceholderColor = Color.Black,
                TextColor = Color.Black,
                BackgroundColor = Color.White
        };
          passwordEntry = new Entry
          {
              Text = "",
              IsPassword = true,
              Placeholder = "请输入密码",
              PlaceholderColor = Color.Black,
              BackgroundColor = Color.White,
              TextColor = Color.Black
          };
            repasswordEntry = new Entry
            {
                Text = "",
                IsPassword = true,
                Placeholder = "请再次输入密码",
                PlaceholderColor = Color.Black,
                BackgroundColor = Color.White,
                TextColor = Color.Black
            };
            checkEntry=new Entry
            {
                Text = "",
                PlaceholderColor =Color.Black,
                BackgroundColor = Color.White,
                TextColor = Color.Black,
                Placeholder = "验证码",
                HorizontalOptions=LayoutOptions.FillAndExpand
            };
            checkBtn = new Button
            {
                Text = "获取验证码",
                //Margin = new Thickness(0, 40, 0, 0),
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.End,

                BackgroundColor = Color.FromRgb(255, 220, 156)

            };

            checkBtn.Clicked += CheckBtn_Clicked;
           
            var checkLayout = new StackLayout {
                //HorizontalOptions=LayoutOptions.StartAndExpand,

                //VerticalOptions = LayoutOptions.StartAndExpand,
                Orientation =StackOrientation.Horizontal
            };
            checkLayout.Children.Add(checkEntry);
            checkLayout.Children.Add(checkBtn);

            var buttonLayout = new StackLayout
          {
                
             
              
              VerticalOptions = LayoutOptions.StartAndExpand,
          };
            signUpButton=new Button
            {
                Text = "注    册",
                Margin = new Thickness(0, 40, 0, 0),
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,


                BackgroundColor = Color.FromRgb(255,220,156)
            };
            buttonLayout.Children.Add(signUpButton);
            signUpButton.Clicked += SignUpButton_Clicked;
          Title = "注 册";
            var detail=new StackLayout
            {
               // Spacing = 10,
                
                Padding = new Thickness(2,1,2,1),
                BackgroundColor = Color.FromRgb(239, 242, 246),
                VerticalOptions = LayoutOptions.StartAndExpand,
          };
            detail.Children.Add(telEntry);
            detail.Children.Add(passwordEntry);
            detail.Children.Add(repasswordEntry);
            detail.Children.Add(checkLayout);

            var page=new StackLayout
            {
                Margin = new Thickness(50, 80, 50, 40),
                //Padding = new Thickness(5),
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.StartAndExpand,
            }; ;
            page.Children.Add(detail);
            page.Children.Add(buttonLayout);
          Content = page;

      }

        private async void CheckBtn_Clicked(object sender, EventArgs e)
        {
            Shutdown = 60;
            // randomcheck = "121211";
            randomcheck = CreateRandomCode(6);
            randomcheck = "121211";

            //实际要去掉固定的验证码
            //var aa = new Random();
            if (telEntry.Text.Length == 11)
            {

            
                string para = string.Format("appkey={0}&secretKey={1}&checkcode={2}&telphone={3}", Constants.appkey, Constants.secret, randomcheck, telEntry.Text);
                var content = new StringContent(para, Encoding.UTF8, "application/x-www-form-urlencoded");
                var uri = Constants.serverurl;

                HttpResponseMessage response = null;


                try
                {

                    //发送短信要去掉注释
                    //response = await client.PostAsync(uri, content);
                    Device.StartTimer(TimeSpan.FromMilliseconds(1000), OnTimerTick);
                    telwithcheck = telEntry.Text;


                }
                catch(Exception ex)
                {
                    await DisplayAlert("Alert", "网络未连接", "OK");
                }


            }
            else
            {
                await DisplayAlert("Alert", "请输入正确的手机号！", "OK");

            }









            //throw new NotImplementedException();
        }


        private string CreateRandomCode(int length)
        {
            int rand;
            char code;
            string randomcode = String.Empty;

            //生成一定长度的验证码
            System.Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                rand = random.Next();

                //if (rand % 3 == 0)
                //{
                //    code = (char)('A' + (char)(rand % 26));
                //}
                //else
                //{
                //    code = (char)('0' + (char)(rand % 10));
                //}
                code = (char)('0' + (char)(rand % 10));
                randomcode += code.ToString();
            }
            return randomcode;
        }








        bool OnTimerTick()
    { 
            if (Shutdown == 0)
            {
                checkBtn.Text = "重新获得验证码";
                Shutdown = 60;
                checkBtn.IsEnabled = true;
                return false;

            }

            else
            {
                checkBtn.Text = Shutdown+"秒";
                Shutdown--;
                checkBtn.IsEnabled = false;
                return true;
                   

            }

        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {

         







            if(checkEntry.Text == randomcheck&&telwithcheck==telEntry.Text)
            {

                

            
                if (telEntry.Text.Length == 11)

                {                                       
                    if (passwordEntry.Text == repasswordEntry.Text)

                    {


                        HttpClient client = new HttpClient();

                        //var uri = "http://192.168.241.11/thinkphp/index.php/home/signup";//本地数据库

                        var uri = new Uri(string.Format(Constants.SignupUrl));//腾讯数据库

                        var para = string.Format("telphone={0}&passwd={1}", telEntry.Text,passwordEntry.Text);


                        var content = new StringContent(para, Encoding.UTF8, "application/x-www-form-urlencoded");

                        HttpResponseMessage response = null;

                        try

                        {

                            response = await client.PostAsync(uri, content);
                            var content22 = await response.Content.ReadAsStringAsync();

                            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(content22);
                            //200 创建成功
                            //201 手机号存在
                            //202 创建用户失败
                            //203 手机号长度不正确
                         //请求完要清除验证码

                            switch (dict["code"])
                            {
                                case "200":
                                    randomcheck= CreateRandomCode(6);
                                    await DisplayAlert("Alert", dict["mes"], "OK");
                                    break;
                                case "201":
                                    passwordEntry.Text = "";
                                    repasswordEntry.Text = "";
                                    randomcheck = CreateRandomCode(6);
                                    await DisplayAlert("Alert", dict["mes"], "OK");
                                    break;
                                case "202":

                                    telEntry.Text = "";
                                    passwordEntry.Text = "";
                                    repasswordEntry.Text = "";
                                    randomcheck = CreateRandomCode(6);
                                    await DisplayAlert("Alert", dict["mes"], "OK");
                                    break;
                                case "203":
                                    telEntry.Text = "";
                                    passwordEntry.Text = "";
                                    repasswordEntry.Text = "";
                                    randomcheck = CreateRandomCode(6);
                                    await DisplayAlert("Alert", dict["mes"], "OK");
                                    break;
                                default:
                                    randomcheck = CreateRandomCode(6);
                                    break;
                            }                                            
                            
                        }
                        catch (Exception ex)

                        {
                            //401 网络错误
                            await DisplayAlert("Alert", "网络未连接！", "OK");

                        }


                    }



                    else

                    {

                        passwordEntry.Text = "";

                        repasswordEntry.Text = "";

                        await DisplayAlert("Alert", "两次输入的密码不一样！", "OK");

                    }







                }

                else

                {

                    telEntry.Text = "";
                    passwordEntry.Text = "";
                    repasswordEntry.Text = "";
                    
                    await DisplayAlert("Alert", "请输入正确的手机号！", "OK");


                }





            }
            else
            {

                await DisplayAlert("Alert", "验证码错误，请重新输入", "OK");

            }

        








             //Items = new List<UserLoginInf>();
            //HttpClient client;
            //client = new HttpClient();
            //string RestUrl = "http://192.168.1.105/thinkphp/index.php/home/user/read/1.json";
            //var uri = new Uri(string.Format(RestUrl, string.Empty));

            //var response = await client.GetAsync(uri);
            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    Items = JsonConvert.DeserializeObject<List<UserLoginInf>>(content);

            //}








            //var Item = new UserLoginInf { name = "12", call = 344 };
            //HttpClient client;
            //client = new HttpClient();

            //string RestUrl = "http://192.168.1.105/thinkphp/index.php/home/user/read/1.json";
            //var uri = new Uri(string.Format(RestUrl, string.Empty));
            //var json = JsonConvert.SerializeObject(Item);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = null;



            //response = await client.PostAsync(uri, content);

            //var content11 = await response.Content.ReadAsStringAsync();
            //var ss = JsonConvert.DeserializeObject<UserLoginInf>(content11);








            //var Item = new UserLoginInf { name = "12", call = 344 };
            //HttpClient client;



            //var AuthData = string.Format("{0}:{1}", Constants.ClientId, Constants.ClientSecret);
            //var AuthHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(AuthData));
            //client = new HttpClient();
            //client.MaxResponseContentBufferSize = 256000;
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", AuthHeaderValue);



            //string RestUrl = "http://123.206.29.130/oauth2/token.php";
            //var uri = new Uri(string.Format(RestUrl, string.Empty));
            //var json = "grant_type=client_credentials";
            //var content = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");
            //HttpResponseMessage response = null;



            //response = await client.PostAsync(uri, content);

            //var content11 = await response.Content.ReadAsStringAsync();
            //var ss = JsonConvert.DeserializeObject<UserLoginInf>(content11);





            // Items = JsonConvert.DeserializeObject<List<UserLoginInf>>(content11);
           // throw new NotImplementedException();
        }
    }
}

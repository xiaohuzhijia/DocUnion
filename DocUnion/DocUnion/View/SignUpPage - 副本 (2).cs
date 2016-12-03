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


        
        public SignUpPage()
      {

            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
           
            NavigationPage.SetTitleIcon(this, "logo.png");
          BackgroundColor = Color.White;

            telEntry = new Entry
            {
                Placeholder = "请输入手机号码",
                PlaceholderColor = Color.Black,
                TextColor = Color.Black,
                BackgroundColor = Color.White
              
            };

            passwordEntry = new Entry
            {
                IsPassword = true,
                Placeholder = "请输入密码",
                PlaceholderColor = Color.Black,
                BackgroundColor = Color.White,
                TextColor = Color.Black
            };
            repasswordEntry = new Entry
            {
                IsPassword = true,
                Placeholder = "请再次输入密码",
                PlaceholderColor = Color.Black,
                BackgroundColor = Color.White,
                TextColor = Color.Black
            };
            checkEntry = new Entry
            {
                PlaceholderColor = Color.Black,
                BackgroundColor = Color.White,
                TextColor = Color.Black,
                Placeholder = "验证码"

            };
            checkBtn = new Button
            {
                Text = "获取验证码",
                //Margin = new Thickness(0, 40, 0, 0),
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,



                BackgroundColor = Color.FromRgb(255, 220, 156)

            };
            signUpButton = new Button
            {
                Text = "注    册",
                Margin = new Thickness(0, 40, 0, 0),
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,


                BackgroundColor = Color.FromRgb(255, 220, 156)
            };


            var checkLayout = new StackLayout
            {
                Orientation=StackOrientation.Horizontal
            };

            checkLayout.Children.Add(checkEntry);
            checkLayout.Children.Add(checkBtn);



            var page = new StackLayout
            {
                Margin = new Thickness(50, 80, 50, 40),
                Padding = new Thickness(5),
                BackgroundColor = Color.White,
               // VerticalOptions = LayoutOptions.Start
               //HorizontalOptions=LayoutOptions.StartAndExpand
               Orientation=StackOrientation.Vertical
            };

            page.Children.Add(telEntry);
            page.Children.Add(passwordEntry);
            page.Children.Add(repasswordEntry);
            page.Children.Add(checkLayout);
            page.Children.Add(signUpButton);

            Content = page;
            //    telEntry=new Entry
            //    {
            //        Placeholder = "请输入手机号码",
            //        PlaceholderColor = Color.Black,
            //        TextColor = Color.Black,
            //        BackgroundColor = Color.White
            //};
            //  passwordEntry = new Entry
            //  {
            //      IsPassword = true,
            //      Placeholder = "请输入密码",
            //      PlaceholderColor = Color.Black,
            //      BackgroundColor = Color.White,
            //      TextColor = Color.Black
            //  };
            //    repasswordEntry = new Entry
            //    {
            //        IsPassword = true,
            //        Placeholder = "请再次输入密码",
            //        PlaceholderColor = Color.Black,
            //        BackgroundColor = Color.White,
            //        TextColor = Color.Black
            //    };
            //    checkEntry=new Entry
            //    {
            //        PlaceholderColor =Color.Black,
            //        BackgroundColor = Color.White,
            //        TextColor = Color.Black,
            //        Placeholder = "验证码",
            //    };
            //    checkBtn = new Button
            //    {
            //        Text = "获取验证码",
            //        //Margin = new Thickness(0, 40, 0, 0),
            //        TextColor = Color.White,
            //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
            //        FontAttributes = FontAttributes.Bold,


            //        BackgroundColor = Color.FromRgb(255, 220, 156)

            //    };

            //    var checkLayout = new StackLayout {
            //        HorizontalOptions=LayoutOptions.StartAndExpand,
            //    };
            //    checkLayout.Children.Add(checkEntry);
            //    checkLayout.Children.Add(checkBtn);

            //    var buttonLayout = new StackLayout
            //  {


            //      VerticalOptions = LayoutOptions.StartAndExpand,
            //  };
            //    signUpButton=new Button
            //    {
            //        Text = "注    册",
            //        Margin = new Thickness(0, 40, 0, 0),
            //        TextColor = Color.White,
            //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
            //        FontAttributes = FontAttributes.Bold,


            //        BackgroundColor = Color.FromRgb(255,220,156)
            //    };
            //    buttonLayout.Children.Add(signUpButton);
            //    signUpButton.Clicked += SignUpButton_Clicked;
            //  Title = "注 册";
            //    var detail=new StackLayout
            //    {
            //       // Spacing = 10,

            //        Padding = new Thickness(2,1,2,1),
            //        BackgroundColor = Color.FromRgb(239, 242, 246),
            //        VerticalOptions = LayoutOptions.StartAndExpand,
            //  };
            //    detail.Children.Add(telEntry);
            //    detail.Children.Add(passwordEntry);
            //    detail.Children.Add(repasswordEntry);
            //    detail.Children.Add(checkLayout);

            //    var page=new StackLayout
            //    {
            //        Margin = new Thickness(50, 80, 50, 40),
            //        //Padding = new Thickness(5),
            //        BackgroundColor = Color.White,
            //        VerticalOptions = LayoutOptions.StartAndExpand,
            //    }; ;
            //    page.Children.Add(detail);
            //    page.Children.Add(buttonLayout);
            //  Content = page;

        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
             Items = new List<UserLoginInf>();
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

            var Item = new UserLoginInf { name = "12", call = 344 };
            HttpClient client;
            client = new HttpClient();

            string RestUrl = "http://192.168.1.105/thinkphp/index.php/home/user/read/1.json";
            var uri = new Uri(string.Format(RestUrl, string.Empty));
            var json = JsonConvert.SerializeObject(Item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;



            response = await client.PostAsync(uri, content);

            var content11 = await response.Content.ReadAsStringAsync();
            var ss = JsonConvert.DeserializeObject<UserLoginInf>(content11);

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
            throw new NotImplementedException();
        }
    }
}

using DocUnion.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocUnion.View
{
    public class DefaultLoginPage:ContentPage
    {
        
        Button DefaultButton;//默认用户登录
        Button OtherUserButton;//其他用户登录
        LoginService Loginservice;


        public DefaultLoginPage()
        {

            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);

            NavigationPage.SetTitleIcon(this, "logo.png");
            BackgroundColor = Color.White;
            

            var buttonLayout = new StackLayout
            {


                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            DefaultButton = new Button
            {
                Text = "登录",
                Margin = new Thickness(0, 40, 0, 0),
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,


                BackgroundColor = Color.FromRgb(255, 220, 156)
            };
            OtherUserButton = new Button
            {
                Text = "其他用户",
                Margin = new Thickness(0, 40, 0, 0),
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,


                BackgroundColor = Color.FromRgb(255, 220, 156)
            };
            buttonLayout.Children.Add(DefaultButton);
            buttonLayout.Children.Add(OtherUserButton);
            DefaultButton.Clicked += DefaultButton_Clicked;
            OtherUserButton.Clicked += OtherUserButton_Clicked;
            Title = "登录";
          
           
            var page = new StackLayout
            {
                Margin = new Thickness(50, 80, 50, 40),
                //Padding = new Thickness(5),
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.StartAndExpand,
            }; ;
         
            page.Children.Add(buttonLayout);
            Content = page;

        }

        private async void OtherUserButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new LoginPage());



            // await Navigation.PushAsync(new LoginPage());
            //throw new NotImplementedException();
        }

        private async void DefaultButton_Clicked(object sender, EventArgs e)
        {
            DefaultButton.IsEnabled = false;

            Loginservice = new LoginService();

            var Oathinfo = Loginservice.GetDefaltOathinfo();

            var ss = await Loginservice.IsAcessTokenExpired(Oathinfo.AcessToken);


            if (ss == 401)
            {
                await DisplayAlert("Alert", "网络未连接", "OK");
                Debug.WriteLine("网络未连接");
            }
            else if (ss == 1)
            {
                await DisplayAlert("Alert", "欢迎"+ Oathinfo.Telephone, "OK");
                await DisplayAlert("Alert", "登陆成功", "OK");
                Debug.WriteLine("登录成功");
            }
            else if (ss == 0)
            {
                await DisplayAlert("Alert", "acesstoken 过期", "OK");
                Debug.WriteLine("acesstoken 过期");


                //使用refreshtoken刷险acesstoken，返回
                //403    refresh token 不存在(已经使用或者过期)
                //401 网络错误
                //否则返回acesstoken
                var NewOathinfo = await Loginservice.RefreshAcessTokenAsync(Oathinfo);


                if (NewOathinfo.Telephone == "403")
                {
                    await DisplayAlert("Alert", "Refreshtoken 过期", "OK");


                    Debug.WriteLine("Refreshtoken 过期");
                    await Navigation.PushAsync(new LoginPage());


                }
                else if (NewOathinfo.Telephone == "401")
                {
                    await DisplayAlert("Alert", "网络未连接", "OK");
                    Debug.WriteLine("网络未连接");
                }
                else if (NewOathinfo.Telephone.Length == 11)
                {
                    Loginservice.SaveOauthInfoAsync(NewOathinfo);
                    await DisplayAlert("Alert", "欢迎" + NewOathinfo.Telephone, "OK");
                    await DisplayAlert("Alert", "登录成功", "OK");
                    Debug.WriteLine("登录成功");



                }





            }

            //  throw new NotImplementedException();



            DefaultButton.IsEnabled = true;
        }
    }





}

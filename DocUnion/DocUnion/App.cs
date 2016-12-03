using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocUnion.View;
using Xamarin.Forms;
using DocUnion.Services;
using DocUnion.Services.SQLite;
namespace DocUnion
{
    public class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        //LoginService LoginService;
        public static OathoQuery OathoQuery;

        public App()
        {

            //datagramsocket()
            // The root page of your application
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
            
            IsUserLoggedIn = false;
            if (!IsUserLoggedIn)
            {
                OathoQuery = new OathoQuery();
                // LoginService = new LoginService();
                var nn =OathoQuery.IsExitItems();
                if (nn == false)
                {

                    var loginpage = new LoginPage();

                    var nav = new NavigationPage(loginpage);

                    NavigationPage.SetHasNavigationBar(this, false);

                    // nav.BarBackgroundColor = Color.White;

                    nav.BarBackgroundColor = Color.FromRgb(255, 224, 170);

                    nav.BarTextColor = Color.White;

                    nav.BackgroundColor = Color.White;

                    // nav.Icon = "logo.png";


                    //var lkk=new ();

                    MainPage = nav;
                    //MainPage = nav;
                    //MainPage = new NavigationPage(new LoginPage())
                    //{

                    //    BarBackgroundColor = Color.FromRgb(255,224,170),
                    //    BarTextColor = Color.White




                    //};

                    // MainPage = new LoginPage();
                }
                else
                {
                    var DefaultLoginPage = new DefaultLoginPage();

                    var nav = new NavigationPage(DefaultLoginPage);

                    NavigationPage.SetHasNavigationBar(this, false);
                                       
                    nav.BarBackgroundColor = Color.FromRgb(255, 224, 170);

                    nav.BarTextColor = Color.White;

                    nav.BackgroundColor = Color.White;
                                     
                    MainPage = nav;

                }

            }
            else
            {
              // MainPage = new NavigationPage(new MainPage());
                 MainPage = new MainPage();
            }
            

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

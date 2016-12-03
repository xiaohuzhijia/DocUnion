using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocUnion.View
{
  public  class NextResetPasswdPage:ContentPage
    {
        Entry PasswdEntry;
        Entry RepasswdEntry;
        Button ConfirmButton;
        public NextResetPasswdPage()
        {
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetTitleIcon(this, "logo.png");
            BackgroundColor = Color.White;
            PasswdEntry = new Entry
            {
                Text = "",
                IsPassword = true,
                BackgroundColor = Color.White,
                Placeholder = "请输入密码",
                PlaceholderColor = Color.Black,
                TextColor = Color.Black
            };
            RepasswdEntry = new Entry
            {
                Text = "",
                IsPassword = true,
                BackgroundColor = Color.White,
                Placeholder = "请再次输入密码",
                PlaceholderColor = Color.Black,
                TextColor = Color.Black
            };

            //nextButton = new Button
            //{
            //    Text = "确定",
            //    //Margin = new Thickness(0, 40, 0, 0),
            //    TextColor = Color.White,
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
            //    FontAttributes = FontAttributes.Bold,
            //    BackgroundColor = Color.FromRgb(255, 220, 156)
            //};
           
            Title = "找回密码";
            var detail = new StackLayout
            {
                Padding = new Thickness(2, 1, 2, 1),
                BackgroundColor = Color.FromRgb(239, 242, 246),
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            detail.Children.Add(PasswdEntry);
            detail.Children.Add(RepasswdEntry);

            var buttonLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
            };

            ConfirmButton = new Button
            {
                Text = "确定",
                Margin = new Thickness(0, 40, 0, 0),
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromRgb(255, 220, 156)
            };
            ConfirmButton.Clicked += ConfirmButton_Clicked;
            buttonLayout.Children.Add(ConfirmButton);
            var page = new StackLayout
            {
                Margin = new Thickness(50, 80, 50, 40),
                //Padding = new Thickness(5),
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            page.Children.Add(detail);
            page.Children.Add(ConfirmButton);

            Content = page;
          // ContentPage =new NavigationPage(new LoginPage());

        }

        async void ConfirmButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Page1());
            //await Navigation.PushAsync(new DetailPage());
            //await Navigation.

        }

    }
}

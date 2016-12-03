using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocUnion.View
{
   public class ResetPasswdPage:ContentPage
   {
       Entry telphonEntry;
       Entry checkEntry;
       Button nextButton;
       public ResetPasswdPage()
       {
            NavigationPage.SetHasNavigationBar(this,true);
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetTitleIcon(this, "logo.png");
            BackgroundColor = Color.White;
            telphonEntry=new Entry
            {
                Text = "",
                BackgroundColor = Color.White,
                Placeholder = "请输入手机号",
                PlaceholderColor = Color.Black,
                TextColor = Color.Black
            };
            checkEntry = new Entry
            {
                Text = "",
                BackgroundColor = Color.White,
                Placeholder = "验证码",
                PlaceholderColor = Color.Black,
                TextColor = Color.Black
            };
            
            nextButton = new Button
            {
                Text = "下一步",
                //Margin = new Thickness(0, 40, 0, 0),
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromRgb(255, 220, 156)
            };
            nextButton.Clicked += NextButton_Clicked;
           Title = "找回密码";
            var detail =new StackLayout
            {
                Padding = new Thickness(2, 1, 2, 1),
                BackgroundColor = Color.FromRgb(239, 242, 246),
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            detail.Children.Add(telphonEntry);
            detail.Children.Add(checkEntry);

            var buttonLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
            };

            //nextButton = new Button
            //{
            //    Text = "下一步",
            //    Margin = new Thickness(0, 40, 0, 0),
            //    TextColor = Color.White,
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
            //    FontAttributes = FontAttributes.Bold,
            //    BackgroundColor = Color.FromRgb(255, 220, 156)
            //};
            buttonLayout.Children.Add(nextButton);
            var page = new StackLayout
            {
                Margin = new Thickness(50, 80, 50, 40),
                //Padding = new Thickness(5),
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            page.Children.Add(detail);
            page.Children.Add(nextButton);

           Content = page;

       }

        async void NextButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NextResetPasswdPage());
        }
    }
}

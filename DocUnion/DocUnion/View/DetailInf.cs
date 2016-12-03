using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace DocUnion.View
{
    public class DetailInf : ContentPage
    {
        
        private Image headImage;
        private Image birthImage;
        private Label birthLabel;
        private DatePicker bitDatePicker;


        public DetailInf()
        {
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetTitleIcon(this, "logo.png");
            BackgroundColor = Color.White;
            Title = "完善资料";
            headImage = new Image
            {
                HorizontalOptions = LayoutOptions.Center
            };
            headImage.Source=ImageSource.FromResource("DocUnion.Image.logo.jpg");
            var headimagestack = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand

            };
            headimagestack.Children.Add(headImage);
            Content = headimagestack;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DocUnion.View
{
    public partial class DetailPage : ContentPage
    {
        public int Sex=0;
        public int Title = 0;
        public DetailPage()
        {

            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetTitleIcon(this, "logo.png");
            BackgroundColor = Color.White;

            



            InitializeComponent();


            foreach(string sexname in sexDict.Keys)
            {
                birtpicker.Items.Add(sexname);
            }

           
            imagechange.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLabelClicked()),
               
            });

            foreach(string title in titleDict.Keys)
            {

                titlepicker.Items.Add(title);
            }




        }

        

        Dictionary<string, int> sexDict = new Dictionary<string, int>
        {
            {"男",1 }, {"女",2 }
        };


        Dictionary<string, int> titleDict = new Dictionary<string, int>
        {

           {" 主任医师(医疗)",231 },
           {" 副主任医师(医疗)",232},
           {"主治医师(医疗)",233},
           {" 医师(医疗)",234},
           {" 医士(医疗)",235},
            {" 主任医师(药剂)",241 },
           {" 副主任医师(药剂)",242},
           {"主治医师(药剂)",243},
           {" 医师(药剂)",244},
           {" 医士(药剂)",245},
            {" 主任医师(护理)",251 },
           {" 副主任医师(护理)",252},
           {"主治医师(护理)",253},
           {" 医师(护理)",254},
           {" 医士(护理)",255},
            {" 主任医师(技师)",261 },
           {" 副主任医师(技师)",262},
           {"主治医师(技师)",263},
           {" 医师(技师)",264},
           {" 医士(技师)",265},
           
        };






        private void OnLabelClicked()
        {
            DisplayAlert("ss", "dd", "OK");
            //throw new NotImplementedException();
           
        }

        private void fromDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void birtpicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (birtpicker.SelectedIndex == -1)
            {
                Sex = 0;
                DisplayAlert("ss", "dd", "OK");
            }
            else
            {
                string colorName = birtpicker.Items[birtpicker.SelectedIndex];
                Sex = sexDict[colorName];
            }
            //birtpicker.Title = birtpicker.Items[birtpicker.SelectedIndex];
        }

        private void hospitaltext_Focused(object sender, FocusEventArgs e)
        {

        }

        private void depltext_Focused(object sender, FocusEventArgs e)
        {

        }

        private void titlepicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (titlepicker.SelectedIndex == -1)
            {
                Title = 0;
                DisplayAlert("ss", "dd", "OK");
            }
            else
            {
                string colorName = titlepicker.Items[titlepicker.SelectedIndex];
                Title = titleDict[colorName];
            }
        }

        private void majortext_Focused(object sender, FocusEventArgs e)
        {

        }

        private void benketext_Focused(object sender, FocusEventArgs e)
        {

        }
    }
}

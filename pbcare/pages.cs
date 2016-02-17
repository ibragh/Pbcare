using System;

using Xamarin.Forms;

namespace pbcare
{
    public class page1 : ContentPage
    {
        public page1()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage",TextColor=Color.Red }
                }
            };
        }
    }


    public class page2 : ContentPage
    {
        public page2()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage",TextColor=Color.Red }
                }
            };
        }
    }


    public class page3 : ContentPage
    {
        public page3()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage 3" , TextColor=Color.Red}
                }
            };
        }
    }


    public class page4 : ContentPage
    {
        public page4()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage 4" , TextColor=Color.Red}
                }
            };
        }

    }
}



using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace YogaUI
{
    public class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "Markup_Experimental" });

            MainPage = new MainPage();
        }
    }
}

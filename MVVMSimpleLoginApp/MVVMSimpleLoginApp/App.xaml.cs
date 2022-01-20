using MVVMSimpleLoginApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMSimpleLoginApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

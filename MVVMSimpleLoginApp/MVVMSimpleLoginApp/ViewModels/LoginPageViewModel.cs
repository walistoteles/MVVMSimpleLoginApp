using MVVMSimpleLoginApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MVVMSimpleLoginApp.ViewModels
{
    class LoginPageViewModel : INotifyPropertyChanged
    {

        #region Propriedades

        private string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public LoginPageViewModel()
        {
            LoginCommand = new Command(LoginExecute);
            RegisterCommand = new Command(RegisterExecute);
        }


        public bool CheckPropiedades()
        {

            if(UserName != null && Password != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public async void LoginExecute()
        {
            LoginService service = new LoginService();
            if(await service.Login(Password, UserName))
            {
                await App.Current.MainPage.DisplayAlert("LOGADO COM SUCESSO", "sua conta foi logada com sucesso", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "algo deu errado", "Ok");
            }
        }

        public void RegisterExecute()
        {
            LoginService service = new LoginService();
            service.Register(Password, UserName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}

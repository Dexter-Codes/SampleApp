using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Sample.Core.ViewModels
{
    public class LoginViewModel:MvxViewModel
    {
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public IMvxCommand LoginCommand { get; set; }
       
        
        public LoginViewModel()
        {
            LoginCommand=new MvxAsyncCommand(OnLoginCommand);
        }

        private async Task OnLoginCommand()
        {
            var validator=CheckValidation();
            if (validator)
            {
                var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
                await navigationService.Navigate<ClientViewModel>();
            }
        }

        private bool CheckValidation()
        {
            if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password))
                return true;
            else
                return false;
        }

    }
}

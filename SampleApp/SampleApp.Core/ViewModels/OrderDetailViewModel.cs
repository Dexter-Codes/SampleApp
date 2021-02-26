using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Sample.Core.Models;

namespace Sample.Core.ViewModels
{
    public class OrderDetailViewModel: MvxViewModel<ClientListModel>
    {
        private string _status;
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private string _orderNum;
        public string OrderNum
        {
            get => _orderNum;
            set => SetProperty(ref _orderNum, value);
        }

        private string _clientName;
        public string ClientName
        {
            get => _clientName;
            set => SetProperty(ref _clientName, value);
        }

        private string _propertyName;
        public string PropertyName
        {
            get => _propertyName;
            set => SetProperty(ref _propertyName, value);
        }

        private string _address;
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private string _note;
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        private string _btn1;
        public string Btn1
        {
            get => _btn1;
            set => SetProperty(ref _btn1, value);
        }

        private string _btn2;
        public string Btn2
        {
            get => _btn2;
            set => SetProperty(ref _btn2, value);
        }

        private string _statusIcon;
        public string StatusIcon
        {
            get => _statusIcon;
            set => SetProperty(ref _statusIcon, value);
        }

        public IMvxCommand BackCommand { get; set; }
        

        public OrderDetailViewModel()
        {
            BackCommand = new MvxAsyncCommand(OnBackClick);
        }

        private async Task OnBackClick()
        {
            var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            await navigationService.Close(this);
        }

        public override void Prepare(ClientListModel parameter)
        {
            Status = parameter.Status;
            OrderNum = parameter.ClientNumber.ToString();
            ClientName = parameter.ClientName;
            PropertyName = parameter.PropertyNumber;
            Address = parameter.Address;
            Note = parameter.Note;
            Btn1 = parameter.BtnPrev;
            Btn2 = parameter.BtnNext;
            StatusIcon = Status == "Complete" ? "checkmark" : "error";
        }
    }
}

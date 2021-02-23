using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Sample.Core.Models;

namespace Sample.Core.ViewModels
{
    public class ClientViewModel:MvxViewModel
    {
        private ObservableCollection<ClientListModel> _clientList = new ObservableCollection<ClientListModel>();
        public ObservableCollection<ClientListModel> ClientList
        {
            get => _clientList;
            set => SetProperty(ref _clientList, value);
        }

        public IMvxCommand<ClientListModel> ClickCommand { get; private set; }

        public ClientViewModel()
        {
            SetData();
            ClickCommand = new MvxAsyncCommand<ClientListModel>(OrderItemSelected);
        }

        private async Task OrderItemSelected(ClientListModel arg)
        {
            var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            await navigationService.Navigate<OrderListViewModel, ClientListModel, DestructionResult<ClientListModel>>(arg);
        }

        void SetData()
        {
            for(int i=0;i<5;i++)
            {
                ClientList.Add(new ClientListModel {ClientNumber=i+5,ClientName="Client Name"+i.ToString() });
            }
        }
    }
}

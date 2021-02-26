using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Sample.Core.Models;

namespace Sample.Core.ViewModels
{
    public class ClientViewModel:MvxViewModel
    {
        private List<ClientListModel> _clientList = new List<ClientListModel>();
        public List<ClientListModel> ClientList
        {
            get => _clientList;
            set => SetProperty(ref _clientList, value);
        }

        private List<ClientListModel> tempList = new List<ClientListModel>();

        private string _searchText;
        public string searchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public IMvxCommand<ClientListModel> ClickCommand { get;  set; }

        public IMvxCommand SearchCommand { get; set; }

        public ClientViewModel()
        {
            SetData();
            ClickCommand = new MvxAsyncCommand<ClientListModel>(OrderItemSelected);
            SearchCommand = new MvxCommand(OnSearchClick);
        }

        private void OnSearchClick()
        {
            if(!string.IsNullOrEmpty(searchText) && searchText.Length > 4)
            {
                var filtered = tempList.Where(p => p.ClientName != null &&
                                                    p.ClientName.ToLower().Contains(searchText.ToLower()) );

                ClientList = filtered.ToList();
            }
            else if(string.IsNullOrEmpty(searchText))
            {
                ClientList = tempList;
            }
        }

        private async Task OrderItemSelected(ClientListModel arg)
        {
            var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            await navigationService.Navigate<OrderListViewModel, ClientListModel>(arg);
        }

        void SetData()
        {
            for(int i=0;i<5;i++)
            {
                tempList.Add(new ClientListModel {ClientNumber=i+5,ClientName="Client Name"+i.ToString() });
            }
            ClientList = tempList;
        }
    }
}

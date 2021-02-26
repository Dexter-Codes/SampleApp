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
    public class OrderListViewModel: MvxViewModel<ClientListModel>
    {
        private List<ClientListModel> _clientOrderList = new List<ClientListModel>();
        public List<ClientListModel> ClientOrderList
        {
            get => _clientOrderList;
            set => SetProperty(ref _clientOrderList, value);
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

        public IMvxCommand BackCommand { get; set; }

        public OrderListViewModel()
        {
            ClickCommand = new MvxAsyncCommand<ClientListModel>(OrderItemSelected);
            BackCommand = new MvxAsyncCommand(OnBackClick);
            SearchCommand = new MvxCommand(OnSearchClick);
        }

        private async Task OrderItemSelected(ClientListModel arg)
        {
            var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            await navigationService.Navigate<OrderDetailViewModel, ClientListModel>(arg);
        }

        private async Task OnBackClick()
        {
            var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            await navigationService.Close(this);
        }

        private void OnSearchClick()
        {
            if (!string.IsNullOrEmpty(searchText) && searchText.Length > 4)
            {
                searchText.ToLower();
                var filtered = tempList.Where(p => p.ClientName != null && p.ClientName.ToLower().Contains(searchText)
                || p.Address != null && p.Address.ToLower().Contains(searchText) || p.Status.ToLower().Contains(searchText) || p.Date.ToLower().Contains(searchText)
                ||p.PropertyNumber.ToLower().Contains(searchText));

                ClientOrderList = filtered.ToList();
            }
            else if (string.IsNullOrEmpty(searchText))
            {
                ClientOrderList = tempList;
            }
        }

        public void SetData(int total,string clientName)
        {
            for (int i = 0; i < total; i++)
            {
                tempList.Add(new ClientListModel
                {
                    ClientNumber = 12953 + i,
                    PropertyNumber = "667"+i,
                    ClientName = clientName,
                    Date = "20/11/201" + i.ToString(),
                    PropertyId = "PropertyId-13",
                    Status = i%2==0?"Complete":"Pending",
                    Address="JacksonVille newark"+i.ToString(),
                    Note="Important text",
                    BtnNext="Before Images",
                    BtnPrev="After Images",
                    StatusIcon=i%2==0?"checkmark":"error"
                });
            }
            ClientOrderList = tempList;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public override void Prepare(ClientListModel parameter)
        {
            var total=parameter.ClientNumber;
            var clientName = parameter.ClientName;
            SetData(total,clientName);
        }
    }
}

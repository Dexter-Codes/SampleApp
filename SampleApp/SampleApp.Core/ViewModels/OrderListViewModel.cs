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
    public class OrderListViewModel:MvxViewModel
    {
        private ObservableCollection<ClientListModel> _onListClient = new ObservableCollection<ClientListModel>();
        public ObservableCollection<ClientListModel> OnListClient
        {
            get => _onListClient;
            set => SetProperty(ref _onListClient, value);
        }
        public IMvxCommand<ClientListModel> ClickCommand { get; private set; }
        public OrderListViewModel()
        {
            SetData();
            ClickCommand = new MvxAsyncCommand<ClientListModel>(OrderItemSelected);
        }

        private async Task OrderItemSelected(ClientListModel arg)
        {
            var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            await navigationService.Navigate<OrderDetailViewModel, ClientListModel, DestructionResult<ClientListModel>>(arg);
        }

        public void SetData()
        {
            for (int i = 0; i < 5; i++)
            {
                OnListClient.Add(new ClientListModel
                {
                    ClientNumber = 123 + i,
                    PropertyNumber = "XAEji-" + i.ToString(),
                    ClientName = "Sri Pada" + i.ToString(),
                    Date = "20/11/201" + i.ToString(),
                    PropertyId = "Lost2244" + i,
                    Status = "Completed",
                    Address="JacksonVille newark"+i.ToString(),
                    Note="Important text",
                    BtnNext="Before Images",
                    BtnPrev="After Images"
                });
            }
        }
        public override Task Initialize()
        {
            return base.Initialize();
        }
    }
}

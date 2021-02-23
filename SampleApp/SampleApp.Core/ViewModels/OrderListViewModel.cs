using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Sample.Core.Models;

namespace Sample.Core.ViewModels
{
    public class OrderListViewModel: BaseViewModel<ClientListModel, DestructionResult<ClientListModel>>
    {
        private ObservableCollection<ClientListModel> _onListClient = new ObservableCollection<ClientListModel>();
        public ObservableCollection<ClientListModel> OnListClient
        {
            get => _onListClient;
            set => SetProperty(ref _onListClient, value);
        }

        public IMvxCommand<ClientListModel> ClickCommand { get; private set; }

        private ICommand _backCommand;
        public ICommand BackCommand { get; set; }

        public OrderListViewModel()
        {
            ClickCommand = new MvxAsyncCommand<ClientListModel>(OrderItemSelected);
            BackCommand = new MvxAsyncCommand(OnBackClick);
        }

        private async Task OrderItemSelected(ClientListModel arg)
        {
            var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            await navigationService.Navigate<OrderDetailViewModel, ClientListModel, DestructionResult<ClientListModel>>(arg);
        }

        private async Task OnBackClick()
        {
            var navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            await navigationService.Close(this);
        }

        public void SetData(int total,string clientName)
        {
            for (int i = 0; i < total; i++)
            {
                OnListClient.Add(new ClientListModel
                {
                    ClientNumber = 123 + i,
                    PropertyNumber = clientName,
                    ClientName = "Sri Pada" + i.ToString(),
                    Date = "20/11/201" + i.ToString(),
                    PropertyId = "Lost2244" + i,
                    Status = "Complete",
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

        public override void Prepare(ClientListModel parameter)
        {
            var total=parameter.ClientNumber;
            var clientName = parameter.ClientName;
            SetData(total,clientName);
        }
    }
}

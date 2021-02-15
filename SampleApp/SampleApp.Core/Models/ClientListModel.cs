using System;
using MvvmCross.ViewModels;

namespace Sample.Core.Models
{
    public class ClientListModel : MvxNotifyPropertyChanged
    {
        private int _clientNumber;
        public int ClientNumber
        {
            get => _clientNumber;
            set => SetProperty(ref _clientNumber, value);
        }
        private string _status;
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }
        private string _clientName;
        public string ClientName
        {
            get => _clientName;
            set => SetProperty(ref _clientName, value);
        }
        private string _date;
        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
        private string _propertyId;
        public string PropertyId
        {
            get => _propertyId;
            set => SetProperty(ref _propertyId, value);
        }
        private string _propertyNumber;
        public string PropertyNumber
        {
            get => _propertyNumber;
            set => SetProperty(ref _propertyNumber, value);
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
        private string _btnPrev;
        public string BtnPrev
        {
            get => _btnPrev;
            set => SetProperty(ref _btnPrev, value);
        }
        private string _btnNext;
        public string BtnNext
        {
            get => _btnNext;
            set => SetProperty(ref _btnNext, value);
        }
        public ClientListModel()
        {
        }
    }
}

//using MvvmCross.ViewModels;

using System.Threading.Tasks;
using MvvmCross.ViewModels;
using Sample.Core.Services;

namespace Sample.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private readonly ICalculationService _calculationService;

        public FirstViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            TheText = "Hello World";
            _makeItVisible = false;
            _theValue = 3;
            SubTotal = 100;
            Generosity = 10;
            _firstName = "Xavier";
            _lastName = "pande";
            Recalcuate();
        }
        private string _firstName;
        private string _lastName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                RaisePropertyChanged(() => FirstName);
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                RaisePropertyChanged(() => LastName);
            }
        }
        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);

                Recalcuate();
            }
        }
        private bool _checkDraw;
        public bool CheckDraw
        {
            get => _checkDraw;
            set
            {
                _checkDraw = value;
                RaisePropertyChanged(() => CheckDraw);

            }
        }
        private int _generosity;
        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);

                Recalcuate();
            }
        }

        private double _tip;
        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private bool _makeItVisible;
      
        public bool MakeItVisible
        {
            get { return _makeItVisible; }
            set
            {
                _makeItVisible = value;
                RaisePropertyChanged(() => MakeItVisible);
            }
        }
        private string _theText;

      

        public string TheText
        {
            get { return _theText; }
            set
            {
                _theText = value;
                RaisePropertyChanged(() => TheText);
            }
        }
        private double _theValue;

        public double TheValue
        {
            get { return _theValue; }
            set
            {
                _theValue = value;
                RaisePropertyChanged(() => TheValue);
            }
        }


        private void Recalcuate()
        {
            // Tip = SubTotal * Generosity / 100.0;
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }
    }
}

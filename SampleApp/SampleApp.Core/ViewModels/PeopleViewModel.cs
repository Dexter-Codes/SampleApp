using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Sample.Core.Interfaces;
using Sample.Core.Models;

namespace Sample.Core.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        private readonly IPeopleService _peopleService;
        private readonly IMvxNavigationService _navigationService;

        private string _nextPage;

        public PeopleViewModel(
            IPeopleService peopleService,
            IMvxNavigationService navigationService)
        {
            _peopleService = peopleService;
            _navigationService = navigationService;

            People = new MvxObservableCollection<Person>();

            PersonSelectedCommand = new MvxAsyncCommand<Person>(PersonSelected);
            FetchPeopleCommand = new MvxCommand(
                () =>
                {
                    if (!string.IsNullOrEmpty(_nextPage))
                    {
                        FetchPeopleTask = MvxNotifyTask.Create(LoadPeople);
                        RaisePropertyChanged(() => FetchPeopleTask);
                    }
                });
            RefreshPeopleCommand = new MvxCommand(RefreshPeople);
        }

        // MvvmCross Lifecycle
        public override Task Initialize()
        {
            LoadPeopleTask = MvxNotifyTask.Create(LoadPeople);

            return base.Initialize();
        }

        // MVVM Properties
        public MvxNotifyTask LoadPeopleTask { get; private set; }

        public MvxNotifyTask FetchPeopleTask { get; private set; }

        private MvxObservableCollection<Person> _people;
        public MvxObservableCollection<Person> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                RaisePropertyChanged(() => People);
            }
        }

        // MVVM Commands
        public IMvxCommand<Person> PersonSelectedCommand { get; private set; }

        public IMvxCommand FetchPeopleCommand { get; private set; }

        public IMvxCommand RefreshPeopleCommand { get; private set; }

        // Private methods
        private async Task LoadPeople()
        {
            //  var result = await _peopleService.GetMockedPeople();
            var result = new List<Person>
                {
                    new Person
                    {
                        Name = "Master Yoda",
                        SkinColor = "Green",
                        Height = "65"
                    },
                    new Person
                    {
                        Name = "Obi-Wan Kenobi",
                        Mass = "80"
                    },
                    new Person
                    {
                        Name = "Master Windu",
                        Height = "165",
                        Mass = "85"
                    }
                };

            if (string.IsNullOrEmpty(_nextPage))
            {
                People.Clear();
                People.AddRange(result.Where(p => !p.Name.Contains("Vader") && !p.Name.Contains("Anakin")));
            }
            else
            {
                People.AddRange(result.Where(p => !p.Name.Contains("Vader") && !p.Name.Contains("Anakin")));
            }

            //_nextPage = result.Next;
        }

        private async Task PersonSelected(Person selectedPerson)
        {
            await _navigationService.Navigate<FirstViewModel>();
            //var result = await _navigationService.Navigate<PersonViewModel, Person, DestructionResult<Person>>(selectedPerson);

            //if (result != null && result.Destroyed)
            //{
            //    var person = People.FirstOrDefault(p => p.Name == result.Entity.Name);
            //    if (person != null)
            //        People.Remove(person);
            //}
        }

        private void RefreshPeople()
        {
            _nextPage = null;

            LoadPeopleTask = MvxNotifyTask.Create(LoadPeople);
            RaisePropertyChanged(() => LoadPeopleTask);
        }
    }
}

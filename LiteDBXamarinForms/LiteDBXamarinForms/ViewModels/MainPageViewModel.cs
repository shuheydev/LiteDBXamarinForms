using LiteDBXamarinForms.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LiteDBXamarinForms.Models;
using LiteDBXamarinForms.Repositories;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LiteDBXamarinForms.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigatedAware
    {
        private string _title = "Hello Xamarin.Forms!";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _firstName="test";
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName="test2";
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private int _age=1;
        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get => _people;
            set => SetProperty(ref _people, value);
        }

        public DelegateCommand AddCommand => new DelegateCommand(
                async () =>
                {
                    var person = new Person
                    {
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        Age = this.Age,
                    };

                    try
                    {
                        var result = await _peopleRepository.AddAsync(person);
                        this.People.Add(result);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                },
                () =>
                {
                    return !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName) && this.Age != null;
                }
            )
            .ObservesProperty(() => this.FirstName)
            .ObservesProperty(() => this.LastName)
            .ObservesProperty(() => this.Age);

        private readonly INavigationService _navigationService;
        private readonly IPeopleRepository _peopleRepository;

        public MainPageViewModel(INavigationService navigationService,IPeopleRepository peopleRepository)
        {
            _navigationService = navigationService;
            _peopleRepository = peopleRepository;
        }

        public async void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            this.People = new ObservableCollection<Person>(await _peopleRepository.ReadAll());
        }
    }
}

using LiteDBXamarinForms.Repositories;
using LiteDBXamarinForms.ViewModels;
using LiteDBXamarinForms.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiteDBXamarinForms
{
    public partial class App
    {
        public App(IPlatformInitializer initializer=null):base(initializer)
        {
            InitializeComponent();

            NavigationService.NavigateAsync(nameof(MainPage));
        }

        protected override void OnInitialized()
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}

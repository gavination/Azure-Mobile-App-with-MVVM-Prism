using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismMobileServicesClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PrismMobileServicesClient.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public static MobileServiceClient MobileService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _buttonTitle = "Get Table";
        public string ButtonTitle
        {
            get { return _buttonTitle; }
            set { SetProperty(ref _buttonTitle, value); }
        }

        public MainPageViewModel()
        {

            MobileService = new MobileServiceClient("https://gavinapp.azurewebsites.net");
            GetTableCommand = new DelegateCommand(GetTable);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        public DelegateCommand GetTableCommand { get; set; }

        private void GetTable()
        {
             IMobileServiceTable<TodoItem> todoTable = MobileService.GetTable<TodoItem>();
        }
    }
}

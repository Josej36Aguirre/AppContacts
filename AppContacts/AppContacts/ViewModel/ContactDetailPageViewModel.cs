﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppContacts.Model;
using Xamarin.Forms;

namespace AppContacts.ViewModel
{
   public class ContactDetailPageViewModel
    {
       
        public Command SaveContactCommand { get; set; }
        public Command DeleteContactCommand { get; set; }
        public INavigation Navigation { get; set; }

        public ContactDetailPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            CurrenContact = new Contact();
            SaveContactCommand = new Command(async () => await SaveContact());
            DeleteContactCommand = new Command(async () => await DeleteContact());

        }

        private async Task SaveContact()
        {
            await App.DataBase.SaveItemAsync(CurrenContact);
            await Navigation.PopToRootAsync();
        }

        private async Task DeleteContact()
        {
            await App.DataBase.DeleteItemAsync(CurrenContact);
            await Navigation.PopToRootAsync();
        }
 

}
}

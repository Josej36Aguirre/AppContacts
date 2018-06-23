using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppContacts.View;
using AppContacts.Model;
using AppContacts.Helper;

namespace AppContacts.ViewModel
{
   public class ContactsPageViewModel
    {
        public ObservableCollection<Grouping<string, Contact>> ContactsLists { get; set; }
        public Command AddContactCommand { get; set; }
        public INavigation Navigation { get; set; }
        public Contact CurrenContact { get; set; }
        public Command ItemTappedCommand { get; }
        //ItemTappedCommand = new Command(async () => GotoContactDetailPageViewModel(CurrenContact));
    

        public ContactsPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Task.Run(async () => ContactsLists = await App
                                .DataBase.GetAllGrouped()).Wait();
            AddContactCommand = new Command(async () => await GoToDetailContactAsync(CurrenContact)

                );

        }

        private async Task GoToDetailContactAsync(Contact contact = null)
        {
            if (contact == null)
            {
                await Navigation.PushAsync(new View.ContactDetailPage());
            }
            else
            {
                await Navigation.PushAsync(new ContactDetailPage(CurrenContact));
            }
        }

    }
}

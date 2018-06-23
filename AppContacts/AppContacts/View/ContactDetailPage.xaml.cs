using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppContacts.ViewModel;
using AppContacts.Model;

namespace AppContacts.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailPageViewModel : ContentPage
	{
        private INavigation navigation;

        public ContactDetailPageViewModel ViewModel { get; set; }

        public ContactDetailPageViewModel (Contact currenContact)
		{
			InitializeComponent ();
            ViewModel = new ContactDetailPageViewModel(Navigation);
            this.BindingContext = ViewModel;

        }

        public ContactDetailPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AppContacts.Data;
using AppContacts.Services;

using Xamarin.Forms;

namespace AppContacts
{
	public partial class App : Application
	{
        private static ContactsDatabase dataBase;

        public static ContactsDatabase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    try
                    {
                        dataBase = new ContactsDatabase(DependencyService.Get<IFileHelper>()
                                       .GetLocalFilePath("contacts.db3"));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                return dataBase;
            }
        }

        public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new View.ContactsPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

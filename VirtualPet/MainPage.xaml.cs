using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VirtualPet
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void ButtonPlay(System.Object sender, System.EventArgs e) {
            var modalPage = new PetPage();

            modalPage.Disappearing += (sender2, e2) => {
                Console.WriteLine("The modal page is dismissed, do something now");
            };

            await Navigation.PushModalAsync(modalPage);
            Console.WriteLine("The modal page is now on screen, hit back button");
        }

        async void ButtonSettings(System.Object sender, System.EventArgs e) {
            var modalPage = new SettingsPage();

            modalPage.Disappearing += (sender2, e2) => {
                Console.WriteLine("The modal page is dismissed, do something now");
            };

            await Navigation.PushModalAsync(modalPage);
            Console.WriteLine("The modal page is now on screen, hit back button");
        }
    }
}

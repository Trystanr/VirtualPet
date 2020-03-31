using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VirtualPet
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // To the "game" screen
        async void ButtonPlay(System.Object sender, System.EventArgs e) {
            var modalPage = new PetPage();
            await Navigation.PushModalAsync(modalPage);
        }

        // To the "settings" screen
        async void ButtonSettings(System.Object sender, System.EventArgs e) {
            var modalPage = new SettingsPage();
            await Navigation.PushModalAsync(modalPage);
        }
    }
}

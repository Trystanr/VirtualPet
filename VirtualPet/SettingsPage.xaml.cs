using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VirtualPet {
    public partial class SettingsPage : ContentPage {
        public SettingsPage() {
            InitializeComponent();
        }

        async void SettingsQuit(System.Object sender, System.EventArgs e) {

            await Navigation.PopModalAsync();

        }
    }
}

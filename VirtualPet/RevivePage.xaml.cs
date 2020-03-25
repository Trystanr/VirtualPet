using System;
using System.Collections.Generic;

using Xamarin.Forms;

using VirtualPet.Objects;

namespace VirtualPet {
    public partial class RevivePage : ContentPage {
        private VPet pet = new VPet();

        public RevivePage() {
            InitializeComponent();

            if (pet.Hunger == 0) {
                labelCOD.Text = "He died of hunger.";
            } else if (pet.Thirst == 0) {
                labelCOD.Text = "He died of thirst.";
            } else if (pet.Cure == 0) {
                labelCOD.Text = "He died of disease.";
            }
        }

        async void RevivePet(System.Object sender, System.EventArgs e) {
            pet.Revive();
            await Navigation.PopModalAsync();
        }
    }
}

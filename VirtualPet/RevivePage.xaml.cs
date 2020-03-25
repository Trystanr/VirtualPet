using System;
using System.Collections.Generic;

using Xamarin.Forms;

using VirtualPet.Objects;

namespace VirtualPet {
    public partial class RevivePage : ContentPage {
        private VPet pet = new VPet();

        public RevivePage() {
            InitializeComponent();

            deathName.Text = pet.PetName + " has died.";

            if (pet.Hunger == 0) {
                labelCOD.Text = "He died of hunger.";
                speechImage.Source = "Speech_Food";
            } else if (pet.Thirst == 0) {
                labelCOD.Text = "He died of thirst.";
                speechImage.Source = "Speech_Water";
            } else if (pet.Cure == 0) {
                labelCOD.Text = "He died of disease.";
                speechImage.Source = "Speech_Virus";
            }


        }

        async void RevivePet(System.Object sender, System.EventArgs e) {

            if (nameEntry.Text != "") {

                string newPetName = nameEntry.Text;
                pet.PetName = newPetName;

                pet.Revive();
                await Navigation.PopModalAsync();
            } else {
                labelErr.Text = "Please enter a name for your new patient.";
            }
            
        }
    }
}

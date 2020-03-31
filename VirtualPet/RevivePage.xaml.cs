using System;
using System.Collections.Generic;

using Xamarin.Forms;

using VirtualPet.Objects;

namespace VirtualPet {
    public partial class RevivePage : ContentPage {
        private VPet pet = new VPet();

        public RevivePage() {
            InitializeComponent();

            // Sets the skin and name to the selected skin and name
            charImage.Source = "Character_" + pet.PetSkin + "_Dead";
            deathName.Text = pet.PetName + " has died.";

            // Feedback on how the pet died
            if (pet.Hunger == 0) {
                labelCOD.Text = "They died of hunger.";
                speechImage.Source = "Speech_Food";
            } else if (pet.Thirst == 0) {
                labelCOD.Text = "They died of thirst.";
                speechImage.Source = "Speech_Water";
            } else if (pet.Cure == 0) {
                labelCOD.Text = "They died of disease.";
                speechImage.Source = "Speech_Virus";
            }


        }

        // Pops the modal and revives the pet to default values
        async void RevivePet(System.Object sender, System.EventArgs e) {

            if (nameEntry.Text != "") {

                // Set the new pet name
                string newPetName = nameEntry.Text;
                pet.PetName = newPetName;

                pet.Revive();
                await Navigation.PopModalAsync();
            } else {
                // If the user did not enter a new name
                labelErr.Text = "Please enter a name for your new patient.";
            }
            
        }
    }
}

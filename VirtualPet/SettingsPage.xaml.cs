using System;
using System.Collections.Generic;

using VirtualPet.Objects;

using Xamarin.Forms;

namespace VirtualPet {
    public partial class SettingsPage : ContentPage {
        private VPet pet = new VPet();

        public SettingsPage() {
            InitializeComponent();

            // Set the entry to the current pet name
            nameEntry.Text = pet.PetName;
            SetCarouselIndex();
        }

        async void SettingsQuit(System.Object sender, System.EventArgs e) {

            // Ensure the user enters a name for the pet
            if (nameEntry.Text != "") {
                string newPetName = nameEntry.Text;

                pet.PetName = newPetName;

                // Set the skins of the pets to the selected index of the carousel
                if (carSelect.Position == 0) {
                    pet.PetSkin = "Man";
                } else if (carSelect.Position == 1) {
                    pet.PetSkin = "Woman";
                } else if (carSelect.Position == 2) {
                    pet.PetSkin = "Crash";
                }

                await Navigation.PopModalAsync();
            }

        }

        void CarouselItemChanged(System.Object sender, Xamarin.Forms.CurrentItemChangedEventArgs e) {
            // Controls the selection buttons to give feedback on if they are interactable
            if (carSelect.Position == 0) {
                ButtonPrev.Opacity = 0.5;
                ButtonNext.Opacity = 1;
            } else if (carSelect.Position == (carSource.Length - 1)) {
                ButtonNext.Opacity = 0.5;
                ButtonPrev.Opacity = 1;
            } else {
                ButtonPrev.Opacity = 1;
                ButtonNext.Opacity = 1;
            }
        }


        private void SetCarouselIndex() {

            //Xamarin forms carousel does not set index on constructor, so I implemented this workaround hack
            //Starts a timer of 100 miliseconds, but only runs it once

            // This int is the index value the carousel should default to depending on the selected skin
            int characterSkin = 0;

            if (pet.PetSkin == "Man") {
                characterSkin = 0;
            } else if (pet.PetSkin == "Woman") {
                characterSkin = 1;
            } else if (pet.PetSkin == "Crash") {
                characterSkin = 2;
            }

            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                carSelect.ScrollTo(characterSkin, animate: false);

                return false;
            });
        }

        // Moves the carousel to the previous position and updates the button interaction handlers
        void ButtonPrevClicked(System.Object sender, System.EventArgs e) {
            if (carSelect.Position == 0) {

            } else if ((carSelect.Position - 1) == 0) {
                carSelect.ScrollTo(0);
                ButtonPrev.Opacity = 0.5;
                ButtonNext.Opacity = 1;
            } else {
                carSelect.ScrollTo(carSelect.Position - 1);
                ButtonPrev.Opacity = 1;
                ButtonNext.Opacity = 1;
            }
        }

        // Moves the carousel to the next position and updates the button interaction handlers
        void ButtonNextClicked(System.Object sender, System.EventArgs e) {
            Console.WriteLine(carSource.Length);
            if (carSelect.Position == (carSource.Length-1)) {

            } else if ((carSelect.Position + 1) == (carSource.Length - 1)) {
                carSelect.ScrollTo((carSource.Length - 1));
                ButtonNext.Opacity = 0.5;
                ButtonPrev.Opacity = 1;
            } else {
                carSelect.ScrollTo(carSelect.Position + 1);
                ButtonNext.Opacity = 1;
                ButtonPrev.Opacity = 1;
            }
        }
    }
}

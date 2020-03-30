using System;
using System.Collections.Generic;

using VirtualPet.Objects;

using Xamarin.Forms;

namespace VirtualPet {
    public partial class SettingsPage : ContentPage {
        private VPet pet = new VPet();

        public SettingsPage() {
            InitializeComponent();

            nameEntry.Text = pet.PetName;
            SetCarouselIndex();
        }

        async void SettingsQuit(System.Object sender, System.EventArgs e) {

            if (nameEntry.Text != "") {
                string newPetName = nameEntry.Text;

                pet.PetName = newPetName;

                if (carSelect.Position == 0) {
                    pet.PetSkin = "Man";
                } else if (carSelect.Position == 1) {
                    pet.PetSkin = "Woman";
                }

                await Navigation.PopModalAsync();
            }

        }

        void CarouselItemChanged(System.Object sender, Xamarin.Forms.CurrentItemChangedEventArgs e) {
            Console.WriteLine("Item changed");
            Console.WriteLine(carSelect.Position);
        }


        private void SetCarouselIndex() {

            //Xamarin forms carousel does not set index on constructor, so I implemented this workaround hack
            //Starts a timer of 100 miliseconds, but only runs it once

            int characterSkin = 0;

            if (pet.PetSkin == "Man") {
                characterSkin = 0;
            } else if (pet.PetSkin == "Woman") {
                characterSkin = 1;
            }

            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                carSelect.ScrollTo(characterSkin, animate: false);

                return false;
            });
        }

    }
}

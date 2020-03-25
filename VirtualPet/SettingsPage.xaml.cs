﻿using System;
using System.Collections.Generic;

using VirtualPet.Objects;

using Xamarin.Forms;

namespace VirtualPet {
    public partial class SettingsPage : ContentPage {
        private VPet pet = new VPet();

        public SettingsPage() {
            InitializeComponent();

            nameEntry.Text = pet.PetName;
        }

        async void SettingsQuit(System.Object sender, System.EventArgs e) {

            if (nameEntry.Text != "") {
                string newPetName = nameEntry.Text;

                pet.PetName = newPetName;

                await Navigation.PopModalAsync();
            }
            

        }
    }
}

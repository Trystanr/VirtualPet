using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using VirtualPet.Objects;

using Xamarin.Forms;

namespace VirtualPet {
    public partial class PetPage : ContentPage {

        private VPet pet = new VPet();

        private bool isTimed = false;

        public PetPage() {
            InitializeComponent();
            updateUI();

            StartTimer();

            
        }

        void updateUI() {

            hungerProgress(Convert.ToDouble((pet.Hunger))/100);

            if (pet.Hunger != 300) {
                hungerLabel.Text = Convert.ToString(pet.Hunger);
                hungerStateLabel.Text = PetHungerStates.GetPetHungerState(PetHungerStates.GetStateFromHunger(pet.Hunger));
            }
        }

        async void MainQuit(System.Object sender, System.EventArgs e) {
            isTimed = false;

            await Navigation.PopModalAsync();
        }

        void FeedPet(System.Object sender, System.EventArgs e) {
            //ResetTimer();

            pet.Feed();

            updateUI();
        }

        private void StartTimer() {
            
            isTimed = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                pet.Starve();
                updateUI();

                // return true to repeat counting, false to stop timer
                if (isTimed) {
                    return true;
                } else {
                    return false;
                }
                 
            });
        }

        async private void hungerProgress(double i) {
            await hungerProgressBar.ProgressTo(i, 100, Easing.Linear);
        }


    }
}

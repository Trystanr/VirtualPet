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
            if (pet.Hunger == 0 || pet.Thirst == 0 || pet.Cure == 0) {

                pet.Die();

                hungerStateLabel.Text = "RIP";
                thirstStateLabel.Text = "RIP";
                cureStateLabel.Text = "RIP";

                petNameLabel.Text = "Dead " + pet.PetName;

                //hungerProgress(0);
                //thirstProgress(0);
                //cureProgress(0);

                speechImage.Source = "Speech-Skull";
            } else {

                hungerProgress(Convert.ToDouble((pet.Hunger))/100);
                thirstProgress(Convert.ToDouble((pet.Thirst)) / 100);
                cureProgress(Convert.ToDouble((pet.Cure)) / 100);

                if (pet.Hunger != 300) {
                    //hungerLabel.Text = Convert.ToString(pet.Hunger);
                    hungerStateLabel.Text = PetHungerStates.GetPetHungerState(PetHungerStates.GetStateFromHunger(pet.Hunger));
                }

            

                if (pet.Thirst != 300) {
                    //thirstLabel.Text = Convert.ToString(pet.Thirst);
                    thirstStateLabel.Text = PetThirstStates.GetPetThirstState(PetThirstStates.GetStateFromThirst(pet.Thirst));
                }

            

                if (pet.Cure != 300) {
                    //thirstLabel.Text = Convert.ToString(pet.Thirst);
                    cureStateLabel.Text = PetCureStates.GetPetCureState(PetCureStates.GetStateFromCure(pet.Cure));
                }

                if (pet.Hunger < 40 && pet.Thirst < 40 && pet.Cure < 40) {
                    speechImage.Source = "Speech-Food-Water-Virus";
                }
                else if (pet.Hunger < 40 && pet.Thirst < 40) {
                    speechImage.Source = "Speech-Food-Water";
                }
                else if (pet.Hunger < 40 && pet.Cure < 40) {
                    speechImage.Source = "Speech-Food-Virus";
                }
                else if (pet.Thirst < 40 && pet.Cure < 40) {
                    speechImage.Source = "Speech-Water-Virus";
                }
                else if (pet.Hunger < 40) {
                    speechImage.Source = "Speech-Food";
                }
                else if (pet.Thirst < 40) {
                    speechImage.Source = "Speech-Water";
                }
                else if (pet.Cure < 40) {
                    speechImage.Source = "Speech-Virus";
                } else {
                    speechImage.Source = "Speech-Dots";
                }

            

                if (pet.PetName == "") {
                    petNameLabel.Text = "Jeffrey";
                } else {
                    petNameLabel.Text = pet.PetName;
                }

            }

        }

        async void MainQuit(System.Object sender, System.EventArgs e) {
            isTimed = false;

            await Navigation.PopModalAsync();
        }

        void FeedPet(System.Object sender, System.EventArgs e) {

            if (pet.isDead == false) {
                pet.Feed();

                updateUI();
            }
            
        }

        void DrinkPet(System.Object sender, System.EventArgs e) {

            if (pet.isDead == false) {

                pet.Drink();

                updateUI();
            }
        }

        void InjectPet(System.Object sender, System.EventArgs e) {
            //ResetTimer();

            if (pet.isDead == false) {

                pet.Inject();

                updateUI();
            }
        }

        async private void RevivePet() {
            var modalPage = new RevivePage();

            modalPage.Disappearing += (sender2, e2) => {
                Console.WriteLine("The modal page is dismissed, do something now");
                updateUI();

                StartTimer();
            };

            await Navigation.PushModalAsync(modalPage);
        }

        private void StartTimer() {
            
            isTimed = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
               
                Random generator = new Random();

                int randomumber = generator.Next(0, 10);

                if (randomumber < 2) {
                    pet.Cough();
                } else if (randomumber < 6) {
                    pet.Starve();
                } else if (randomumber < 8) {
                    pet.Dehydrate();
                } else {
                    pet.Starve();
                    pet.Dehydrate();
                }

                if (pet.isDead == false) {
                    updateUI();
                } else {
                    RevivePet();
                    isTimed = false;
                }

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

        async private void thirstProgress(double i) {
            await thirstProgressBar.ProgressTo(i, 100, Easing.Linear);
        }

        async private void cureProgress(double i) {
            await cureProgressBar.ProgressTo(i, 100, Easing.Linear);
        }


    }
}

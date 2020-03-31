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

        //Instantiate a virtual pet
        private VPet pet = new VPet();

        //Used to control timers
        private bool isTimed = false;

        public PetPage() {
            InitializeComponent();
            updateUI();

            StartTimer();

            //Set the character to the selected skin
            charImage.Source = "Character_" + pet.PetSkin;
        }
    
        void updateUI() {
            //Kill the pet if their hunger, thirst or cure values reach zero
            if (pet.Hunger == 0 || pet.Thirst == 0 || pet.Cure == 0) {

                pet.Die();

                hungerStateLabel.Text = "RIP";
                thirstStateLabel.Text = "RIP";
                cureStateLabel.Text = "RIP";

                petNameLabel.Text = "Dead " + pet.PetName;

                speechImage.Source = "Speech_Skull";
                charImage.Source = "Character_" + pet.PetSkin + "_Dead";

                speechPop();
            } else {

                //Progress Bars
                hungerProgress(Convert.ToDouble((pet.Hunger))/100);
                thirstProgress(Convert.ToDouble((pet.Thirst)) / 100);
                cureProgress(Convert.ToDouble((pet.Cure)) / 100);

                if (pet.Hunger != 300) {
                    //300 is used as a false value
                    hungerStateLabel.Text = PetHungerStates.GetPetHungerState(PetHungerStates.GetStateFromHunger(pet.Hunger));
                }

            

                if (pet.Thirst != 300) {
                    //300 is used as a false value
                    thirstStateLabel.Text = PetThirstStates.GetPetThirstState(PetThirstStates.GetStateFromThirst(pet.Thirst));
                }

            

                if (pet.Cure != 300) {
                    //300 is used as a false value
                    cureStateLabel.Text = PetCureStates.GetPetCureState(PetCureStates.GetStateFromCure(pet.Cure));
                }

                // Let the user know through image feedback if their pet has a need or multiple needs
                if (pet.Hunger < 40 && pet.Thirst < 40 && pet.Cure < 40) {
                    if ((speechImage.Source as FileImageSource).File != "Speech_Food_Water_Virus") {
                        speechImage.Source = "Speech_Food_Water_Virus";
                        speechPop();
                    } 
                }
                else if (pet.Hunger < 40 && pet.Thirst < 40) {
                    if ((speechImage.Source as FileImageSource).File != "Speech_Food_Water") {
                        speechImage.Source = "Speech_Food_Water";
                        speechPop();
                    }
                }
                else if (pet.Hunger < 40 && pet.Cure < 40) {
                    if ((speechImage.Source as FileImageSource).File != "Speech_Food_Virus") {
                        speechImage.Source = "Speech_Food_Virus";
                        speechPop();
                    }
                }
                else if (pet.Thirst < 40 && pet.Cure < 40) {
                    if ((speechImage.Source as FileImageSource).File != "Speech_Water_Virus") {
                        speechPop();
                        speechImage.Source = "Speech_Water_Virus";
                    }
                }
                else if (pet.Hunger < 40) {
                    if ((speechImage.Source as FileImageSource).File != "Speech_Food") {
                        speechPop();
                        speechImage.Source = "Speech_Food";
                    }
                }
                else if (pet.Thirst < 40) {
                    if ((speechImage.Source as FileImageSource).File != "Speech_Water") {
                        speechPop();
                        speechImage.Source = "Speech_Water";
                    }
                }
                else if (pet.Cure < 40) {
                    if ((speechImage.Source as FileImageSource).File != "Speech_Virus") {
                        speechPop();
                        speechImage.Source = "Speech_Virus";
                    }
                } else {
                    if ((speechImage.Source as FileImageSource).File != "Speech_Dots") {
                        speechPop();
                        speechImage.Source = "Speech_Dots";
                    }
                }

            
                // Set the name text
                if (pet.PetName == "") {
                    petNameLabel.Text = "Jeffrey";
                } else {
                    petNameLabel.Text = pet.PetName;
                }

            }

        }

        // An animation for when a need gets gained or removed
        async void speechPop() {
            await speechImage.ScaleTo(1.2, 100);
            await speechImage.ScaleTo(0.8, 100);
            await speechImage.ScaleTo(1, 100);
        }

        // Go back to the main menu
        async void MainQuit(System.Object sender, System.EventArgs e) {
            isTimed = false;

            await Navigation.PopModalAsync();
        }

        // Feed the pet
        void FeedPet(System.Object sender, System.EventArgs e) {

            // Disable feeding if the pet is dead
            if (pet.isDead == false) {
                pet.Feed();
                updateUI();
            }
            
        }

        // Give the pet water
        void DrinkPet(System.Object sender, System.EventArgs e) {

            // Disable drinking if the pet is dead
            if (pet.isDead == false) {
                pet.Drink();
                updateUI();
            }
        }

        // Inject the pet
        void InjectPet(System.Object sender, System.EventArgs e) {

            // Disable injecting if the pet is dead
            if (pet.isDead == false) {
                pet.Inject();
                updateUI();
            }
        }

        // A function that instantiates a modal and revives the pet when the modal is dismissed
        async private void RevivePet() {
            var modalPage = new RevivePage();

            modalPage.Disappearing += (sender2, e2) => {
                charImage.Source = "Character_" + pet.PetSkin;
                updateUI();
                StartTimer();
            };

            await Navigation.PushModalAsync(modalPage);
        }

        // Creates the timer
        private void StartTimer() {
            
            isTimed = true;

            // The timer is responsible for decreasing needs and updating the UI
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                // I wanted to add random numbers to add a bit of interest instead of decreasing all needs
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

        // Progress bar hunger
        async private void hungerProgress(double i) {
            await hungerProgressBar.ProgressTo(i, 100, Easing.Linear);
        }

        // Progress bar thirst
        async private void thirstProgress(double i) {
            await thirstProgressBar.ProgressTo(i, 100, Easing.Linear);
        }

        // Progress bar cure
        async private void cureProgress(double i) {
            await cureProgressBar.ProgressTo(i, 100, Easing.Linear);
        }


        // Testing buttons used to simulate the timer
        void ButtonHunger(System.Object sender, System.EventArgs e) {
            pet.Starve();
            updateUI();
        }

        void ButtonThirst(System.Object sender, System.EventArgs e) {
            pet.Dehydrate();
            updateUI();
        }

        void ButtonSick(System.Object sender, System.EventArgs e) {
            pet.Cough();
            updateUI();
        }

    }
}

﻿using System;

namespace VirtualPet.Objects {

    public class VPet {

        const string PetHungerStateKey = "PetHungerStateKey";
        const string PetHungerKey = "PetHunger";

        const string PetThirstStateKey = "PetThirstStateKey";
        const string PetThirstKey = "PetThirst";

        const string PetCureStateKey = "PetCureStateKey";
        const string PetCureKey = "PetCure";

        public PetHungerState CurrentHungerState {
            get {
                // Assign a key if it doesn't exist

                if (App.Current.Properties.ContainsKey(PetHungerStateKey)) {
                    return PetHungerStates.GetPetHungerState((string)App.Current.Properties[PetHungerStateKey]);
                } else {
                    return PetHungerState.full;
                }
            }

            set {
                App.Current.Properties[PetHungerStateKey] = PetHungerStates.GetPetHungerState(value);
            }
        }

        public int Hunger {
            get {
                if (App.Current.Properties.ContainsKey(PetHungerKey)) {
                    //Console.WriteLine((int)App.Current.Properties[PetHungerKey]);
                    return (int)App.Current.Properties[PetHungerKey];
                } else {
                    Console.WriteLine("No property found?");
                    return 0;
                }
            }

            set {
                App.Current.Properties[PetHungerKey] = value;
            }
        }

        public void Feed() {
            if (Hunger < 91) {
                Hunger += 10;
            } else {
                Hunger = 100;
            }
        }

        public void Starve() {
            if (Hunger > 0) {
                Hunger -= 1;
            } else {
                Hunger = 0;
            }
        }

        public PetThirstState CurrentThirstState {
            get {
                // Assign a key if it doesn't exist

                if (App.Current.Properties.ContainsKey(PetThirstStateKey)) {
                    return PetThirstStates.GetPetThirstState((string)App.Current.Properties[PetThirstStateKey]);
                } else {
                    return PetThirstState.hydrated;
                }
            }

            set {
                App.Current.Properties[PetThirstStateKey] = PetThirstStates.GetPetThirstState(value);
            }
        }

        public int Thirst {
            get {
                if (App.Current.Properties.ContainsKey(PetThirstKey)) {
                    //Console.WriteLine((int)App.Current.Properties[PetThirstKey]);
                    return (int)App.Current.Properties[PetThirstKey];
                } else {
                    Console.WriteLine("No property found?");
                    return 0;
                }
            }

            set {
                App.Current.Properties[PetThirstKey] = value;
            }
        }

        public void Drink() {
            if (Thirst < 91) {
                Thirst += 10;
            } else {
                Thirst = 100;
            }
        }

        public void Dehydrate() {
            if (Thirst > 0) {
                Thirst -= 2;
            } else {
                Thirst = 0;
            }
        }

        public PetCureState CurrentCureState {
            get {
                // Assign a key if it doesn't exist

                if (App.Current.Properties.ContainsKey(PetCureStateKey)) {
                    return PetCureStates.GetPetCureState((string)App.Current.Properties[PetCureStateKey]);
                } else {
                    return PetCureState.cured;
                }
            }

            set {
                App.Current.Properties[PetCureStateKey] = PetCureStates.GetPetCureState(value);
            }
        }

        public int Cure {
            get {
                if (App.Current.Properties.ContainsKey(PetCureKey)) {
                    //Console.WriteLine((int)App.Current.Properties[PetCureKey]);
                    return (int)App.Current.Properties[PetCureKey];
                } else {
                    Console.WriteLine("No property found?");
                    return 0;
                }
            }

            set {
                App.Current.Properties[PetCureKey] = value;
            }
        }

        public void Inject() {
            if (Cure < 91) {
                Cure += 10;
            } else {
                Cure = 100;
            }
        }

        public void Cough() {
            if (Cure > 0) {
                Cure -= 2;
            } else {
                Cure = 0;
            }
        }

        public VPet() {

        }


    }
}

using System;

namespace VirtualPet.Objects {

    public class VPet {

        const string PetHungerStateKey = "PetHungerStateKey";
        const string PetHungerKey = "PetHunger";

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

        public VPet() {

        }


    }
}

using System;

namespace VirtualPet.Objects {

    public enum PetHungerState {
        full,
        peckish,
        hungry,
        starving
    }

    class PetHungerStates {

        public static string GetPetHungerState(PetHungerState hungerState) {
            switch (hungerState) {
                case PetHungerState.full:
                    return "full";
                case PetHungerState.peckish:
                    return "peckish";
                case PetHungerState.hungry:
                    return "hungry";
                default:
                    return "starving";
            }
        }

        public static PetHungerState GetPetHungerState(string hungerState) {
            switch (hungerState) {
                case "full":
                    return PetHungerState.full;
                case "peckish":
                    return PetHungerState.peckish;
                case "hungry":
                    return PetHungerState.hungry;
                default:
                    return PetHungerState.starving;
            }
        }

        public PetHungerStates() {
        }
    }
}

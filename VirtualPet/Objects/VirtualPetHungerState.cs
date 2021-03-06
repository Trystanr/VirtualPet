﻿using System;

namespace VirtualPet.Objects {

    // Enum of hunger states
    public enum PetHungerState {
        full,
        peckish,
        hungry,
        starving
    }

    class PetHungerStates {

        // Returns the specified hunger state
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

        // Returns the hunger state as a string
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

        // Returns the hunger state based on an integer as input
        public static PetHungerState GetStateFromHunger(int hungerValue) {
            if (hungerValue < 20) {
                return PetHungerState.starving;
            } else if (hungerValue < 40) {
                return PetHungerState.hungry;
            } else if (hungerValue < 70) {
                return PetHungerState.peckish;
            } else {
                return PetHungerState.full;
            }
        }

        public PetHungerStates() {
        }
    }
}

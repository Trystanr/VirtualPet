using System;

namespace VirtualPet.Objects {

    // Enum of thirst states
    public enum PetThirstState {
        hydrated,
        thirsty,
        drought,
        dehydrated
    }

    class PetThirstStates {

        // Returns the specified thirst state
        public static string GetPetThirstState(PetThirstState ThirstState) {
            switch (ThirstState) {
                case PetThirstState.hydrated:
                    return "hydrated";
                case PetThirstState.thirsty:
                    return "thirsty";
                case PetThirstState.drought:
                    return "drought";
                default:
                    return "dehydrated";
            }
        }

        // Returns the thirst state as a string
        public static PetThirstState GetPetThirstState(string ThirstState) {
            switch (ThirstState) {
                case "hydrated":
                    return PetThirstState.hydrated;
                case "thirsty":
                    return PetThirstState.thirsty;
                case "drought":
                    return PetThirstState.drought;
                default:
                    return PetThirstState.dehydrated;
            }
        }

        // Returns the thirst state based on an integer as input
        public static PetThirstState GetStateFromThirst(int ThirstValue) {
            if (ThirstValue < 20) {
                return PetThirstState.dehydrated;
            } else if (ThirstValue < 40) {
                return PetThirstState.drought;
            } else if (ThirstValue < 70) {
                return PetThirstState.thirsty;
            } else {
                return PetThirstState.hydrated;
            }
        }

        public PetThirstStates() {
        }
    }
}

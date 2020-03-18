using System;

namespace VirtualPet.Objects {

    public enum PetThirstState {
        hydrated,
        thirsty,
        drought,
        dehydrated
    }

    class PetThirstStates {

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

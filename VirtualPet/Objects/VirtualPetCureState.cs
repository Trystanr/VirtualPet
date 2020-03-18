using System;

namespace VirtualPet.Objects {

    public enum PetCureState {
        cured,
        declining,
        sick,
        ill
    }

    class PetCureStates {

        public static string GetPetCureState(PetCureState CureState) {
            switch (CureState) {
                case PetCureState.cured:
                    return "cured";
                case PetCureState.declining:
                    return "declining";
                case PetCureState.sick:
                    return "sick";
                default:
                    return "ill";
            }
        }

        public static PetCureState GetPetCureState(string CureState) {
            switch (CureState) {
                case "cured":
                    return PetCureState.cured;
                case "declining":
                    return PetCureState.declining;
                case "sick":
                    return PetCureState.sick;
                default:
                    return PetCureState.ill;
            }
        }

        public static PetCureState GetStateFromCure(int CureValue) {
            if (CureValue < 20) {
                return PetCureState.ill;
            } else if (CureValue < 40) {
                return PetCureState.sick;
            } else if (CureValue < 70) {
                return PetCureState.declining;
            } else {
                return PetCureState.cured;
            }
        }

        public PetCureStates() {
        }
    }
}

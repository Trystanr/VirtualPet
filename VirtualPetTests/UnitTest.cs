using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualPet.Objects;

namespace VirtualPetTests {
    [TestClass]
    public class UnitTest {

        [TestMethod]
        public void getHungerStateFull() {
            Assert.AreEqual(PetHungerStates.GetPetHungerState("full"), PetHungerState.full);
        }

        [TestMethod]
        public void getHungerStateStarving() {
            Assert.AreEqual(PetHungerStates.GetPetHungerState("starving"), PetHungerState.starving);
        }

        [TestMethod]
        public void getHungerStateFromValue() {
            int hungerValue = 15;
            Assert.AreEqual(PetHungerStates.GetStateFromHunger(hungerValue), PetHungerState.starving);
        }
        

    }
}

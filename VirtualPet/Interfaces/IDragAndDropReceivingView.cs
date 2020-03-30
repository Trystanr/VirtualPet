using System;
namespace VirtualPet.Interfaces {
    public interface IDragAndDropReceivingView
    {
        void OnDropReceived(IDragAndDropMovingView view);
    }
}

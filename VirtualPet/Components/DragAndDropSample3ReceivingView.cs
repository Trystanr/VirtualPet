using System.Collections.Generic;
using System.Linq;
using VirtualPet.Interfaces;
using Xamarin.Forms;
using VirtualPet.Objects;
using System;
using Xamarin.Essentials;
using VirtualPet;

namespace VirtualPet.Components {
    public class DragAndDropSample3ReceivingView : Frame, IDragAndDropHoverableView, IDragAndDropReceivingView {
        private VPet pet = new VPet();

        public void OnHovered(List<IDragAndDropMovingView> views) {
            Opacity = views.Any() ? .3 : 1;
        }

        public void OnDropReceived(IDragAndDropMovingView view) {
            if (view is DragAndDropMeatView) {
                pet.Feed();
            }

            if (view is DragAndDropWaterView) {
                pet.Drink();
            }

            if (view is DragAndDropInjectView) {
                pet.Inject();
            }
        }
    }
}

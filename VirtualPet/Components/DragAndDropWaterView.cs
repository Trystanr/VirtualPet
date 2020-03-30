using VirtualPet.Extensions;
using VirtualPet.Interfaces;
using Xamarin.Forms;

namespace VirtualPet.Components {
    public class DragAndDropWaterView : Frame, IDragAndDropMovingView {
        public double ScreenX { get; set; }
        public double ScreenY { get; set; }

        protected override void OnParentSet() {
            base.OnParentSet();
            this.InitializeDragAndDrop();
        }
    }
}

using System;
using System.Collections.Generic;

namespace VirtualPet.Interfaces {
    public interface IDragAndDropHoverableView {
        void OnHovered(List<IDragAndDropMovingView> views);
    }
}

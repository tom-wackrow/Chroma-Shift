using System.Collections.Generic;
using UnityEngine;

namespace ChromaShift {
    public class ColouredObject : MonoBehaviour {

        [SerializeField] private List<ColourManager.Colour> myColour = new List<ColourManager.Colour>();
        [SerializeField]
        private List<ColourToggleableMonoBehaviour> toggleables;

        void Awake() {
            // subscribe to event
            ColourManager.OnColourChangeEvent += ColourManager_OnColourChangeEvent;
        }


        void Start() {

        }


        void Update() {

        }

        private void OnDestroy() {
            ColourManager.OnColourChangeEvent -= ColourManager_OnColourChangeEvent;
        }

        private void ColourManager_OnColourChangeEvent(object sender, ColourManager.ColourChangeEventArgs info) {
            if (myColour.Contains(info.newColour)) {
                foreach (var item in toggleables) {
                    item?.enable(info.newColour);
                }
            } else {
                foreach (var item in toggleables) {
                    item?.disable(info.newColour);
                }
            }


        }

    }

    public abstract class ColourToggleableMonoBehaviour : MonoBehaviour {
        public abstract void enable(ColourManager.Colour newColour);
        public abstract void disable(ColourManager.Colour newColour);
    }
}

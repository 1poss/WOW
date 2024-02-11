using System;
using UnityEngine;

namespace WOW {

    public class CameraCore {

        public Camera mainCamera;

        public CameraCore() { }

        public void Inject(Camera mainCamera) {
            this.mainCamera = mainCamera;
        }

        public Vector2 ScreenToWorld(Vector2 screenPos) {
            return mainCamera.ScreenToWorldPoint(screenPos);
        }

    }

}
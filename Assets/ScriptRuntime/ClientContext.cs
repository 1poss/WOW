using UnityEngine;

namespace WOW {

    public class ClientContext {

        public Templates templates;

        public UIApp uiApp;

        public ClientContext() {
            templates = new Templates();
            uiApp = new UIApp();
        }

        public void Inject(Canvas overlayCanvas) {
            uiApp.Inject(overlayCanvas, templates);
        }

    }

}
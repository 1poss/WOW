using UnityEngine;
using WOW.Business;

namespace WOW {

    public class ClientContext {

        public GameContext gameContext;

        public Templates templates;

        public UIApp uiApp;

        public ClientContext() {
            gameContext = new GameContext();
            templates = new Templates();
            uiApp = new UIApp();
        }

        public void Inject(Canvas overlayCanvas) {
            uiApp.Inject(overlayCanvas, templates);
            gameContext.Inject(uiApp, templates);
        }

    }

}
using System.Numerics;
using WOW.Business;

namespace WOW {

    public class ClientContext {

        public GameContext gameContext;

        public CameraCore cameraCore;
        public Templates templates;

        public UIApp uiApp;

        public ClientContext() {
            gameContext = new GameContext();
            cameraCore = new CameraCore();
            templates = new Templates();
            uiApp = new UIApp();
        }

        public void Inject(UnityEngine.Canvas overlayCanvas) {
            uiApp.Inject(overlayCanvas, templates);
            gameContext.Inject(uiApp, cameraCore, templates);
        }

    }

}
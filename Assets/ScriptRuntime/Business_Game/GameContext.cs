namespace WOW.Business {

    public class GameContext {

        public UIApp uiApp;

        public GameContext() { }

        public void Inject(UIApp uiApp) {
            this.uiApp = uiApp;
        }

    }

}
namespace WOW.Business {

    public class GameContext {

        public RoleRepository roleRepository;

        public IDService idService;

        public UIApp uiApp;
        public Templates templates;

        public GameContext() {
            roleRepository = new RoleRepository();
            idService = new IDService();
        }

        public void Inject(UIApp uiApp, Templates templates) {
            this.uiApp = uiApp;
            this.templates = templates;
        }

    }

}
namespace WOW.Business {

    public class GameContext {

        public InputEntity inputEntity;
        public PlayerEntity playerEntity;
        public RoleRepository roleRepository;

        public IDService idService;

        public UIApp uiApp;
        public Templates templates;

        public GameContext() {
            inputEntity = new InputEntity();
            playerEntity = new PlayerEntity();
            roleRepository = new RoleRepository();
            idService = new IDService();
        }

        public void Inject(UIApp uiApp, Templates templates) {
            this.uiApp = uiApp;
            this.templates = templates;
        }

    }

}
namespace WOW.Business {

    public class GameContext {

        public InputEntity inputEntity;
        public PlayerEntity playerEntity;
        public RoleRepository roleRepository;

        public IDService idService;

        public UIApp uiApp;
        public CameraCore cameraCore;
        public Templates templates;

        public GameContext() {
            inputEntity = new InputEntity();
            playerEntity = new PlayerEntity();
            roleRepository = new RoleRepository();
            idService = new IDService();
        }

        public void Inject(UIApp uiApp, CameraCore cameraCore, Templates templates) {
            this.uiApp = uiApp;
            this.cameraCore = cameraCore;
            this.templates = templates;
        }

        public bool TryGetChosenRole(out RoleEntity role) {
            if (playerEntity.chosenEntityType == EntityType.None) {
                role = null;
                return false;
            }
            return roleRepository.TryGet(playerEntity.chosenEntityID, out role);
        }

    }

}
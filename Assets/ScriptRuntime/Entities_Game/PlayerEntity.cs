namespace WOW {

    public class PlayerEntity {

        public EntityType chosenEntityType;
        public int chosenEntityID;

        public PlayerEntity() {
            chosenEntityType = EntityType.None;
            chosenEntityID = -1;
        }

    }

}
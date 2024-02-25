namespace WOW.Business {

    public static class UIDomain {

        public static void Teamer_Open(GameContext ctx) {
            ctx.uiApp.W_Teamer_Open();
            int teamerLen = ctx.roleRepository.GetPlayerTeamer(out RoleEntity[] teamers);
            for (int i = 0; i < teamerLen; i++) {
                var teamer = teamers[i];
                ctx.uiApp.W_Teamer_Add(teamer.id, teamer.typeName, teamer.portraitIcon);
            }
        }

        public static void Teamer_Update(GameContext ctx) {
            int teamerLen = ctx.roleRepository.GetPlayerTeamer(out RoleEntity[] teamers);
            for (int i = 0; i < teamerLen; i++) {
                var teamer = teamers[i];
                ctx.uiApp.W_Teamer_UpdateHP(teamer.id, teamer.attrComponent.hp, teamer.attrComponent.hpMax);
            }
        }

    }

}
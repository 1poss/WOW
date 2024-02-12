namespace WOW.Business {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx, int typeID) {
            RoleEntity role = GameFactory.Role_Create(ctx.templates, ctx.idService, typeID);
            ctx.roleRepository.Add(role);
            return role;
        }

        public static void MoveByPath(GameContext ctx, RoleEntity role, float fixdt) {
            role.Move_FixTick(fixdt);
        }
    }
}
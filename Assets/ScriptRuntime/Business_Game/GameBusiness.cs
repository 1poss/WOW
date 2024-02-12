using UnityEngine;

namespace WOW.Business {

    public static class GameBusiness {

        public static void Enter(GameContext ctx) {
            Debug.Log("GameBusiness.Enter");
            var role = RoleDomain.Spawn(ctx, 1);
        }

        public static void PreTick(GameContext ctx, float dt) {

            InputDomain.Process(ctx, ctx.inputEntity);

        }

        public static void FixTick(GameContext ctx, float fixdt) {

            int roleLen = ctx.roleRepository.TakeAll(out var roles);
            for (int i = 0; i < roleLen; i++) {
                RoleDomain.MoveByPath(ctx, roles[i], fixdt);
            }

            Physics2D.Simulate(fixdt);

        }

        public static void LateTick(GameContext ctx, float latedt) {

        }

    }

}
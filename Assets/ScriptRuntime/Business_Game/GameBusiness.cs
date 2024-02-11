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

            Physics2D.Simulate(fixdt);

        }

        public static void LateTick(GameContext ctx, float latedt) {

        }

    }

}
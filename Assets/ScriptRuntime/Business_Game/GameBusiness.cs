using UnityEngine;

namespace WOW.Business {

    public static class GameBusiness {

        public static void Enter(GameContext ctx) {
            Debug.Log("GameBusiness.Enter");
            var role = RoleDomain.Spawn(ctx, 1);
        }

        public static void PreTick(GameContext ctx, float dt) {
            ctx.inputEntity.Process();

            var cam = ctx.cameraCore.mainCamera;

            Vector3 worldPos = cam.ScreenToWorldPoint(ctx.inputEntity.downScreenPos);
            ctx.inputEntity.downWorldPos = worldPos;

            if (ctx.inputEntity.isLeftDown) {
                Collider2D coll = Physics2D.OverlapPoint(worldPos);
                if (coll != null) {
                    Debug.Log("coll.name: " + coll.name);
                }
            }

        }

        public static void FixTick(GameContext ctx, float fixdt) {

            Physics2D.Simulate(fixdt);

        }

        public static void LateTick(GameContext ctx, float latedt) {

        }

    }

}
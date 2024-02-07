using UnityEngine;

namespace WOW.Business {

    public static class GameBusiness {

        public static void Enter(GameContext ctx) {
            Debug.Log("GameBusiness.Enter");
            var role = RoleDomain.Spawn(ctx, 1);
        }

    }

}
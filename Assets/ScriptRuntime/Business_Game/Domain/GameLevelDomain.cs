using UnityEngine;

namespace WOW.Business {

    public static class GameLevelDomain {

        public static void Enter(GameContext ctx, int chapter, int level) {

            bool has = ctx.templates.GameLevel_TryGet(chapter, level, out var gameTM);
            if (!has) {
                Debug.LogError($"GameLevelDomain.Enter: GameLevel not found: {chapter}-{level}");
                return;
            }

            var spawners = gameTM.spawners;
            for (int i = 0; i < spawners.Length; i++) {
                var spawner = spawners[i];
                if (spawner.entityType == EntityType.Role) {
                    RoleDomain.Spawn(ctx, spawner.typeID, spawner.allyType, spawner.spawnPos);
                }
            }

            // UI
            UIDomain.Teamer_Open(ctx);

        }

    }
}
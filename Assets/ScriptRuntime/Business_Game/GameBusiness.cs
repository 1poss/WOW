using UnityEngine;

namespace WOW.Business {

    public static class GameBusiness {

        public static void Init(GameContext ctx) {

            Physics2D.IgnoreLayerCollision(LayerCollection.ROLE, LayerCollection.ROLE, true);

            var input = ctx.inputEntity;

            input.Bind(InputEnum.ChooseTeamer1, new KeyCode[] { KeyCode.Alpha1 });
            input.Bind(InputEnum.ChooseTeamer2, new KeyCode[] { KeyCode.Alpha2 });
            input.Bind(InputEnum.ChooseTeamer3, new KeyCode[] { KeyCode.Alpha3 });
            input.Bind(InputEnum.ChooseTeamer4, new KeyCode[] { KeyCode.Alpha4 });

            input.Bind(InputEnum.Skill1, new KeyCode[] { KeyCode.Q });
            input.Bind(InputEnum.Skill2, new KeyCode[] { KeyCode.W });
            input.Bind(InputEnum.Skill3, new KeyCode[] { KeyCode.E });
            input.Bind(InputEnum.Skill4, new KeyCode[] { KeyCode.R });
            input.Bind(InputEnum.Skill5, new KeyCode[] { KeyCode.T });

            input.Bind(InputEnum.CancelChose, new KeyCode[] { KeyCode.Escape });

        }

        public static void Enter(GameContext ctx) {
            GameLevelDomain.Enter(ctx, 1, 1);
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
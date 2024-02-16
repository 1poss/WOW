using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WOW.Business;

namespace WOW {

    public class ClientMain : MonoBehaviour {

        ClientContext ctx;
        [SerializeField] Canvas overlayCanvas;

        bool isTearDown;

        void Start() {

            // ==== Instantiate ====
            ctx = new ClientContext();

            // ==== Inject ====
            ctx.Inject(overlayCanvas, Camera.main);

            // ==== Init ====
            ctx.templates.Init();
            GameBusiness.Init(ctx.gameContext);

            ClientBindings.Binding(ctx);

            // ==== Enter Game ====
            ctx.uiApp.W_Login_Open();

        }

        float restDT;
        void Update() {

            float dt = Time.deltaTime;
            GameBusiness.PreTick(ctx.gameContext, dt);

            restDT += dt;
            const float fixInterval = 0.02f;
            if (restDT <= fixInterval) {
                GameBusiness.FixTick(ctx.gameContext, restDT);
                restDT = 0;
            } else {
                while (restDT > fixInterval) {
                    GameBusiness.FixTick(ctx.gameContext, fixInterval);
                    restDT -= fixInterval;
                }
            }

        }

        void OnApplicationQuit() {
            TearDown();
        }

        void OnDestroy() {
            TearDown();
        }

        void TearDown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;
            ctx.templates.Release();
        }

    }

}

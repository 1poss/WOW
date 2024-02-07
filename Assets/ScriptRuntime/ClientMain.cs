using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WOW {

    public class ClientMain : MonoBehaviour {

        ClientContext ctx;
        [SerializeField] Canvas overlayCanvas;

        bool isTearDown;

        void Start() {

            // ==== Instantiate ====
            ctx = new ClientContext();

            // ==== Inject ====
            ctx.Inject(overlayCanvas);

            // ==== Init ====
            ctx.templates.Init();

            ClientBindings.Binding(ctx);

            // ==== Enter Game ====
            ctx.uiApp.W_Login_Open();

        }

        void Update() {

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

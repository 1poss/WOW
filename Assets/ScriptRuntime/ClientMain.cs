using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WOW {

    public class ClientMain : MonoBehaviour {

        ClientContext ctx;

        void Start() {

            // ==== Instantiate ====
            ctx = new ClientContext();

            // ==== Inject ====

            // ==== Init ====
            ctx.templates.Init();

            // ==== Enter Game ====

        }

        void Update() {

        }

    }

}

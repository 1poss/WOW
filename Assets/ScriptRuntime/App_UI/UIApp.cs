using UnityEngine;

namespace WOW {

    public class UIApp {

        UIContext ctx;
        Templates templates;

        Canvas overlayCanvas;

        public readonly UIEvents events;

        public UIApp() {
            ctx = new UIContext();
            events = new UIEvents();
        }

        public void Inject(Canvas overlayCanvas, Templates templates) {
            this.overlayCanvas = overlayCanvas;
            this.templates = templates;
        }

        public void W_Login_Open() {
            var window = ctx.w_login;
            if (window == null) {
                window = Open<Window_Login>();
                window.Ctor();
                ctx.w_login = window;

                window.OnStartHandle = () => {
                    events.W_Login_Start();
                };
            }
        }

        public void W_Login_Close() {
            var window = ctx.w_login;
            if (window != null) {
                Object.Destroy(window.gameObject);
                ctx.w_login = null;
            }
        }

        T Open<T>() where T : MonoBehaviour {
            string name = typeof(T).Name;
            bool has = templates.UI_TryGet(name, out var prefab);
            if (!has) {
                Debug.LogError($"UIApp.Open<{name}>: prefab not found");
                return null;
            }
            var go = Object.Instantiate(prefab, overlayCanvas.transform);
            var comp = go.GetComponent<T>();
            return comp;
        }

    }

}
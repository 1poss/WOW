using System;

namespace WOW {

    public class UIEvents {

        public UIEvents() { }

        public Action W_Login_StartHandle;
        public void W_Login_Start() {
            W_Login_StartHandle.Invoke();
        }

    }
}
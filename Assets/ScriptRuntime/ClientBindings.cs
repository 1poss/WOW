using WOW.Business;

namespace WOW {

    public static class ClientBindings {

        public static void Binding(ClientContext ctx) {
            var uiEvents = ctx.uiApp.events;
            uiEvents.W_Login_StartHandle = () => {
                GameBusiness.Enter(ctx.gameContext);
            };
        }

    }

}
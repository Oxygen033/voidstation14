using Robust.Client.UserInterface;
using Robust.Client.GameObjects;
using Robust.Shared.Timing;

namespace Content.Client.Voidstation.KeycardActivator.UI
{
    public sealed class KeycardActivatorBoundUserInterface : BoundUserInterface
    {
        [ViewVariables]
        private KeycardActivatorMenu? _menu;

        public KeycardActivatorBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey) { }

        protected override void Open()
        {
            base.Open();

            _menu = this.CreateWindow<KeycardActivatorMenu>();
            _menu.OnActionSelected += HandleActionSelected;
            _menu.OnBack += HandleBack;
        }

        private void HandleActionSelected(string action)
        {
            _menu?.ShowActivationScreen();
        }

        private void HandleBack()
        {
            _menu?.ShowMainScreen();
        }

        protected override void UpdateState(BoundUserInterfaceState state)
        {
        }
    }
}

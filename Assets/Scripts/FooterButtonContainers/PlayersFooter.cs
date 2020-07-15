using System;

namespace RootStats.Controllers.FooterButtons
{
    public class PlayersFooter : FooterButtonContainer
    {
        public override void Init()
        {
            base.Init();
        }
        
        public override void FillClickActions(Action[] actions)
        {
            base.FillClickActions(actions);
        }
        
        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }

        public void DisableButtonsByAction(Action action)
        {
            foreach (var button in _buttons)
            {
                button.interactable = button.OnClickAction != action;
            }
        }
    }
}
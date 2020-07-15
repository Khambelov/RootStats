using System;

namespace RootStats.Controllers.FooterButtons
{
    public class InputFooter : FooterButtonContainer
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

        public void DisableAllButtons()
        {
            foreach (var button in _buttons)
            {
                button.interactable = false;
            }
        }

        public void UpdateEnableButtons(bool canBack, bool canSave, Action saveAction, bool canNext)
        {
            _buttons[0].interactable = canBack;
            Array.Find(_buttons, b => b.OnClickAction == saveAction).interactable = canSave;
            _buttons[_buttons.Length - 1].interactable = canNext;
        }
    }
}
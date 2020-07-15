using RootStats.Controllers;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class SettingDialog : DialogView
    {
        [SerializeField] private TextExtension _title;
        [SerializeField] private TextExtension _languageText;
        [SerializeField] private ButtonExtension _closeButton;
        [SerializeField] private ButtonExtension _accessButton;

        [SerializeField] private ToggleExtension _darkTheme;
        [SerializeField] private DropdownExtension _language;

        public override void Init()
        {
            base.Init();

            _title.Init();
            _languageText.Init();

            _darkTheme.OnValueChangeAction = UpdateTheme;
            _darkTheme.Init();

            _language.OnValueChangeAction = ChangeLanguage;
            _language.Init();

            _closeButton.OnClickAction = DialogsController.Instance.HideWindow;
            _closeButton.Init();
        }

        private void UpdateTheme(bool isOn)
        {
        }

        private void ChangeLanguage(int languageIndex)
        {
        }
    }
}
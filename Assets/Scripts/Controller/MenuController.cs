using System.Collections;
using RootStats.UI;
using UnityEngine;

namespace RootStats.Controllers
{
    public class MenuController : Controller
    {
        public static MenuController Instance { get; private set; }

        [SerializeField] private ButtonExtension _menuButton;
        [SerializeField] private Animator _menuAnimator;
        [SerializeField] private ButtonExtension _settingButton;
        [SerializeField] private ButtonExtension _backgroundButton;
        [SerializeField] private ButtonExtension _closeButton;

        [SerializeField] private ButtonExtension[] _buttons;
        [SerializeField] private Controller[] _controllers;

        public override IEnumerator Init()
        {
            if (Instance == null)
                Instance = this;

            yield return base.Init();

            _closeButton.OnClickAction = _backgroundButton.OnClickAction = () => { _menuAnimator.SetTrigger("close"); };
            _menuButton.OnClickAction = ShowWindow;
            _settingButton.OnClickAction = () =>
            {
                _menuAnimator.SetTrigger("close");
                DialogsController.Instance.OpenSettingDialog();
            };

            _settingButton.Init();
            _closeButton.Init();
            _menuButton.Init();

            for (int i = 0; i < _buttons.Length; i++)
            {
                var viewIndex = i;
                _buttons[i].OnClickAction = () =>
                {
                    OpenWindow(_buttons[viewIndex], _controllers[viewIndex]);
                    _menuAnimator.SetTrigger("close");
                };
            }

            OpenWindow(_buttons[0], _controllers[0]);

            IsInitialized = true;

            yield return null;
        }

        private void OpenWindow(ButtonExtension button, Controller controller)
        {
            foreach (var viewButton in _buttons)
            {
                viewButton.interactable = viewButton != button;
            }

            foreach (var view in _controllers)
            {
                if (view == controller)
                    view.ShowWindow();
                else
                    view.HideWindow();
            }
        }
    }
}
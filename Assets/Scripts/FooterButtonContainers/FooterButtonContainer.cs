using System;
using RootStats.UI;
using UnityEngine;

namespace RootStats.Controllers.FooterButtons
{
    public class FooterButtonContainer : MonoBehaviour
    {
        [SerializeField] protected ButtonExtension[] _buttons;

        public int ButtonsCount => _buttons.Length;

        public virtual void Init()
        {
            foreach (var button in _buttons)
            {
                button.Init();
            }
        }

        public virtual void FillClickActions(Action[] actions)
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (i >= actions.Length) break;

                _buttons[i].OnClickAction = actions[i];
            }
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public void EnableButton(int buttonIndex)
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].interactable = i == buttonIndex;
            }
        }

        public void DisableButton(int buttonIndex)
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].interactable = i != buttonIndex;
            }
        }
    }
}
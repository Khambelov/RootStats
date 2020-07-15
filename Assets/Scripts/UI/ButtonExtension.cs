using System;
using RootStats.UI.Theme;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RootStats.UI
{
    public class ButtonExtension : Button, IThemeListener
    {
        public Action OnClickAction { get; set; }
        public Action OnSubmitAction { get; set; }

        private Image _background;
        private Image _border;
        private TextExtension _text;

        public void Init()
        {
            var asset = ScriptableObject.CreateInstance<ButtonTheme>();
            asset.InstanceId = GetHashCode(); 
            AssetDatabase.CreateAsset(asset, $"Assets/Resources/Theme/White/Buttons/{name + " " + GetHashCode()}.asset");

            if (targetGraphic != null)
                _background = (Image) targetGraphic;

            if (_background.gameObject.transform.childCount > 0)
                _border = _background.gameObject.transform.GetChild(0).GetComponent<Image>();

            _text = transform.GetComponentInChildren<TextExtension>();

            ThemeManager.Instance.AddListenerEvent(GetHashCode(), this);

            ThemeManager.Instance.UpdateElementTheme(GetHashCode(), ThemeType.White);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if(!interactable) return;
            
            base.OnPointerClick(eventData);

            OnClickAction?.Invoke();
        }

        public override void OnSubmit(BaseEventData eventData)
        {
            base.OnSubmit(eventData);

            OnSubmitAction?.Invoke();
        }

        public void SetButtonText(string text)
        {
            if(_text == null) return;

            _text.text = text;
        }

        public void UpdateTheme(Theme.Theme theme)
        {
            if (theme == null) return;

            var buttonTheme = (ButtonTheme) theme;

            _background.sprite = buttonTheme.BackgroundImage;
            _background.color = buttonTheme.BaseColor;

            if (buttonTheme.HasBorder)
            {
                _border.sprite = buttonTheme.BorderImage;
                _border.color = buttonTheme.BorderColor;
            }

            if (buttonTheme.HasText)
            {
                var textTheme = ScriptableObject.CreateInstance<TextTheme>();
                textTheme.TextFont = buttonTheme.TextFont;
                textTheme.BaseColor = buttonTheme.TextColor;

                _text.UpdateTheme(textTheme);
            }

            ColorBlock newColorsBlock = colors;

            newColorsBlock.normalColor = buttonTheme.NormalColor;
            newColorsBlock.highlightedColor = buttonTheme.HighlightedColor;
            newColorsBlock.pressedColor = buttonTheme.PressedColor;
            newColorsBlock.selectedColor = buttonTheme.SelectedColor;
            newColorsBlock.disabledColor = buttonTheme.DisabledColor;

            colors = newColorsBlock;
        }
    }
}
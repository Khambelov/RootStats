using System;
using RootStats.UI.Theme;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RootStats.UI
{
    public class InputFieldExtension : InputField, IThemeListener
    {
        public Action<string> OnSubmitEvent { get; set; }
        public Action InputSelected { get; set; }
        public Action InputDeselected { get; set; }

        private Image _background;
        private Image _border;
        private TextExtension _placeholder;
        private TextExtension _text;

        public void Init()
        {
            var asset = ScriptableObject.CreateInstance<InputFieldTheme>();
            asset.InstanceId = GetHashCode();
            AssetDatabase.CreateAsset(asset, $"Assets/Resources/Theme/White/InputFields/{name + " " + GetHashCode()}.asset");
            
            _background = (Image) targetGraphic;

            if (_background.gameObject.transform.childCount > 0)
                _border = _background.gameObject.transform.GetChild(0).GetComponent<Image>();

            _placeholder = (TextExtension) placeholder;
            _placeholder.Init();

            _text = (TextExtension) textComponent;
            _text.Init();

            onValueChanged.AddListener(Validate);
            onEndEdit.AddListener(TrySubmit);

            ThemeManager.Instance.AddListenerEvent(GetHashCode(), this);

            ThemeManager.Instance.UpdateElementTheme(GetHashCode(), ThemeType.White);
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);

            InputSelected?.Invoke();
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);

            InputDeselected?.Invoke();
        }

        private void TrySubmit(string s)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                OnSubmitEvent?.Invoke(s);
            }

            if (!EventSystem.current.alreadySelecting)
            {
                EventSystem.current.SetSelectedGameObject(null);
            }

            DeactivateInputField();
        }

        protected virtual void Validate(string content)
        {
            //Change if need validate input data
            text = content;
        }

        public void ClearText()
        {
            text = string.Empty;
        }

        public void UpdateTheme(Theme.Theme theme)
        {
            if (theme == null) return;

            var inputFieldTheme = (InputFieldTheme) theme;

            _background.sprite = inputFieldTheme.BackgroundImage;
            _background.color = inputFieldTheme.BaseColor;

            _border.sprite = inputFieldTheme.BorderImage;
            _border.color = inputFieldTheme.BorderColor;

            ColorBlock newColorsBlock = colors;

            newColorsBlock.normalColor = inputFieldTheme.NormalColor;
            newColorsBlock.highlightedColor = inputFieldTheme.HighlightedColor;
            newColorsBlock.pressedColor = inputFieldTheme.PressedColor;
            newColorsBlock.selectedColor = inputFieldTheme.SelectedColor;
            newColorsBlock.disabledColor = inputFieldTheme.DisabledColor;

            colors = newColorsBlock;
        }
    }
}
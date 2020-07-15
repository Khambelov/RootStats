using System;
using RootStats.UI.Theme;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RootStats.UI
{
    [Serializable]
    public class ToggleExtension : Toggle, IThemeListener
    {
        public Action OnClickAction { get; set; }
        public UnityAction<bool> OnValueChangeAction { get; set; }

        private Image _background;
        private Image _border;
        private Image _checkMark;

        public void Init()
        {
            var asset = ScriptableObject.CreateInstance<ToggleTheme>();
            asset.InstanceId = GetHashCode(); 
            AssetDatabase.CreateAsset(asset, $"Assets/Resources/Theme/White/Toggles/{name + " " + GetHashCode()}.asset");
            
            if (targetGraphic != null)
                _background = (Image) targetGraphic;

            if (_background.gameObject.transform.childCount > 0)
                _border = _background.gameObject.transform.GetChild(0).GetComponent<Image>();

            if (graphic != null)
                _checkMark = (Image) graphic;

            transform.GetComponentInChildren<TextExtension>()?.Init();

            onValueChanged.AddListener(OnValueChangeAction);

            ThemeManager.Instance.AddListenerEvent(GetHashCode(), this);

            ThemeManager.Instance.UpdateElementTheme(GetHashCode(), ThemeType.White);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            OnClickAction?.Invoke();
        }

        public bool IsOn
        {
            get => isOn;
            set => isOn = value;
        }

        public void UpdateTheme(Theme.Theme theme)
        {
            if (theme == null) return;

            var toggleTheme = (ToggleTheme) theme;

            _background.sprite = toggleTheme.BackgroundImage;
            _background.color = toggleTheme.BaseColor;

            if (toggleTheme.HasBorder)
            {
                _border.sprite = toggleTheme.BorderImage;
                _border.color = toggleTheme.BorderColor;
            }

            if (toggleTheme.HasCheckMark)
            {
                _checkMark.sprite = toggleTheme.CheckMarkImage;
                _checkMark.color = toggleTheme.CheckMarkColor;
            }

            ColorBlock newColorsBlock = colors;

            newColorsBlock.normalColor = toggleTheme.NormalColor;
            newColorsBlock.highlightedColor = toggleTheme.HighlightedColor;
            newColorsBlock.pressedColor = toggleTheme.PressedColor;
            newColorsBlock.selectedColor = toggleTheme.SelectedColor;
            newColorsBlock.disabledColor = toggleTheme.DisabledColor;

            colors = newColorsBlock;
        }
    }
}
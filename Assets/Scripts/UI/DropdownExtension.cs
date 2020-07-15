using System;
using System.Security.Cryptography;
using RootStats.UI.Theme;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RootStats.UI
{
    public class DropdownExtension : Dropdown, IThemeListener
    {
        public UnityAction<int> OnValueChangeAction { get; set; }

        private Image _background;
        private Image _border;

        public void Init()
        {
            var asset = ScriptableObject.CreateInstance<DropdownTheme>();
            asset.InstanceId = GetHashCode();
            AssetDatabase.CreateAsset(asset, $"Assets/Resources/Theme/White/Dropdowns/{name + " " + GetHashCode()}.asset");
            
            if (targetGraphic != null)
                _background = (Image) targetGraphic;

            if (_background.gameObject.transform.childCount > 0)
                _border = _background.gameObject.transform.GetChild(0).GetComponent<Image>();

            if (captionText != null)
            {
                (captionText as TextExtension)?.Init();
            }

            if (template != null)
                template.GetComponent<DropdownTemplate>()?.Init();

            onValueChanged.AddListener(OnValueChangeAction);

            ThemeManager.Instance.AddListenerEvent(GetHashCode(), this);

            ThemeManager.Instance.UpdateElementTheme(GetHashCode(), ThemeType.White);
        }

        public void UpdateTheme(Theme.Theme theme)
        {
            if (theme == null) return;

            var windowTheme = (WindowTheme) theme;

            _background.sprite = windowTheme.WindowImage;
            _background.color = windowTheme.BaseColor;

            _border.sprite = windowTheme.BorderImage;
            _border.color = windowTheme.BorderColor;
        }
    }
}
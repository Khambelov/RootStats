using RootStats.UI.Theme;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.UI.Views
{
    public class MainView : View
    {
        [SerializeField] private Image _window;
        [SerializeField] private Image _border;

        public override void Init()
        {
            var asset = ScriptableObject.CreateInstance<DropdownTheme>();
            asset.InstanceId = GetHashCode();
            AssetDatabase.CreateAsset(asset, $"Assets/Resources/Theme/White/Windows/{name + " " + GetHashCode()}.asset");
            
            base.Init();

            ThemeManager.Instance.AddListenerEvent(GetInstanceID(), this);
            
            ThemeManager.Instance.UpdateElementTheme(GetInstanceID(), ThemeType.White);
        }

        public override void UpdateTheme(Theme.Theme theme)
        {
            base.UpdateTheme(theme);
            
            if(theme == null) return;

            var windowTheme = (WindowTheme) theme;

            _window.sprite = windowTheme.WindowImage;
            _border.sprite = windowTheme.BorderImage;

            _window.color = windowTheme.BaseColor;
            _border.color = windowTheme.BorderColor;
        }
    }
}
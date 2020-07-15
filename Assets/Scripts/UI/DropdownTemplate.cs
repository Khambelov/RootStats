using RootStats.UI.Theme;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.UI
{
    public class DropdownTemplate : MonoBehaviour, IThemeListener
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _border;
        [SerializeField] private ToggleExtension _item;

        public void Init()
        {
            var asset = ScriptableObject.CreateInstance<DropdownTheme>();
            asset.InstanceId = GetHashCode();
            AssetDatabase.CreateAsset(asset,
                $"Assets/Resources/Theme/White/Windows/{name + " " + GetHashCode()}.asset");

            _item.Init();

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
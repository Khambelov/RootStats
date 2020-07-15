using UnityEngine;
using UnityEngine.Serialization;

namespace RootStats.UI.Theme
{
    [CreateAssetMenu(fileName = "NewToggleTheme", menuName = "Theme/ToggleTheme", order = 0)]
    public class ToggleTheme : Theme
    {
        public Sprite BackgroundImage;

        public bool HasBorder;
        public Sprite BorderImage;
        public Color BorderColor;
        
        public bool HasCheckMark;
        public Sprite CheckMarkImage;
        public Color CheckMarkColor;
        
        public Color NormalColor;
        public Color HighlightedColor;
        public Color PressedColor;
        public Color SelectedColor;
        public Color DisabledColor;
    }
}
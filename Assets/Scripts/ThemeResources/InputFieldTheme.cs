using UnityEngine;

namespace RootStats.UI.Theme
{
    [CreateAssetMenu(fileName = "NewInputFieldTheme", menuName = "Theme/InputFieldTheme", order = 0)]
    public class InputFieldTheme : Theme
    {
        public Sprite BackgroundImage;
        public Sprite BorderImage;
        public Color BorderColor;

        public Color NormalColor;
        public Color HighlightedColor;
        public Color PressedColor;
        public Color SelectedColor;
        public Color DisabledColor;
    }
}
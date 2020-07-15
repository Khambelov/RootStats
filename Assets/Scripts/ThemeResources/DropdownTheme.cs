using UnityEngine;

namespace RootStats.UI.Theme
{
    [CreateAssetMenu(fileName = "NewDropdownTheme", menuName = "Theme/DropdownTheme", order = 0)]
    public class DropdownTheme : Theme
    {
        public Sprite BackgroundImage;

        public bool HasBorder;
        public Sprite BorderImage;
        public Color BorderColor;
    }
}
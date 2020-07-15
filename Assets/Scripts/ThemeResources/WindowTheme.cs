using UnityEngine;

namespace RootStats.UI.Theme
{
    [CreateAssetMenu(fileName = "NewWindowTheme", menuName = "Theme/WindowTheme", order = 0)]
    public class WindowTheme : Theme
    {
        public Sprite WindowImage;
        public Sprite BorderImage;
        public Color BorderColor;
    }
}
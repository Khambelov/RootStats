using System.Collections.Generic;
using UnityEngine;

namespace RootStats.UI.Theme
{
    [CreateAssetMenu(fileName = "NewButtonTheme", menuName = "Theme/ButtonTheme", order = 0)] 
    public class ButtonTheme : Theme
    {
        public Sprite BackgroundImage;

        public bool HasBorder;
        public Sprite BorderImage;
        public Color BorderColor;

        public bool HasText;
        public Color TextColor;
        public Font TextFont;
        
        public Color NormalColor;
        public Color HighlightedColor;
        public Color PressedColor;
        public Color SelectedColor;
        public Color DisabledColor;
    }
}
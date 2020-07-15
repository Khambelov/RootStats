using System;
using RootStats.UI.Theme;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.UI
{
    public class TextExtension : Text, IThemeListener
    {
        public void Init()
        {
            var asset = ScriptableObject.CreateInstance<TextTheme>();
            asset.InstanceId = GetHashCode();
            AssetDatabase.CreateAsset(asset,
                $"Assets/Resources/Theme/White/Textes/{name + " " + GetHashCode()}.asset");

            ThemeManager.Instance.AddListenerEvent(GetHashCode(), this);

            ThemeManager.Instance.UpdateElementTheme(GetHashCode(), ThemeType.White);
        }

        public void UpdateTheme(Theme.Theme theme)
        {
            if (theme == null) return;

            var textTheme = (TextTheme) theme;

            font = textTheme.TextFont;
            color = textTheme.BaseColor;
        }
    }
}
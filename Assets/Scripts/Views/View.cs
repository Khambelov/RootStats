using RootStats.UI.Theme;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class View : MonoBehaviour, IThemeListener
    {
        public bool IsVisible => gameObject.activeInHierarchy;

        public virtual void Init() { }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void UpdateTheme(Theme.Theme theme)
        {
            if (theme == null) return;
        }
    }
}

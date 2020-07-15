using RootStats.UI.Theme;
using UnityEngine;

namespace RootStats.Core.Containers
{
    [CreateAssetMenu(fileName = "NewThemeContainer", menuName = "Containers/ThemeContainer", order = 0)]
    public class ThemeContainer : Container<Theme>
    {
        public ThemeType ThemeType { get; set; }

        public override Theme GetItem(int instanceId)
        {
            return items.Find(t => t.InstanceId == instanceId && t.ThemeType == ThemeType);
        }
    }
}
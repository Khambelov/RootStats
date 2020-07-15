using System.Collections.Generic;
using RootStats.Core.Containers;
using UnityEngine;

namespace RootStats.UI.Theme
{
    public class ThemeManager : BaseManager<ThemeManager, Theme>
    {
        private Dictionary<int, IThemeListener> _listeners;

        protected override void OnInit()
        {
            base.OnInit();

            _listeners = new Dictionary<int, IThemeListener>();

            _container = Resources.Load<ThemeContainer>("Theme/ThemeContainer");

            if (_container != null && _container is ThemeContainer themeContainer)
            {
                themeContainer.ThemeType = ThemeType.White;
            }
        }

        public void AddListenerEvent(int instanceId, IThemeListener listener)
        {
            if (!_listeners.ContainsKey(instanceId))
                _listeners.Add(instanceId, listener);
        }

        public void RemoveListenerEvent(int instanceId)
        {
            if (_listeners.ContainsKey(instanceId))
                _listeners.Remove(instanceId);
        }

        public void OnChangeTheme(ThemeType themeType)
        {
            foreach (var key in _listeners.Keys)
            {
                _listeners[key].UpdateTheme(_container.GetItem(key));
            }
        }

        public void UpdateElementTheme(int instanceId, ThemeType themeType)
        {
            _listeners[instanceId].UpdateTheme(_container.GetItem(instanceId));
        }
    }
}
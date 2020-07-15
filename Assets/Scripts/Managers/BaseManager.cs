using RootStats.Core;
using RootStats.Core.Containers;
using RootStats.UI.Theme;
using UnityEngine;


    public class BaseManager<T0, T1> : SingletonBehaviour<T0> where T0 : SingletonBehaviour<T0>
    {
        protected Container<T1> _container;
        
        protected override void OnInit()
        {
        }
    }

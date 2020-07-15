using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

namespace RootStats.Core.Containers
{
    public class Container<T> : ScriptableObject
    {
        [SerializeField] protected List<T> items;

        public virtual T GetItem(int id)
        {
            return items.FirstOrDefault();
        }
    }
}
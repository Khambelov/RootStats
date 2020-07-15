using RootStats.UI;
using UnityEngine;

namespace RootStats.UI.Table
{
    public class Table : MonoBehaviour
    {
        [SerializeField] private TextExtension _title;
        [SerializeField] private TextExtension[] _titleElements;

        public virtual void Init()
        {
            _title.Init();

            foreach (var element in _titleElements)
            {
                element.Init();
            }
        }
        
        public virtual void FillData()
        {
        }
    }
}
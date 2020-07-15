using UnityEngine;

namespace RootStats.UI.Views
{
    public class FactionPlayerStats : View
    {
        [SerializeField] private Table.Table[] _tables;
        [SerializeField] private Transform _content;
        
        public override void Init()
        {
            base.Init();

            foreach (var table in _tables)
            {
                Instantiate(table.gameObject, _content, false);
                table.Init();
            }
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
            
            transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
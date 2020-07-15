using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class FactionsDataView : View
    {
        [SerializeField] private GameObject _factionViewPrefab;
        [SerializeField] private Transform _content;

        private List<FactionView> _factionViews;

        public override void Init()
        {
            base.Init();

            _factionViews = new List<FactionView>();
        }

        public void SetFactionView(bool active)
        {
            if (active)
                AddFactionView();
            else
                RemoveFactionView();
        }

        private void AddFactionView()
        {
            if(_factionViews == null) return;

            var obj = Instantiate(_factionViewPrefab, _content, false);
            obj.GetComponent<FactionView>().Init();

            _factionViews.Add(obj.GetComponent<FactionView>());
        }

        private void RemoveFactionView()
        {
            if(_factionViews == null || _factionViews.Count <= 0) return;
            
            var obj = _factionViews.FirstOrDefault();

            if (obj != null)
            {
                _factionViews.Remove(obj);
                Destroy(obj.gameObject);
            }
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }
    }
}
using RootStats.Controllers;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class OtherFactionsStats : View
    {
        [SerializeField] private View _listView;
        [SerializeField] private View _infoView;

        public override void Init()
        {
            base.Init();

            ((OtherFactionStatsList) _listView).OnOpenInfoAction = ShowFactionInfo;
            _listView.Init();
            
            ((OtherFactionStatsInfo) _infoView).OnBackToListAction = BackToList;
            _infoView.Init();
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
            
            transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);

            _infoView.Hide();
            _listView.Hide();
        }

        public bool InfoViewIsActive => _infoView.IsVisible;
        
        private void ShowFactionInfo()
        {
            FactionStatsController.Instance.StartAnimation("factionInfo");
        }

        private void BackToList()
        {
            FactionStatsController.Instance.StartAnimation("factionInfo");
        }
    }
}
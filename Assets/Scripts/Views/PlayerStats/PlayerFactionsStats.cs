using RootStats.Controllers;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class PlayerFactionsStats : View
    {
        [SerializeField] private View _listView;
        [SerializeField] private View _infoView;

        public override void Init()
        {
            base.Init();

            ((PlayerFactionStatsList) _listView).OnOpenInfoAction = ShowFactionInfo;
            _listView.Init();

            ((PlayerFactionStatsInfo) _infoView).OnBackToListAction = BackToList;
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
            
            _listView.Hide();
            _infoView.Hide();
        }

        public bool InfoViewIsActive => _infoView.IsVisible;

        private void ShowFactionInfo()
        {
            PlayerStatsController.Instance.StartAnimation("factionInfo");
        }

        private void BackToList()
        {
            PlayerStatsController.Instance.StartAnimation("factionInfo");
        }
    }
}
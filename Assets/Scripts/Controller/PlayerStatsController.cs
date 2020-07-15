using System;
using System.Collections;
using RootStats.Controllers.FooterButtons;
using RootStats.UI;
using RootStats.UI.Views;
using UnityEngine;

namespace RootStats.Controllers
{
    public class PlayerStatsController : Controller
    {
        public static PlayerStatsController Instance { get; private set; }

        [SerializeField] private View _playerListView;
        [SerializeField] private View _playerInfoView;
        [SerializeField] private Animator _windowAnimator;

        public override IEnumerator Init()
        {
            if (Instance == null)
                Instance = this;
            
            yield return base.Init();
            
            ((PlayerListView) _playerListView).OnClickAction = ShowFactionInfo;
            _playerListView.Init();
            yield return null;

            _playerInfoView.Init();
            yield return null;
            
            var actions = new Action[] {BackToList, ShowCommonInfo, ShowFactionsInfo, ShowOtherPlayersInfo};

            _footerButtonContainer.FillClickActions(actions);
            yield return null;
            
            _footerButtonContainer.Init();
            yield return null;
            
            IsInitialized = true;

            yield return null;
        }
        
        public override void ShowWindow()
        {
            base.ShowWindow();
        }

        public override void HideWindow()
        {
            base.HideWindow();
            
            _footerButtonContainer.Hide();
            _playerListView.Show();
            _playerInfoView.Hide();
            
        }
        
        private void BackToList()
        {
            _footerButtonContainer.Hide();
            _windowAnimator.SetTrigger(((PlayerInfoView) _playerInfoView).GetAnimationTrigger("close"));
        }

        private void ShowFactionInfo()
        {
            _footerButtonContainer.Show();
            _windowAnimator.SetTrigger(((PlayerInfoView) _playerInfoView).GetAnimationTrigger("open"));

            ((PlayersFooter) _footerButtonContainer).DisableButtonsByAction(ShowCommonInfo);

        }

        private void ShowCommonInfo()
        {
            ((PlayersFooter) _footerButtonContainer).DisableButtonsByAction(ShowCommonInfo);

            StartAnimation("common");
        }

        private void ShowFactionsInfo()
        {
            ((PlayersFooter) _footerButtonContainer).DisableButtonsByAction(ShowFactionsInfo);

            StartAnimation("faction");
        }

        private void ShowOtherPlayersInfo()
        {
            ((PlayersFooter) _footerButtonContainer).DisableButtonsByAction(ShowOtherPlayersInfo);

            StartAnimation("player");
        }

        public void StartAnimation(string trigger)
        {
            if (_windowAnimator != null)
                _windowAnimator.SetTrigger(((PlayerInfoView) _playerInfoView).GetAnimationTrigger(trigger));
        }
    }
}
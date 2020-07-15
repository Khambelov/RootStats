using System;
using System.Collections;
using RootStats.Controllers.FooterButtons;
using RootStats.UI;
using RootStats.UI.Views;
using UnityEngine;

namespace RootStats.Controllers
{
    public class FactionStatsController : Controller
    {
        public static FactionStatsController Instance { get; private set; }

        [SerializeField] private View _factionListView;
        [SerializeField] private View _factionInfoView;
        [SerializeField] private Animator _windowAnimator;

        public override IEnumerator Init()
        {
            if (Instance == null)
                Instance = this;

            yield return base.Init();

            ((FactionListView) _factionListView).OnClickAction = ShowFactionInfo;
            _factionListView.Init();
            yield return null;

            _factionInfoView.Init();
            yield return null;

            var actions = new Action[] {BackToList, ShowCommonInfo, ShowOtherFactionsInfo, ShowPlayersInfo};

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
            _factionInfoView.Hide();
            _factionListView.Show();
        }

        private void BackToList()
        {
            _footerButtonContainer.Hide();
            _windowAnimator.SetTrigger(((FactionInfoView) _factionInfoView).GetAnimationTrigger("close"));
        }

        private void ShowFactionInfo()
        {
            _footerButtonContainer.Show();
            _windowAnimator.SetTrigger(((FactionInfoView) _factionInfoView).GetAnimationTrigger("open"));
            
            ((FactionsFooter) _footerButtonContainer).DisableButtonsByAction(ShowCommonInfo);
        }

        private void ShowCommonInfo()
        {
            ((FactionsFooter) _footerButtonContainer).DisableButtonsByAction(ShowCommonInfo);

            StartAnimation("common");
        }

        private void ShowOtherFactionsInfo()
        {
            ((FactionsFooter) _footerButtonContainer).DisableButtonsByAction(ShowOtherFactionsInfo);
            
            StartAnimation("faction");
        }

        private void ShowPlayersInfo()
        {
            ((FactionsFooter) _footerButtonContainer).DisableButtonsByAction(ShowPlayersInfo);

            StartAnimation("player");
        }

        public void StartAnimation(string trigger)
        {
            if (_windowAnimator != null)
                _windowAnimator.SetTrigger(((FactionInfoView) _factionInfoView).GetAnimationTrigger(trigger));
        }
    }
}
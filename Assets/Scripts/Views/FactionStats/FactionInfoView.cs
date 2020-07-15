using UnityEngine;
using UnityEngine.UI;

namespace RootStats.UI.Views
{
    public class FactionInfoView : View
    {
        [SerializeField] private Image _factionPortrait;
        [SerializeField] private TextExtension _factionName;
        [SerializeField] private TextExtension _winrateTitle;
        [SerializeField] private TextExtension _winrateValue;
        [SerializeField] private TextExtension _playCountTitle;
        [SerializeField] private TextExtension _playCountValue;
        
        [SerializeField] private View _commonView;
        [SerializeField] private View _otherStatsView;
        [SerializeField] private View _playersView;

        public override void Init()
        {
            base.Init();
            
            _factionName.Init();
            
            _winrateTitle.Init();
            _winrateValue.Init();
            
            _playCountTitle.Init();
            _playCountValue.Init();

            _commonView.Init();
            _otherStatsView.Init();
            _playersView.Init();
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
            
            transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);

            _commonView.Hide();
            _otherStatsView.Hide();
            _playersView.Hide();
        }

        public string GetAnimationTrigger(string startTrigger)
        {
            switch (startTrigger)
            {
                case "open":
                    return !IsVisible ? "open" : null;
                case "common":
                    return !_commonView.IsVisible ? "common" : null;
                case "faction":
                    return !_otherStatsView.IsVisible ? "faction" : null;
                case "factionInfo":
                {
                    return ((OtherFactionsStats) _otherStatsView).InfoViewIsActive ? "faction" : "factionInfo";
                }
                case "player":
                    return !_playersView.IsVisible ? "player" : null;
                case "close":
                {
                    if (_commonView.IsVisible)
                        return string.Concat(startTrigger, "Common");

                    if (_playersView.IsVisible)
                        return string.Concat(startTrigger, "Player");

                    if (_otherStatsView.IsVisible && ((OtherFactionsStats) _otherStatsView).InfoViewIsActive)
                        return string.Concat(startTrigger, "FactionInfo");

                    return string.Concat(startTrigger, "Faction");
                }
                default:
                    return null;
            }
        }
    }
}
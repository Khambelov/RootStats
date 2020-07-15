using UnityEngine;
using UnityEngine.UI;

namespace RootStats.UI.Table
{
    public class TopPlayerTable : Table
    {
        [SerializeField] private Image[] _playersIcon;

        [SerializeField] private TextExtension _playerCountTitle;

        [SerializeField] private TextExtension[] _winrateElements;
        [SerializeField] private TextExtension[] _playerCountElements;

        public override void Init()
        {
            base.Init();

            _playerCountTitle.Init();

            foreach (var element in _winrateElements)
            {
                element.Init();
            }

            foreach (var element in _playerCountElements)
            {
                element.Init();
            }
        }

        public override void FillData()
        {
            base.FillData();
        }
    }
}
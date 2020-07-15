using System;
using RootStats.UI;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.InputData.Fields
{
    public class PlayerFactionStatsListField : MonoBehaviour
    {
        public Action OnOpenInfoAction { get; set; }

        [SerializeField] private ButtonExtension _openInfoButton;
        [SerializeField] private Image _factionIcon;
        [SerializeField] private TextExtension _factionName;

        public void Init()
        {
            _openInfoButton.OnClickAction = OnOpenInfoAction;
            _openInfoButton.Init();

            _factionName.Init();
        }

        public void FillData()
        {

        }
    }
}
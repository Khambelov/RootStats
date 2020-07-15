using System;
using System.Collections.Generic;
using RootStats.InputData.Fields;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.UI.Views
{
    public class OtherFactionStatsInfo : View
    {
        public Action OnBackToListAction { get; set; }

        [SerializeField] private GameObject _factionElement;
        [SerializeField] private Transform _content;

        [SerializeField] private Image _factionIcon;
        [SerializeField] private TextExtension _factionName;
        [SerializeField] private ButtonExtension _backButton;
        
        private List<CommonStatsField> _commonStatsFields;

        public override void Init()
        {
            base.Init();

            _commonStatsFields = new List<CommonStatsField>();
            
            _factionName.Init();

            _backButton.OnClickAction = OnBackToListAction;
            _backButton.Init();
            
            var obj = Instantiate(_factionElement, _content, false);
            obj.GetComponent<CommonStatsField>().Init();
            
            _commonStatsFields.Add(obj.GetComponent<CommonStatsField>());
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
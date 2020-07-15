using System;
using System.Collections.Generic;
using RootStats.InputData.Fields;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class OtherFactionStatsList : View
    {
        public Action OnOpenInfoAction { get; set; }

        [SerializeField] private GameObject _factionElement;
        [SerializeField] private Transform _content;

        private List<OtherFactionStatsField> _otherFactionStatsFields;

        public override void Init()
        {
            base.Init();

            _otherFactionStatsFields = new List<OtherFactionStatsField>();
            
            var obj = Instantiate(_factionElement, _content, false);
            obj.GetComponent<OtherFactionStatsField>().OnOpenInfoAction = OnOpenInfoAction;
            obj.GetComponent<OtherFactionStatsField>().Init();

            _otherFactionStatsFields.Add(obj.GetComponent<OtherFactionStatsField>());
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
            
            transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
            
            Show();
        }
    }
}
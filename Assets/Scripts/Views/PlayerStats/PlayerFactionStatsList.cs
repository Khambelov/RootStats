using System;
using System.Collections.Generic;
using RootStats.InputData.Fields;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class PlayerFactionStatsList: View
    {
        public Action OnOpenInfoAction { get; set; }

        [SerializeField] private GameObject _factionElement;
        [SerializeField] private Transform _content;

        private List<PlayerFactionStatsListField> _otherFactionStatsFields;

        public override void Init()
        {
            base.Init();

            _otherFactionStatsFields = new List<PlayerFactionStatsListField>();
            
            var obj = Instantiate(_factionElement, _content, false);
            obj.GetComponent<PlayerFactionStatsListField>().OnOpenInfoAction = OnOpenInfoAction;
            obj.GetComponent<PlayerFactionStatsListField>().Init();

            _otherFactionStatsFields.Add(obj.GetComponent<PlayerFactionStatsListField>());
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
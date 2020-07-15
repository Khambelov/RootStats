using System.Collections.Generic;
using RootStats.InputData.Fields;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class FactionCommonStats : View
    {
        [SerializeField] private GameObject _commonElement;
        [SerializeField] private Transform _content;

        private List<CommonStatsField> _commonStatsFields;
        
        public override void Init()
        {
            base.Init();

            _commonStatsFields = new List<CommonStatsField>();
            
            var obj = Instantiate(_commonElement, _content, false);
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
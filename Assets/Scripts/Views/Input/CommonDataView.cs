using System.Collections.Generic;
using RootStats.Controllers;
using RootStats.InputData;
using RootStats.InputData.Fields;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class CommonDataView : View
    {
        [SerializeField] private GameObject _inputDataPrefab;
        [SerializeField] private Transform _content;

        private List<CommonInputData> _commonInputDatas;
        
        public override void Init()
        {
            base.Init();
            
            _commonInputDatas = new List<CommonInputData>();

            foreach (var commonInputData in _commonInputDatas)
            {
                commonInputData.Init(InputDataType.Toggle);
            }
            
            InputController.Instance.AddViewInOrder(this);
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }
    }
}
using System.Collections.Generic;
using RootStats.Controllers;
using RootStats.InputData;
using RootStats.InputData.Fields;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.UI.Views
{
    public class FactionView : View
    {
        [SerializeField] private GameObject _inputDataPrefab;
        [SerializeField] private Transform _content;

        [SerializeField] private Image _icon;
        [SerializeField] private TextExtension _name;

        private List<FactionInputData>_factionInputDatas;
        
        public override void Init()
        {
            base.Init();

            _factionInputDatas = new List<FactionInputData>();
            
            foreach (var factionInputData in _factionInputDatas)
            {
                factionInputData.Init(InputDataType.Toggle);
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

        private void OnDestroy()
        {
            InputController.Instance.RemoveViewInOrder(this);
        }
    }
}
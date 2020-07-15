using System.Collections.Generic;
using System.Linq;
using RootStats.Controllers;
using RootStats.InputData;
using RootStats.InputData.Fields;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class PlayerDataView : View
    {
        [SerializeField] private GameObject _inputDataPrefab;
        [SerializeField] private Transform _content;
        
        private List<PlayerInputData> _playerInputDatas;

        public int GetActiveFactions => _playerInputDatas.Count(p => p.isActive);
        
        public override void Init()
        {
            base.Init();

            _playerInputDatas = new List<PlayerInputData>();

            var obj = Instantiate(_inputDataPrefab, _content, false);
            _playerInputDatas.Add(obj.GetComponent<PlayerInputData>());
            
            foreach (var playerInputData in _playerInputDatas)
            {
                playerInputData.Init();
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
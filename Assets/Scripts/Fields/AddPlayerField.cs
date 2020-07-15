using System;
using RootStats.UI;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.InputData.Fields
{
    public class AddPlayerField : MonoBehaviour
    {
        [SerializeField] private ButtonExtension _chooseButton;
        [SerializeField] private Image _border;

        public Action<AddPlayerField> OnChooseAction { get; set; }

        private bool _isChoose;

        public bool IsChoose
        {
            get => _isChoose;
            set
            {
                _isChoose = value;
                _border.color = _isChoose ? Color.red : Color.black;
            }
        }

        public void Init()
        {
            _isChoose = false;

            _chooseButton.OnClickAction = Choose;

            _chooseButton.Init();
        }

        private void Choose()
        {
            OnChooseAction?.Invoke(this);
        }

        public void GetPlayerInfo()
        {
        }
    }
}
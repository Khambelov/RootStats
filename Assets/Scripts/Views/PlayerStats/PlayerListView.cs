using System;
using System.Collections;
using RootStats.Controllers;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class PlayerListView : View
    {
        public Action OnClickAction { get; set; }

        [SerializeField] private ButtonExtension _addPlayerButton;

        [SerializeField] private GameObject _playerElement;
        [SerializeField] private Transform _content;

        public override void Init()
        {
            base.Init();

            _addPlayerButton.OnClickAction = AddPlayer;
            _addPlayerButton.Init();

            var obj = Instantiate(_playerElement, _content, false);
            obj.GetComponent<ButtonExtension>().OnClickAction = OnClickAction;
            obj.GetComponent<ButtonExtension>().Init();
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

        private void AddPlayer()
        {
            DialogsController.Instance.OpenAddPlayerDialog();

            StartCoroutine(WaitAddPlayer());
        }

        private IEnumerator WaitAddPlayer()
        {
            while (DialogsController.Instance.DialogIsVisible(typeof(PlayerDialog)))
            {
                yield return null;
            }

            var obj = Instantiate(_playerElement, _content, false);
            obj.GetComponent<ButtonExtension>().OnClickAction = OnClickAction;
            obj.GetComponent<ButtonExtension>().Init();
        }
    }
}

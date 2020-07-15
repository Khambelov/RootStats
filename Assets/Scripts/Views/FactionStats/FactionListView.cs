using System;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class FactionListView : View
    {
        public Action OnClickAction { get; set; }

        [SerializeField] private GameObject _factionElement;
        [SerializeField] private Transform _content;

        public override void Init()
        {
            base.Init();

            var obj = Instantiate(_factionElement, _content, false);
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
    }
}
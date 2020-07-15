using System.Collections;
using RootStats.Controllers.FooterButtons;
using RootStats.UI.Views;
using UnityEngine;

namespace RootStats.Controllers
{
    public class Controller : MonoBehaviour
    {
        public bool IsInitialized { get; protected set; }

        [SerializeField] private GameObject _window;
        [SerializeField] protected FooterButtonContainer _footerButtonContainer;

        public virtual IEnumerator Init()
        {
            yield return null;
        }

        public virtual void ShowWindow()
        {
            _window.SetActive(true);
        }

        public virtual void HideWindow()
        {
            _window.SetActive(false);
        }
    }
}
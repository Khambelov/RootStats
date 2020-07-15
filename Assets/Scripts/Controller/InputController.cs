using System;
using System.Collections;
using System.Linq;
using Boo.Lang;
using RootStats.Controllers.FooterButtons;
using RootStats.InputData.Fields;
using RootStats.UI.Views;
using UnityEngine;

namespace RootStats.Controllers
{
    public class InputController : Controller
    {
        public static InputController Instance { get; private set; }

        [SerializeField] private View[] _DataViews;

        private List<View> _viewsOrder;

        private readonly WaitForSeconds _delay = new WaitForSeconds(0.001f);
        private readonly float _animationSpeed = (float) Math.Round((0 + 594.21) / 25, 2);

        public AddPlayerField _inputPlayer;

        public override IEnumerator Init()
        {
            if (Instance == null)
                Instance = this;

            yield return base.Init();

            _viewsOrder = new List<View>();

            foreach (var dataView in _DataViews)
            {
                dataView.Init();
                yield return null;
            }

            var actions = new Action[] {ShowPrevInputView, SaveData, ShowNextInputView};

            _footerButtonContainer.FillClickActions(actions);
            yield return null;

            _footerButtonContainer.Init();
            yield return null;

            IsInitialized = true;

            yield return null;
        }
        
        public override void ShowWindow()
        {
            base.ShowWindow();
            
            _footerButtonContainer.Show();
        }

        public override void HideWindow()
        {
            base.HideWindow();
            
            _footerButtonContainer.Hide();
        }

        public View GetViewByType(Type type)
        {
            return _DataViews.SingleOrDefault(v => v.GetType() == type);
        }

        public void AddViewInOrder(View view)
        {
            _viewsOrder.Add(view);

            //_viewsOrder.Sort();
        }

        public void RemoveViewInOrder(View view)
        {
            _viewsOrder.Remove(view);

            //_viewsOrder.Sort();
        }

        private void ShowPrevInputView()
        {
            int currentViewIndex = _viewsOrder.IndexOf(v => v.IsVisible);

            if (currentViewIndex > 0)
            {
                int nextViewIndex = _viewsOrder.IndexOf(v => v.IsVisible) - 1;

                Transform currentViewTransform = _viewsOrder[currentViewIndex].transform;
                Transform nextViewTransform = _viewsOrder[nextViewIndex].transform;

                ((InputFooter) _footerButtonContainer).DisableAllButtons();

                _viewsOrder[currentViewIndex].Show();
                currentViewTransform.localPosition = new Vector3(0f, 0f, 0f);

                _viewsOrder[nextViewIndex].Show();
                nextViewTransform.localPosition = new Vector3(-594.21f, 0f, 0f);

                StartCoroutine(SwapWindows(currentViewTransform, nextViewTransform, false));
            }
            else
            {
                ((InputFooter) _footerButtonContainer).UpdateEnableButtons(currentViewIndex > 0, CanSaveData(),
                    SaveData, currentViewIndex < _viewsOrder.Count - 1);
            }
        }

        private void ShowNextInputView()
        {
            int currentViewIndex = _viewsOrder.IndexOf(v => v.IsVisible);

            if (currentViewIndex < _viewsOrder.Count - 1)
            {
                int nextViewIndex = _viewsOrder.IndexOf(v => v.IsVisible) + 1;

                Transform currentViewTransform = _viewsOrder[currentViewIndex].transform;
                Transform nextViewTransform = _viewsOrder[nextViewIndex].transform;

                if (nextViewTransform.GetComponent<View>() is FactionView)
                {
                    _DataViews.FirstOrDefault(v => v.GetType() == typeof(FactionsDataView))?.Show();
                }

                ((InputFooter) _footerButtonContainer).DisableAllButtons();

                _viewsOrder[currentViewIndex].Show();
                currentViewTransform.localPosition = new Vector3(0f, 0f, 0f);

                _viewsOrder[nextViewIndex].Show();
                nextViewTransform.localPosition = new Vector3(594.21f, 0f, 0f);

                StartCoroutine(SwapWindows(currentViewTransform, nextViewTransform, true));
            }
            else
            {
                ((InputFooter) _footerButtonContainer).UpdateEnableButtons(currentViewIndex > 0, CanSaveData(),
                    SaveData, currentViewIndex < _viewsOrder.Count - 1);
            }
        }

        private bool CanSaveData()
        {
            return true;
        }

        private void SaveData()
        {
        }

        private IEnumerator SwapWindows(Transform currentView, Transform nextView, bool next)
        {
            float speed = _animationSpeed * (next ? -1f : +1f);

            while ((next && nextView.localPosition.x > 0f) || (!next && nextView.localPosition.x < 0f))
            {
                currentView.localPosition = new Vector3(currentView.localPosition.x + speed, 0f, 0f);
                nextView.localPosition = new Vector3(nextView.localPosition.x + speed, 0f, 0f);

                yield return _delay;
            }

            currentView.GetComponent<View>().Hide();
            currentView.localPosition = new Vector3(0f, 0f, 0f);
            nextView.localPosition = new Vector3(0f, 0f, 0f);

            if (currentView.GetComponent<View>() is FactionView && !(nextView.GetComponent<View>() is FactionView))
            {
                _DataViews.FirstOrDefault(v => v.GetType() == typeof(FactionsDataView))?.Hide();
            }

            yield return null;

            var openViewIndex = _viewsOrder.IndexOf(v => v.IsVisible);

            ((InputFooter) _footerButtonContainer).UpdateEnableButtons(openViewIndex > 0, CanSaveData(),
                SaveData, openViewIndex < _viewsOrder.Count - 1);
            yield return null;
        }
    }
}
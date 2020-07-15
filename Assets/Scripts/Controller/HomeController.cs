using System;
using System.Collections;
using System.Collections.Generic;
using RootStats.UI;
using RootStats.UI.Views;
using UnityEngine;

namespace RootStats.Controllers
{
    public class HomeController : Controller
    {
        public static HomeController Instance { get; private set; }

        [SerializeField] private View[] _homeViews;
        [SerializeField] private Animator _windowAnimator; //TODO: Переделать анимацию в окне Home!

        private int _currentOpenWindow;

        public override IEnumerator Init()
        {
            if (Instance == null)
                Instance = this;

            yield return base.Init();

            foreach (var view in _homeViews)
            {
                view.Init();

                if (view.GetType() == typeof(HomeFactionListView))
                    view.Show();
                else
                    view.Hide();

                yield return null;
            }

            var actions = new Action[_footerButtonContainer.ButtonsCount];

            for (int i = 0; i < actions.Length; i++)
            {
                var window = i + 1;
                actions[i] = () => OpenWindow(window);

                yield return null;
            }

            _footerButtonContainer.FillClickActions(actions);
            yield return null;

            _footerButtonContainer.Init();
            yield return null;

            _currentOpenWindow = 1;

            _footerButtonContainer.DisableButton(_currentOpenWindow - 1);

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

        private void OpenWindow(int openingWindow)
        {
            _footerButtonContainer.DisableButton(openingWindow - 1);

            _windowAnimator.SetInteger("W", openingWindow);

            _windowAnimator.SetTrigger(openingWindow > _currentOpenWindow ? "R" : "L");

            _currentOpenWindow = openingWindow;
        }
    }
}
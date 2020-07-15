using System;
using System.Collections;
using RootStats.InputData.Fields;
using RootStats.UI.Views;
using UnityEngine;

namespace RootStats.Controllers
{
    public class DialogsController : Controller
    {
        public static DialogsController Instance { get; private set; }

        [SerializeField] private DialogView[] _dialogViews;
        
        public override IEnumerator Init()
        {
            if (Instance == null)
                Instance = this;

            yield return base.Init();

            foreach (var dialogView in _dialogViews)
            {
                dialogView.Init();
            }

            IsInitialized = true;

            yield return null;
        }

        public override void HideWindow()
        {
            base.HideWindow();

            foreach (var dialogView in _dialogViews)
            {
                dialogView.Hide();
            }
        }

        public bool DialogIsVisible(Type dialogType)
        {
            return Array.Find(_dialogViews, v => v.GetType() == dialogType).IsVisible;
        }

        public void OpenAddPlayerDialog(bool returnPlayer = false)
        {
            base.ShowWindow();

            var playerDialog = (PlayerDialog) Array.Find(_dialogViews, d => d.GetType() == typeof(PlayerDialog));
            playerDialog.Show(false, returnPlayer);
        }

        public void OpenEditPlayerDialog()
        {
            base.ShowWindow();

            var playerDialog = (PlayerDialog) Array.Find(_dialogViews, d => d.GetType() == typeof(PlayerDialog));
            playerDialog.Show(true, false);
        }

        public void OpenSettingDialog()
        {
            base.ShowWindow();

            Array.Find(_dialogViews, d => d.GetType() == typeof(SettingDialog)).Show();
        }

        public void OpenChoosePlayerDialog()
        {
            base.ShowWindow();
            
            Array.Find(_dialogViews, d => d.GetType() == typeof(ChoosePlayerDialog)).Show();
        }

        public void AddNewPlayer(AddPlayerField newPlayer)
        {
            var dialog = (ChoosePlayerDialog)Array.Find(_dialogViews, d => d.GetType() == typeof(ChoosePlayerDialog));
            dialog.SetChoosePlayer(newPlayer);
        }
    }
}
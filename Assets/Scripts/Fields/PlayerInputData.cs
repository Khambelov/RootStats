using System.Collections;
using RootStats.Controllers;
using RootStats.UI;
using RootStats.UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.InputData.Fields
{
    public class PlayerInputData : MonoBehaviour
    {
        [SerializeField] private bool _isAvailable = true;
        [SerializeField] private ToggleExtension _factionActivate;
        [SerializeField] private Image _userPhoto;
        [SerializeField] private TextExtension _userName;
        [SerializeField] private ButtonExtension _userSelectButton;
        [SerializeField] private ToggleExtension _winSelect;
        [SerializeField] private ToggleExtension _winByVPSelect;
        [SerializeField] private InputFieldExtension _victoryPoint;
        [SerializeField] private TextExtension _victoryPointLabel;
        [SerializeField] private GameObject _unavailableWindow;

        public bool isActive { get; private set; }

        public void Init()
        {
            _factionActivate.OnValueChangeAction = ActivatePlayerData;
            _userSelectButton.OnClickAction = () => { StartCoroutine(SetPlayer()); };
            _winSelect.OnValueChangeAction = SetWinStatus;
            _winByVPSelect.OnValueChangeAction = SetVPWinStatus;
            _victoryPoint.OnSubmitEvent = SetVictoryPoint;

            _userName.Init();
            _factionActivate.Init();
            _userSelectButton.Init();
            _winSelect.Init();
            _winByVPSelect.Init();
            _victoryPoint.Init();
            _victoryPointLabel.Init();

            if (!_isAvailable)
            {
                _unavailableWindow.SetActive(true);
            }

            _userSelectButton.gameObject.SetActive(false);
            _winSelect.gameObject.SetActive(false);
            _winByVPSelect.gameObject.SetActive(false);
            _victoryPoint.gameObject.SetActive(false);
            _victoryPointLabel.gameObject.SetActive(false);

            _factionActivate.IsOn = isActive = false;
        }

        private void ActivatePlayerData(bool active)
        {
            isActive = active;

            _userSelectButton.gameObject.SetActive(active);
            _winSelect.gameObject.SetActive(active);
            _winByVPSelect.gameObject.SetActive(active);
            _victoryPoint.gameObject.SetActive(active);
            _victoryPointLabel.gameObject.SetActive(active);

            var startFaction = (Image) _factionActivate.targetGraphic;
            startFaction.color = new Color(1f, 1f, 1f, active ? 1f : 0.5f);

            var dataView = (FactionsDataView) InputController.Instance.GetViewByType(typeof(FactionsDataView));
            dataView.SetFactionView(active);
        }

        private void SetWinStatus(bool isWin)
        {
        }

        private void SetVPWinStatus(bool isVP)
        {
            _victoryPoint.interactable = isVP;
            _victoryPoint.ClearText();
        }

        private void SetVictoryPoint(string victoryPoints)
        {
            Debug.Log(victoryPoints);
        }

        private IEnumerator SetPlayer()
        {
            DialogsController.Instance.OpenChoosePlayerDialog();

            while (InputController.Instance._inputPlayer == null)
            {
                yield return null;
            }

//            _userPhoto.sprite = null;
//            _userName.text = null;
        }
    }
}
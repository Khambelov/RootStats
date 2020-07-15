using RootStats.Controllers;
using RootStats.InputData.Fields;
using UnityEngine;

namespace RootStats.UI.Views
{
    public class PlayerDialog : DialogView
    {
        [SerializeField] private TextExtension _title;
        [SerializeField] private TextExtension _photoTitle;
        [SerializeField] private TextExtension _nameTitle;

        [SerializeField] private InputFieldExtension _nameEdit;
        [SerializeField] private ButtonExtension _photoEmptyEdit;
        [SerializeField] private ButtonExtension _photoEdit;
        
        [SerializeField] private ButtonExtension _closeButton;
        [SerializeField] private ButtonExtension _accessButton;

        private bool _needReturnPlayer;
        
        public override void Init()
        {
            base.Init();

            _title.Init();
            _photoTitle.Init();
            _nameTitle.Init();
            
            _nameEdit.Init();

            _photoEmptyEdit.OnClickAction = SetPlayerPhoto;
            _photoEmptyEdit.Init();

            _photoEdit.OnClickAction = SetPlayerPhoto;
            _photoEdit.Init();
            
            _closeButton.OnClickAction = Close;
            _closeButton.Init();
        }

        public void Show(bool isEdit, bool returnPlayer)
        {
            base.Show();

            if (isEdit)
            {
                _title.text = "Изменить данные игрока";

                _accessButton.OnClickAction = EditPlayer;
                _accessButton.Init();
                _accessButton.SetButtonText("Изменить");
            }
            else
            {
                _title.text = "Добавить игрока";
                
                _accessButton.OnClickAction = AddPlayer;
                _accessButton.Init();
                _accessButton.SetButtonText("Добавить");

                _needReturnPlayer = returnPlayer;
            }

            //TODO: сделать проверку на пустое фото
            if (true)
            {
                _photoEmptyEdit.gameObject.SetActive(true);
                _photoEdit.gameObject.SetActive(false);
            }
            else
            {
                _photoEmptyEdit.gameObject.SetActive(false);
                _photoEdit.gameObject.SetActive(true);
            }
        }

        private void SetPlayerPhoto()
        {
        }

        private void EditPlayer()
        {
        }

        private void AddPlayer()
        {
            if (_needReturnPlayer)
            {
                DialogsController.Instance.AddNewPlayer(new AddPlayerField());
            }
            
            Close();
        }

        private void Close()
        {
            if(_needReturnPlayer)
                Hide();
            else
                DialogsController.Instance.HideWindow();
        }
    }
}
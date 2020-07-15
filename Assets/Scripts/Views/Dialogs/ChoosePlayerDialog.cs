using System.Collections;
using System.Collections.Generic;
using RootStats.Controllers;
using RootStats.InputData.Fields;
using RootStats.UI;
using RootStats.UI.Views;
using UnityEngine;

public class ChoosePlayerDialog : DialogView
{
    [SerializeField] private GameObject _chooseElement;
    [SerializeField] private Transform _content;

    [SerializeField] private TextExtension _title;
    [SerializeField] private TextExtension _findNameTitle;
    [SerializeField] private InputFieldExtension _findNameField;

    [SerializeField] private ButtonExtension _addNewPlayerButton;
    [SerializeField] private ButtonExtension _closeButton;
    [SerializeField] private ButtonExtension _addPlayerButton;

    private List<AddPlayerField> _addPlayerFields;

    private AddPlayerField _choosePlayer;

    public override void Init()
    {
        base.Init();

        _addPlayerFields = new List<AddPlayerField>();

        _title.Init();
        _findNameTitle.Init();
        _findNameField.Init();


        _addNewPlayerButton.OnClickAction = AddNewPlayer;
        _addNewPlayerButton.Init();

        _closeButton.OnClickAction = DialogsController.Instance.HideWindow;
        _closeButton.Init();

        _addPlayerButton.OnClickAction = AddChoosePlayer;
        _addPlayerButton.Init();

        var obj = Instantiate(_chooseElement, _content, false);
        obj.GetComponent<AddPlayerField>().Init();
        obj.GetComponent<AddPlayerField>().OnChooseAction = ChoosePlayer;
        _addPlayerFields.Add(obj.GetComponent<AddPlayerField>());

        obj = Instantiate(_chooseElement, _content, false);
        obj.GetComponent<AddPlayerField>().Init();
        obj.GetComponent<AddPlayerField>().OnChooseAction = ChoosePlayer;
        _addPlayerFields.Add(obj.GetComponent<AddPlayerField>());
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }

    public void SetChoosePlayer(AddPlayerField newPlayer)
    {
        if(_addPlayerFields.Contains(newPlayer)) return;

        _choosePlayer = newPlayer;
    }

    private void ChoosePlayer(AddPlayerField playerField)
    {
        foreach (var addPlayerField in _addPlayerFields)
        {
            addPlayerField.IsChoose = addPlayerField == playerField;

            if (addPlayerField.IsChoose)
                _choosePlayer = addPlayerField;
        }
    }

    private void AddChoosePlayer()
    {
        DialogsController.Instance.HideWindow();

        InputController.Instance._inputPlayer = _choosePlayer;
        _choosePlayer = null;
    }

    private void AddNewPlayer()
    {
        DialogsController.Instance.OpenAddPlayerDialog(true);

        StartCoroutine(WaitAddPlayer());
    }

    private IEnumerator WaitAddPlayer()
    { 
        while (DialogsController.Instance.DialogIsVisible(typeof(PlayerDialog)))
        {
            yield return null;
        }
        
        AddChoosePlayer();

        yield return null;
    }
}
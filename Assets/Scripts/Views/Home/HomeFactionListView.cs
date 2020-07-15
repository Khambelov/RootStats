using RootStats.InputData.Fields;
using RootStats.UI.Views;
using UnityEngine;

public class HomeFactionListView : View
{
    [SerializeField] private GameObject _userElement;
    [SerializeField] private Transform _content;

    [SerializeField] private Color _firstPlace;
    [SerializeField] private Color _secondPlace;
    [SerializeField] private Color _thirdPlace;

    public override void Init()
    {
        base.Init();

        var obj = Instantiate(_userElement, _content, false);
        obj.GetComponent<HomeFactionField>().Init();
        obj.GetComponent<HomeFactionField>().SetChamp(_firstPlace);

        obj = Instantiate(_userElement, _content, false);
        obj.GetComponent<HomeFactionField>().Init();
        obj.GetComponent<HomeFactionField>().SetChamp(_secondPlace);

        obj = Instantiate(_userElement, _content, false);
        obj.GetComponent<HomeFactionField>().Init();
        obj.GetComponent<HomeFactionField>().SetChamp(_thirdPlace);
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
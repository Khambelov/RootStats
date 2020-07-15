using RootStats.InputData.Fields;
using RootStats.UI;
using RootStats.UI.Views;
using UnityEngine;

public class HomeTimeListView : View
{
    [SerializeField] private ButtonExtension _factionButton;
    [SerializeField] private ButtonExtension _playerButton;

    [SerializeField] private ButtonExtension _weekButton;
    [SerializeField] private ButtonExtension _monthButton;

    [SerializeField] private HomeTimeUser[] _homeTimeUsers;

    private bool _showPlayer;
    private bool _monthTime;

    public override void Init()
    {
        base.Init();

        _showPlayer = false;
        _monthTime = false;

        _factionButton.OnClickAction = () => SwitchChampType(false);
        _factionButton.Init();

        _playerButton.OnClickAction = () => SwitchChampType(true);
        _playerButton.Init();

        _weekButton.OnClickAction = () => SwitchChampTime(false);
        _weekButton.Init();

        _monthButton.OnClickAction = () => SwitchChampTime(true);
        _monthButton.Init();

        SwitchChampType(false);
        SwitchChampTime(false);
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void SwitchChampType(bool showPlayer)
    {
        _showPlayer = showPlayer;

        _factionButton.interactable = _showPlayer;
        _playerButton.interactable = !_showPlayer;

        foreach (var user in _homeTimeUsers)
        {
            user.UpdateUserInfo(_showPlayer, _monthTime);
        }
    }

    private void SwitchChampTime(bool monthTime)
    {
        _monthTime = monthTime;

        _weekButton.interactable = _monthTime;
        _monthButton.interactable = !_monthTime;

        foreach (var user in _homeTimeUsers)
        {
            user.UpdateUserInfo(_showPlayer, _monthTime);
        }
    }
}
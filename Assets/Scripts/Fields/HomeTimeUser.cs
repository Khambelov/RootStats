using RootStats.UI;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.InputData.Fields
{
    public class HomeTimeUser : MonoBehaviour
    {
        [SerializeField] private int _place;
        [SerializeField] private Image _userPhoto;
        [SerializeField] private TextExtension _userName;
        [SerializeField] private TextExtension _userWinrate;


        public void UpdateUserInfo(bool isPlayer, bool isMonth)
        {

        }
    }
}
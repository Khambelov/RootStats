using RootStats.UI;
using UnityEngine;
using UnityEngine.UI;

namespace RootStats.InputData.Fields
{
    public class HomeUserField : MonoBehaviour
    {
        [SerializeField] private TextExtension _name;
        [SerializeField] private TextExtension _winrate;
        [SerializeField] private Image _cup;
        [SerializeField] private Image _photo;

        public void Init()
        {
            _name.Init();
            _winrate.Init();

            _cup.gameObject.SetActive(false);
        }

        public void FillData()
        {
        }

        public void SetChamp(Color placeColor)
        {
            _cup.gameObject.SetActive(true);
            _cup.color = placeColor;
        }
    }
}

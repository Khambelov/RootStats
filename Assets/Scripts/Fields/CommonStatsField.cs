using RootStats.UI;
using UnityEngine;

namespace RootStats.InputData.Fields
{
    public class CommonStatsField : MonoBehaviour
    {
        [SerializeField] private TextExtension _statsName;
        [SerializeField] private TextExtension _statsValue;

        public void Init()
        {
            _statsName.Init();
            _statsValue.Init();
        }

        public void FillData()
        {

        }
    }
}
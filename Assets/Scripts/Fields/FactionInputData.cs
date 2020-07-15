using RootStats.UI;
using UnityEngine;

namespace RootStats.InputData.Fields
{
    public class FactionInputData : MonoBehaviour
    {
        [SerializeField] private TextExtension _dataName;
        [SerializeField] private ToggleExtension _toggle;
        [SerializeField] private InputFieldExtension _inputField;
        [SerializeField] private DropdownExtension _dropdown;

        public void Init(InputDataType inputDataType)
        {
            _dataName.Init();
            _toggle.Init();
            _inputField.Init();
            _dropdown.Init();

            _dataName.text = "Data name";

            _toggle.gameObject.SetActive(inputDataType == InputDataType.Toggle);
            _inputField.gameObject.SetActive(inputDataType == InputDataType.InputField);
            _dropdown.gameObject.SetActive(inputDataType == InputDataType.Dropdown);
        }
    }
}
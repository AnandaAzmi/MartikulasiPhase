using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.VersionControl;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private Button sumbit;
    private void Start()
    {
        sumbit.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        displayText.text = inputField.text;
        displayText.fontSize += 1;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class TMPInputFieldDetection : MonoBehaviour, IPointerClickHandler
{
    private TMP_InputField myselfInputField;
    private OpenVirtualKeyboard keyboardController;

    private void Awake()
    {
        myselfInputField = GetComponent<TMP_InputField>();
        keyboardController = GameObject.Find("Virtual Keyboard Controller")
                                       .GetComponent<OpenVirtualKeyboard>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Register this field as the active target
        GetInputFieldTarget.SelectInputFieldName = transform.name;
        GetInputFieldTarget.Index = myselfInputField.caretPosition;

        // Show keyboard
        keyboardController.onExitKeyboardArea = false;
        keyboardController.OnOpenVirtualKeyboard();

        Debug.Log("Active TMP_InputField = " + transform.name);
    }
}

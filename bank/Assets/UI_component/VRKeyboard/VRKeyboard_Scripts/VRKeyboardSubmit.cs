using UnityEngine;
using TMPro;

public class VRKeyboardSubmit : MonoBehaviour
{
    public void OnSubmit()
    {
        if (string.IsNullOrEmpty(GetInputFieldTarget.SelectInputFieldName))
            return;

        GameObject targetObj = GameObject.Find(GetInputFieldTarget.SelectInputFieldName);
        if (targetObj == null) return;

        TMP_InputField targetField = targetObj.GetComponent<TMP_InputField>();
        if (targetField == null) return;

        Debug.Log("Submitted value: " + targetField.text);

        // Hide keyboard
        OpenVirtualKeyboard keyboard = GameObject.Find("Virtual Keyboard Controller")
                                                 .GetComponent<OpenVirtualKeyboard>();
        keyboard.OnCloseVirtualKeyboard();
    }
}

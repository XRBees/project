using UnityEngine;
using TMPro;

public class VRKeyboardKey : MonoBehaviour
{
    public string keyValue = "A"; // set this in Inspector for each key

    public void OnKeyPress()
    {
        if (string.IsNullOrEmpty(GetInputFieldTarget.SelectInputFieldName))
            return;

        GameObject targetObj = GameObject.Find(GetInputFieldTarget.SelectInputFieldName);
        if (targetObj == null) return;

        TMP_InputField targetField = targetObj.GetComponent<TMP_InputField>();
        if (targetField == null) return;

        int insertIndex = GetInputFieldTarget.Index;
        targetField.text = targetField.text.Insert(insertIndex, keyValue);
        targetField.caretPosition = insertIndex + keyValue.Length;

        GetInputFieldTarget.Index = targetField.caretPosition;
    }
}

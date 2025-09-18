using UnityEngine;
using TMPro;

public class VRKeyboardBackspace : MonoBehaviour
{
    public void OnBackspace()
    {
        if (string.IsNullOrEmpty(GetInputFieldTarget.SelectInputFieldName))
            return;

        GameObject targetObj = GameObject.Find(GetInputFieldTarget.SelectInputFieldName);
        if (targetObj == null) return;

        TMP_InputField targetField = targetObj.GetComponent<TMP_InputField>();
        if (targetField == null) return;

        if (targetField.text.Length > 0 && GetInputFieldTarget.Index > 0)
        {
            int caret = Mathf.Max(0, GetInputFieldTarget.Index - 1);
            targetField.text = targetField.text.Remove(caret, 1);
            targetField.caretPosition = caret;
            GetInputFieldTarget.Index = caret;
        }
    }
}

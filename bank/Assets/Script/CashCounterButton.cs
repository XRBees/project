using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CashCounterButton : MonoBehaviour
{
    public Button submitButton;
    public TextMeshProUGUI resultText;
    public GameObject thumbsUpIcon;

    private void Start()
    {
        if (thumbsUpIcon != null)
            thumbsUpIcon.SetActive(false);
    }

    // 👇 This must be public + no parameters
    public void OnSubmit()
    {
        if (PlayerManager.Instance.HasChalan())
        {
            resultText.text = "✅ Transaction successful!";
            if (thumbsUpIcon != null)
                thumbsUpIcon.SetActive(true);
        }
        else
        {
            resultText.text = "⚠️ You need a chalan first!";
            if (thumbsUpIcon != null)
                thumbsUpIcon.SetActive(false);
        }
    }
}

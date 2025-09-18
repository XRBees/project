// ChalanCounter.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChalanCounter : MonoBehaviour
{
    public Button collectButton;
    public TextMeshProUGUI messageText;


    private void Start()
    {
        collectButton.onClick.AddListener(CollectChalan);
    }


    public void CollectChalan()
    {
        if (PlayerManager.Instance == null) return;
        PlayerManager.Instance.GiveChalan();
        if (messageText != null) messageText.text = "Chalan collected. Go to cash counter.";
    }
}
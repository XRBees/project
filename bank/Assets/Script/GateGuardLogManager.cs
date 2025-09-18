using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class LogEntry
{
    public string playerName;
    public string dateTime;
    public string type; // "IN" or "OUT"
}

[System.Serializable]
public class LogData
{
    public List<LogEntry> entries = new List<LogEntry>();
}

public class GateGuardLogManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button punchInButton;
    public Button punchOutButton;
    public Button viewLogsButton;

    public Transform logsContent; // Content area of ScrollView
    public GameObject logLinePrefab; // prefab with a TextMeshProUGUI child
    public TextMeshProUGUI messageText;

    private LogData logData = new LogData();
    private const string PREFS_KEY = "GateLogs";

    private void Start()
    {
        LoadLogs();
        punchInButton.onClick.AddListener(PunchIn);
        punchOutButton.onClick.AddListener(PunchOut);
        viewLogsButton.onClick.AddListener(ShowLogs);
    }

    public void PunchIn()
    {
        string name = nameInput.text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            messageText.text = "Please enter a name.";
            return;
        }

        PlayerManager.Instance.SetName(name);
        AddLog(name, "IN");
        messageText.text = $"Punch In recorded: {name}";
    }

    public void PunchOut()
    {
        string name = nameInput.text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            messageText.text = "Please enter a name.";
            return;
        }

        PlayerManager.Instance.SetName(name);
        AddLog(name, "OUT");
        messageText.text = $"Punch Out recorded: {name}";
    }

    private void AddLog(string name, string type)
    {
        LogEntry e = new LogEntry
        {
            playerName = name,
            dateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            type = type
        };
        logData.entries.Add(e);
        SaveLogs();
    }

    private void SaveLogs()
    {
        string json = JsonUtility.ToJson(logData);
        PlayerPrefs.SetString(PREFS_KEY, json);
        PlayerPrefs.Save();
    }

    private void LoadLogs()
    {
        if (PlayerPrefs.HasKey(PREFS_KEY))
        {
            string json = PlayerPrefs.GetString(PREFS_KEY);
            logData = JsonUtility.FromJson<LogData>(json);
        }
    }

    public void ShowLogs()
    {
        // clear existing
        foreach (Transform t in logsContent) Destroy(t.gameObject);

        foreach (var e in logData.entries)
        {
            GameObject go = Instantiate(logLinePrefab, logsContent);
            var txt = go.GetComponentInChildren<TextMeshProUGUI>();
            if (txt != null)
                txt.text = $"{e.dateTime} - {e.playerName} - {e.type}";
        }
    }
}

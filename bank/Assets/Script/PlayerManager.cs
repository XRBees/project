using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private string playerName = "";
    private bool hasChalan = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Name handling
    public void SetName(string name) => playerName = name;
    public string GetName() => playerName;

    // --- Chalan handling ---
    public void CollectChalan() => hasChalan = true;

    // Alias (optional) so old code still works
    public void GiveChalan() => CollectChalan();

    public bool HasChalan() => hasChalan;

    public void ResetChalan() => hasChalan = false;
}

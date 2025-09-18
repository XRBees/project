using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Call this to load a scene by name
    public void LoadSceneByName(string Bank)
    {
        SceneManager.LoadScene(Bank);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        Debug.Log("Button pressed");
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

    }
}
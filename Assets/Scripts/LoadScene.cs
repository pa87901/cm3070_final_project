using UnityEngine;
using UnityEngine.SceneManagement;

// Load scene using name, or reload the active scene.
public class LoadScene : MonoBehaviour
{
    public void LoadSceneUsingName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

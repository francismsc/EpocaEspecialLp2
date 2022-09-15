using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    /// <summary>
    /// Changes the current scene to the Game scene
    /// </summary>
    public void PlayController()
    {
        SceneManager.LoadScene("Game");
    }
    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitController()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

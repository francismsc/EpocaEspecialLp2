using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    /// <summary>
    /// Changes current scene to the menu
    /// </summary>
    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

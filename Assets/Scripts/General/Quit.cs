using UnityEngine;

/// <summary>
/// controls quitting the game
/// </summary>
public class Quit : MonoBehaviour
{
    /// <summary>
    /// quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
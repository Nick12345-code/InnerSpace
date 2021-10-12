using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// controls scene changing
/// </summary>
public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// changes the scene
    /// </summary>
    /// <param name="name"></param>
    public void SwitchScene(string name) => SceneManager.LoadScene(name);
}

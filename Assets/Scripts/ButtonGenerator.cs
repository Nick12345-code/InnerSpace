using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// controls spawning alphabet buttons
/// </summary>
public class ButtonGenerator : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] Player player;
    [Header("")]
    public char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    [SerializeField] GameObject letterButton;
    [SerializeField] Transform letterHolder;

    /// <summary>
    /// generates the alphabet buttons
    /// </summary>
    public void GenerateButtons()
    {
        foreach (char letter in alphabet)
        {
            GameObject a = Instantiate(letterButton) as GameObject;
            a.transform.SetParent(letterHolder);
            a.GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();
            a.transform.GetComponent<Button>().onClick.AddListener(player.CheckLetter);
        }
    }
}

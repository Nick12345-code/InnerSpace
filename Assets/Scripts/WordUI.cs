using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// controls generating UI
/// </summary>
public class WordUI : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] WordGenerator wordGenerator;
    [Header("")]
    [SerializeField] GameObject playerLetterBox;
    [SerializeField] GameObject enemyLetterBox;
    [SerializeField] Transform playerPanel;
    [SerializeField] Transform enemyPanel;
    public List<GameObject> playerLetters = new List<GameObject>();
    public List<GameObject> enemyLetters = new List<GameObject>();
    [SerializeField] HorizontalLayoutGroup playoutGroup;
    [SerializeField] RectTransform plengthRectTransform;
    [SerializeField] HorizontalLayoutGroup elayoutGroup;
    [SerializeField] RectTransform elengthRectTransform;

    /// <summary>
    /// generates player's letters
    /// </summary>
    public void GeneratePlayerLetters()
    {
        foreach (char letter in wordGenerator.randomWord)
        {
            GameObject a = Instantiate(playerLetterBox);
            a.transform.SetParent(playerPanel);
            a.GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();
            playerLetters.Add(a);
            a.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        }
    }

    /// <summary>
    /// generates enemy's letters
    /// </summary>
    public void GenerateEnemyLetters()
    {
        foreach (char letter in wordGenerator.randomWord)
        {
            GameObject a = Instantiate(enemyLetterBox);
            a.transform.SetParent(enemyPanel);
            a.GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();
            enemyLetters.Add(a);
            a.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        }
    }
}

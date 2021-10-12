using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// controls the enemy AI
/// </summary>
public class Enemy : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] EnemyScore score;
    [SerializeField] ButtonGenerator generator;
    [SerializeField] StateManager state;
    [SerializeField] WordUI ui;
    [SerializeField] WordGenerator word;
    [Header("")]
    public char chosenLetter;
    List<char> alphabet = new List<char>{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

    /// <summary>
    /// enemy chooses a random letter
    /// </summary>
    public void ChooseRandomLetter()
    {
        chosenLetter = alphabet[Random.Range(0, alphabet.Count)];

        foreach (char letter in word.randomWord)
        {
            if (letter == chosenLetter)
            {
                foreach (GameObject letterText in ui.enemyLetters)
                {
                    if (chosenLetter.ToString() == letterText.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        letterText.GetComponent<Image>().color = Color.yellow;
                        //letterText.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                    }
                }
                alphabet.Remove(chosenLetter);              
                return;
            }
        }

        foreach (char letter in word.randomWord)
        {
            if (letter != chosenLetter)
            {
                score.LosePoints(1);
                alphabet.Remove(chosenLetter);
                return;
            }
        }

    }
}

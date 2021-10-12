using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// controls the randomness of the words
/// </summary>
public class WordGenerator : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] WordDictionary dictionary;
    [Header("")]
    public string randomWord;
    
    /// <summary>
    /// chooses a random word from dictionary
    /// </summary>
    public void GenerateRandomWord()
    {
        System.Random rand = new System.Random();
        List<string> temp = dictionary.words.ElementAt(rand.Next(0, dictionary.words.Count)).Value;
        randomWord = temp[Random.Range(0, temp.Count)];
        randomWord = randomWord.ToUpper();
    } 
}

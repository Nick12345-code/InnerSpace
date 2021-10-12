using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// loads words from dictionary
/// </summary>
public class WordDictionary : MonoBehaviour
{
    public Dictionary<int, List<string>> words = new Dictionary<int, List<string>>();
    [SerializeField] int minLength;
    [SerializeField] int maxLength;
    [SerializeField] int minLetters;
    [SerializeField] int maxLetters;
    TextAsset txt;
    string[] dictionary;

    void Awake() => LoadWordsFromFile();

    void LoadWordsFromFile()
    {
        txt = (TextAsset)Resources.Load("English");
        dictionary = txt.text.Split("\n"[0]);
        AddWordsToList();
    }

    void AddWordsToList()
    {
        for (int length = minLength; length < maxLength; length++) words[length] = new List<string>();

        foreach (string word in dictionary)
        {
            int number = word.Length;

            if (number < maxLetters && number > minLetters)
            {
                List<string> l = words[number];
                l.Add(word);
            }
        }
    }
}

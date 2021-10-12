using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// controls player interaction
/// </summary>
public class Player : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] Enemy enemy;
    [SerializeField] WordUI ui;
    [SerializeField] WordGenerator generator;
    [SerializeField] PlayerScore score;
    [SerializeField] StateManager state;
    [SerializeField] ButtonGenerator buttonGenerator;
    [Header("")]
    public GameObject selected;

    /// <summary>
    /// checks if player got the correct letter
    /// </summary>
    public void CheckLetter()
    {
        selected = EventSystem.current.currentSelectedGameObject;

        foreach (char letter in generator.randomWord)
        {
            if (letter.ToString() == selected.GetComponentInChildren<TextMeshProUGUI>().text)
            {
                Result(Color.green);

                foreach (GameObject letterText in ui.playerLetters)
                {
                    if (letterText.GetComponentInChildren<TextMeshProUGUI>().text == selected.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        letterText.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                    }
                }
                state.currentState = State.ENEMYTURN;
                return;
            }
        }

        foreach (char letter in generator.randomWord)
        {
            if (letter.ToString() != selected.GetComponentInChildren<TextMeshProUGUI>().text)
            {
                Result(Color.red);
                score.LosePoints(1);
                state.currentState = State.ENEMYTURN;
                return;
            }
        }
    }

    void Result(Color color)
    {
        selected.GetComponent<Button>().enabled = false;
        selected.GetComponent<Button>().targetGraphic.color = color;
    }
}

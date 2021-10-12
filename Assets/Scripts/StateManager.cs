using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum State { START, PLAYERTURN, ENEMYTURN, WIN, LOSE }

// controls the game state
public class StateManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] Enemy enemy;
    [SerializeField] WordGenerator wordGenerator;
    [SerializeField] WordUI wordUI;
    [SerializeField] ButtonGenerator buttonGenerator;
    [SerializeField] Player player;
    [Header("")]
    [SerializeField] GameObject resultsPanel;
    [SerializeField] TextMeshProUGUI resultsText;
    [SerializeField] TextMeshProUGUI pickALetter;
    [SerializeField] float delay;
    public State currentState;

    void Start() => Setup();

    void Setup()
    {
        currentState = State.START;
        wordGenerator.GenerateRandomWord();
        wordUI.GeneratePlayerLetters();
        wordUI.GenerateEnemyLetters();
        buttonGenerator.GenerateButtons();
        currentState = State.PLAYERTURN;
    }

    void EnemyTurn()
    {
        enemy.ChooseRandomLetter();
        currentState = State.PLAYERTURN;
    }

    void StateStatus()
    {
        switch (currentState)
        {
            case State.START:

                break;
            case State.PLAYERTURN:
                pickALetter.text = "Pick A Letter!";
                break;
            case State.ENEMYTURN:
                pickALetter.text = "";
                EnemyTurn();
                break;
            case State.WIN:
                WinUI();
                break;
            case State.LOSE:
                LoseUI();
                break;
            default:
                break;
        }
    }

    void Update()
    {
        if (Win()) currentState = State.WIN;
        if (Lose()) currentState = State.LOSE;
        StateStatus();
    }


    bool Win()
    {
        foreach (GameObject letter in wordUI.playerLetters)
        {
            if (!letter.GetComponentInChildren<TextMeshProUGUI>().enabled) return false;
        }
        return true;
    }

    bool Lose()
    {
        foreach (GameObject letter in wordUI.enemyLetters)
        {
            if (letter.GetComponent<Image>().color != Color.yellow) return false;
        }
        return true;
    }

    void WinUI()
    {
        resultsPanel.SetActive(true);
        resultsText.text = "You won!";
    }

    void LoseUI()
    {
        resultsPanel.SetActive(true);
        resultsText.text = "You lost!";
    }
}

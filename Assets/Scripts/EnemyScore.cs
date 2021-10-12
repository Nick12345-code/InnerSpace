using UnityEngine;
using TMPro;

/// <summary>
/// currently unused but controls player score for 3D element of game
/// </summary>
public class EnemyScore : MonoBehaviour
{
    public int points;
    [SerializeField] int maxPoints;
    [SerializeField] TextMeshProUGUI pointsText;

    private void Start()
    {
        points = maxPoints;
        pointsText.text = points.ToString();
    }

    private void Update()
    {
        if (points <= 0)
        {
            // ai loses
        }
    }

    public void LosePoints(int amount)
    {
        points -= amount;
        pointsText.text = points.ToString();
    }
}

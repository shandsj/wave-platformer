using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public Font Font;

    public int MaximumMultiplier = 20;
    public int MultiplierIncrease = 1;
    public float MaximumTimeBetweenKills = 2.0f;
    public int KillsNeededForMultiplierIncrease = 3;

    private int multiplier = 1;
    private int killsForMultiplier = 0;
    private int score;
    private float lastKillTime = 0;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnGUI()
    {
        var multiplierString = multiplier > 1 ? $"x{multiplier}" : string.Empty;
        GUI.Label(new Rect(-10, 5, Screen.width, Screen.height), $"{multiplierString} {score}", new GUIStyle()
        {
            alignment = TextAnchor.UpperRight,
            font = Font,
            fontSize = 45,
            normal = 
            {
                textColor = Color.white,
            },            
        });
    }

    public void AddScore(int baseAmount)
    {
        float elapsedTime = Time.time - lastKillTime;
        lastKillTime = Time.time;
        killsForMultiplier++;
        if (elapsedTime <= MaximumTimeBetweenKills)
        {
            if (killsForMultiplier >= KillsNeededForMultiplierIncrease)
            {
                // if (multiplier == 1)
                // {
                //     // Resetting to 0, for initial condition, just so calculations are easier.
                //     multiplier = 0;
                // }
                killsForMultiplier = 0;
                multiplier = Mathf.Min(multiplier + MultiplierIncrease, MaximumMultiplier);
            }
        }
        else
        {
            killsForMultiplier = 0;
            multiplier = 1;
        }

        score += baseAmount * multiplier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

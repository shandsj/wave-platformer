using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Health = 3;
    public Font Font;
    
    public float DamageCooldown = 1;

    private float lastDamageTakenTime;

    void OnGUI()
    {

        var heartString = string.Empty;
        for (int i = 0; i < Health; i++)
        {
            heartString += "❤ ";
        }
        GUI.Label(new Rect(10, 5, Screen.width, Screen.height), $"{heartString}", new GUIStyle()
        {
            alignment = TextAnchor.UpperLeft,
            font = Font,
            fontSize = 45,
            normal = 
            {
                textColor = Color.white,
            },            
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Time.time - lastDamageTakenTime > DamageCooldown)
            {
                lastDamageTakenTime = Time.time;
                Health -= 1;
            }
        }
    }
}

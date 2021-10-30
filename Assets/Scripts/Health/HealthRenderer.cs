using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class HealthRenderer : MonoBehaviour
{
    public Font Font;

    private HealthController healthController;

    // Start is called before the first frame update
    private void Awake()
    {
        this.healthController = GetComponent<HealthController>();
    }

    private void OnGUI()
    {

        var heartString = string.Empty;
        for (int i = 0; i < this.healthController.Health; i++)
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
}

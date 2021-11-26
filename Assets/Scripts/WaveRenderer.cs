using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaveController))]
public class WaveRenderer : MonoBehaviour
{
    public Font Font;

    private WaveController waveController;

    // Start is called before the first frame update
    private void Awake()
    {
        this.waveController = GetComponent<WaveController>();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 5, Screen.width, Screen.height), $"Wave {this.waveController.Wave}", new GUIStyle()
        {
            alignment = TextAnchor.UpperCenter,
            font = Font,
            fontSize = 45,
            normal = 
            {
                textColor = Color.white,
            },            
        });
    }
}

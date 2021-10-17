using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInputController : MonoBehaviour
{
    public SpellCaster SpellCaster;

    public int AssignedMouseButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(AssignedMouseButton))
        {
            SpellCaster.Cast();
        }
    }
}

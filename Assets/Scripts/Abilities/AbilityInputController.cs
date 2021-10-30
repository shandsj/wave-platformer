using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AbilitiesController))]
public class AbilityInputController : MonoBehaviour
{
    /// <summary>
    /// The assigned mouse button.
    /// </summary>
    public int AssignedMouseButton;

    private AbilitiesController abilitiesController;

    // Start is called before the first frame update
    private void Awake()
    {
        this.abilitiesController = this.GetComponent<AbilitiesController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(AssignedMouseButton))
        {
            this.abilitiesController.ActiveAbility.Cast();
        }
    }
}

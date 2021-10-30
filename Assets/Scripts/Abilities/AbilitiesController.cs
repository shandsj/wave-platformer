using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Ability))]
public class AbilitiesController : MonoBehaviour
{
    public Ability ActiveAbility;

    public Ability[] Abilities;

    // Start is called before the first frame update
    void Start()
    {
        this.Abilities = this.GetComponents<Ability>();
        this.ActiveAbility = this.Abilities.FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

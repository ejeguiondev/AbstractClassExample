using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EdibleObject : Object
{
    public int bitToEat = 1;
    public override string InteractionName { get; set; } 

    void Start() { InteractionName = "Eat"; }

    public override void Interact() { Eat(); }
    public void Eat()
    {
        Destroy(gameObject);
    }
}

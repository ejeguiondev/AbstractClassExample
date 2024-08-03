using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Object
{
    public override string InteractionName { get; set; }

    [Header("FlashLight Interaction Obj")]
    [SerializeField] GameObject lightObj;
    bool isOn = false;

    void Start() { InteractionName = "Turn On"; }

    public override void Interact()
    {
        isOn = !isOn;
        lightObj.SetActive(isOn);

        if (isOn) InteractionName = "Turn Off";
        else InteractionName = "Turn On";
    }
}

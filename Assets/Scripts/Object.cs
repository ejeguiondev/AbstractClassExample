using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object : MonoBehaviour
{
    public abstract void Interact();
    public abstract string InteractionName { get; set; }

    public string ObjectName;
    public bool graspable;
}
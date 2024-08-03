using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Object currentObject = null;
    [SerializeField] Transform objLocation;

    // ---------------------------------------------------------------------------------------------------------------------------- KEYS
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) drop();
        if (Input.GetKeyDown(KeyCode.F)) interact();
    }
    // ---------------------------------------------------------------------------------------------------------------------------- GRAB
    public void Grab(GameObject obj)
    {
        if (currentObject) return;

        // Make obj clon
        Object grabedObj = Instantiate(obj, objLocation).GetComponent<Object>();
        grabedObj.transform.localPosition = Vector3.zero;
        currentObject = grabedObj;

        // Make scale see with the player. (with maths & if sentences) 
        grabedObj.transform.localScale = new Vector3(

            (ReturnScaleXSymbol(transform) == 1 ? ReturnScaleXSymbol(transform) : -ReturnScaleXSymbol(transform)) * Mathf.Abs(currentObject.transform.localScale.x), 
            currentObject.transform.localScale.y, 
            currentObject.transform.localScale.z
        );
        // Destroy not clone obj
        Destroy(obj);
    }
    // ---------------------------------------------------------------------------------------------------------------------------- DROP
    void drop() 
    {
        if (!currentObject) return;

        // Make obj clon
        Transform dropedObj = Instantiate(currentObject.gameObject).transform;
        dropedObj.position = currentObject.transform.position;

        // Make scale see with the player. (with maths)
        dropedObj.localScale = new Vector3(

            ReturnScaleXSymbol(transform) 
            * Mathf.Abs(currentObject.transform.localScale.x), 

            currentObject.transform.localScale.y, 
            currentObject.transform.localScale.z
        );

        // Destroy not clon obj and set null currentObj
        Destroy(currentObject.gameObject);
        currentObject = null;
    }
    // ---------------------------------------------------------------------------------------------------------------------------- INTERACT
    void interact() 
    { 
        currentObject.Interact();
    }
    // --------------------------------------------------------------------------------------------------------------------------- RETURN SCALE X SYMBOL (-8 = -1; 9 = 1)
    float ReturnScaleXSymbol(Transform trasnformObj) { return trasnformObj.localScale.x / Mathf.Abs(trasnformObj.localScale.x); }

}
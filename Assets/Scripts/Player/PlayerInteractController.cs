using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;
    [SerializeField] float triggerRadio = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) detect();
    }

    void detect()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, triggerRadio);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Object")
                if (collider.GetComponent<Object>().graspable == true) inventory.Grab(collider.gameObject);
                //else collider.GetComponent<Object>().Interact();
        }
    }

    // Draw Detect area player
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadio);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Movement Properties")]

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    Vector2 mov;

    void Update()
    {
        movement();
    }
    // ------------------------------------------------------------------- Movement
    void movement()
    {
        // Variables para el movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        mov = new Vector2(horizontal, vertical);

        // Mover el objeto
        transform.Translate(mov * speed * Time.deltaTime);

        if (horizontal > 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (horizontal < 0) transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }

}

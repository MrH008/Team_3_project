using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("VertiacalMovement", Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.LeftShift))
            anim.SetBool("Sprinting", true);

        else
        {
            anim.SetBool("Sprinting", false);
        }

        if (Input.GetKey(KeyCode.LeftControl))
            anim.SetBool("Afraid", true);

        else
        {
            anim.SetBool("Sprinting", false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTrasform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    [Min(1)]
    private float hitrange = 3;

    [SerializeField]
    private InputActionRedronce interactionInput, dropInput, useInput;

    private RaycastHit hit;
    
    private void Update()
    {
        Debug.DrawRay(playerCameraTrasform.position, playerCameraTrasform.forward * hitrange, Color.red);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }
        if (Physics.Raycast(playerCameraTrasform.position, playerCameraTrasform.forward, out hit, hitrange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);

        }
    }
}

  
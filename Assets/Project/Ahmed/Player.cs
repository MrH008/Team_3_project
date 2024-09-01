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
    
    [SerializeField]
    private AudioSource pickUpSource;

    private void Start()
    {
        interactionInput.action.performed += PickUp;
        dropInput.action.performed += Drop;
        useInput.action.performed += Use;
    }

    private void Use(InputAction.CallbackContext obj)
    {
        if (inHandItem != null)
        {
            IUsable usable = inHandItem.GetComponent<IUsable>();
            if (usable != null)
            {
                usable.Use(this.gameObject);
            }
        }
    }

    private void Drop(InputAction.CallbackContext obj)
    {
        if (inHandItem != null)
        {
            inHandItem.transform.SetParent(null);
            inHandItem = null;
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }
    }

    private void PickUp(InputAction.CallbackContext obj)
    {
        if(hit.collider != null && inHandItem == null)
        {
            IPickable pickableItem = hit.collider.GetComponent<IPickable>();
            if (pickableItem != null)
            {
                pickUpSource.Play();
                inHandItem = pickableItem.PickUp();
                inHandItem.transform.SetParent(pickUpParent.transform, pickableItem.KeepWorldPosition);
            }

            Debug.Log(hit.collider.name);
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (hit.collider.GetComponent<pc>() || hit.collider.GetComponent<keyboard>())
            {
                Debug.Log("it is pc");
                inHandItem = hit.collider.gameObject;
                inHandItem.transform.position = Vector3.zero;
                inHandItem.transform.rotation = Quaternion.identity;
                inHandItem.transform.SetParent(pickUpParent.transform, false);
                if(rb != null)
                {
                    rb.isKinematic = true;
                }
                return;
            }
            //if (hit.collider.GetComponent<Item>())
            //{
            //    Debug.Log("It's a useless item!");
            //    inHandItem = hit.collider.gameObject;
            //    inHandItem.transform.SetParent(pickUpParent.transform, true);
            //    if (rb != null)
            //    {
            //        rb.isKinematic = true;
            //    }
            //    return;
            //}
        }
    }

    
    private void Update()
    {
        Debug.DrawRay(playerCameraTrasform.position, playerCameraTrasform.forward * hitrange, Color.red);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }
        f (inHandItem != null)
        {
            return;
        }
        if (Physics.Raycast(playerCameraTrasform.position, playerCameraTrasform.forward, out hit, hitrange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);

        }
    }
}

  
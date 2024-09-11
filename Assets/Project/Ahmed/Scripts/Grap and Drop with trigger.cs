using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapandDropwithtrigger : MonoBehaviour
{
    [SerializeField] GameObject hand;
    [SerializeField] BoxCollider objCol;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.transform.parent = hand.transform;
            this.transform.position = hand.transform.position;
            objCol.enabled = false;
        }
    }
}

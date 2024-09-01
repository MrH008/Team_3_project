using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEx : MonoBehaviour
{
    [SerializeField] Flowchart dialog;
    [SerializeField] string exBlock;
    [SerializeField] string stopBlock;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("entered");
            dialog.ExecuteBlock(exBlock);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            dialog.ExecuteBlock(stopBlock);
        }
    }
} 

using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEx : MonoBehaviour
{
    [SerializeField] Flowchart dialog;
    [SerializeField] string exBlock;
    [SerializeField] string stopBlock;
    [SerializeField] GameObject pressE;
    private bool isPlayerInRange = false; 

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialog.ExecuteBlock(exBlock);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true; 
            pressE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false; 
            pressE.SetActive(false);
        }
    }
}

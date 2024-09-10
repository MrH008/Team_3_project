using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEx : MonoBehaviour
{
    [SerializeField] Flowchart dialog;
    [SerializeField] string exBlock;
    [SerializeField] string stopBlock;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            dialog.ExecuteBlock(exBlock);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialog.ExecuteBlock(exBlock);
        }
    }
} 

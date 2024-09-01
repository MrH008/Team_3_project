using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoug : MonoBehaviour
{
    [SerializeField] Flowchart Flowchart;
    [SerializeField] string blookname;
    [SerializeField] bool Area = false;

    private void Update()
    {

        if (Area && Input.GetKeyDown(KeyCode.E))
        {
            Flowchart.ExecuteBlock(blookname);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Area = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Area = false;
        }
    }
}

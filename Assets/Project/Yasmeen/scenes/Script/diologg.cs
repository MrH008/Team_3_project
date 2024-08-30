using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diologg : MonoBehaviour
{
    [SerializeField] Flowchart Flowchart;
    [SerializeField] string blockname;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Flowchart.ExecuteBlock(blockname); // تنفيذ الحوار عند دخول اللاعب المنطقة
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Flowchart.StopBlock(blockname); // إيقاف الحوار عند خروج اللاعب من المنطقة
        }
    }
}
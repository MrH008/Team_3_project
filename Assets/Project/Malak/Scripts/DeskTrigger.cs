using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTrigger : MonoBehaviour
{
    [SerializeField] GameObject monitor;
    [SerializeField] GameObject printer;
    [SerializeField] GameObject projector;
    [SerializeField] GameObject keybosrd;
    [SerializeField] GameObject case2 ;
    [SerializeField] GameObject laptop;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("monitor"))
        {
            monitor.SetActive(true);
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("printer"))
        {
            printer.SetActive(true);
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("projector"))
        {
            projector.SetActive(true);
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("keybosrd"))
        {
            keybosrd.SetActive(true);
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("case2"))
        {
            case2.SetActive(true);
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("laptop"))
        {
            laptop.SetActive(true);
            Destroy(other.gameObject);
        }


    }
}

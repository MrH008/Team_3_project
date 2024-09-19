using UnityEngine;

public class TogglePanel : MonoBehaviour
{
   
    public GameObject panel;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Z))
        {

            panel.SetActive(!panel.activeSelf);
        }
    }
}

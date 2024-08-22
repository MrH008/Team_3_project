using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    private Color color = Color.white;

    [SerializeField]
    private List<Material> materials;

    // Update is called once per frame
    private void Awake()
    {
        materials = new List<Material>();
        foreach (var renderer in renderers)
        {
            materials.Add(renderer.material);
        }
        
        
    }
    public void ToggleHighlight(bool val)
    {
        if (val) 
        {
            foreach (var material in materials)
            {
                material.EnableKeyword("_EMISSION");

                material.SetColor("_EMISSIONCOLOR" , color);
            }
        }
        else
        {
            foreach(var material in materials)
            {
                material.DisableKeyword("_EMISSTION");
            }
        }
            
    }
}

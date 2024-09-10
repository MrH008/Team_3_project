using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform handPosition;  // The transform of the hand where the object will be held
    private GameObject objectInHand;  // The current object held by the character

    // New variables for sphere cast
    public float pickupRange = 2f;  // Adjust this value for the range in which the player can pick up objects
    public float sphereRadius = 0.5f;  // Adjust this value to control how wide the sphere cast is

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  // Change "E" to your preferred pickup key
        {
            if (objectInHand == null)  // No object currently held
            {
                // Perform a sphere cast to detect objects in front of the character
                Ray ray = new Ray(transform.position + Vector3.up * 0.5f, transform.forward);
                RaycastHit hit;

                if (Physics.SphereCast(ray, sphereRadius, out hit, pickupRange))  // Use SphereCast instead of Raycast
                {
                    // Check for the tags you are interested in
                    if (hit.collider.CompareTag("pc") ||
                        hit.collider.CompareTag("monitor") ||
                        hit.collider.CompareTag("printer") ||
                        hit.collider.CompareTag("projector") ||
                        hit.collider.CompareTag("laptop") ||
                        hit.collider.CompareTag("keybosrd"))  // Corrected "keybosrd" to "keyboard"
                    {
                        PickupObject(hit.collider.gameObject);
                    }
                }
            }
            else
            {
                DropObject();
            }
        }
    }

    void PickupObject(GameObject obj)
    {
        objectInHand = obj;
        obj.transform.SetParent(handPosition);  // Attach object to hand
        obj.transform.localPosition = Vector3.zero;  // Position it correctly in hand
        obj.GetComponent<Rigidbody>().isKinematic = true;  // Disable physics while holding
    }

    void DropObject()
    {
        objectInHand.transform.SetParent(null);  // Detach from hand
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;  // Re-enable physics
        objectInHand = null;
    }
}
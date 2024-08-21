using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    private GameObject pickedObject;

    public float radius = 2f;
    public float distance = 2f;
    public float height = 1f;

    private PlayerInput playerInput;
    private InputAction pickupAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pickupAction = playerInput.actions["Pickup"];
    }

    private void Update()
    {
        Transform playerTransform = transform;

        // التحقق مما إذا كان زر التقاط الشيء مضغوطاً
        bool pressedT = pickupAction.triggered;

        if (pickedObject)
        {
            Rigidbody objectRigidbody = pickedObject.GetComponent<Rigidbody>();
            Vector3 moveTo = playerTransform.position + distance * playerTransform.forward + height * playerTransform.up;
            Vector3 direction = moveTo - pickedObject.transform.position;
            pickedObject.transform.position += direction * Time.deltaTime;

            pickedObject.transform.rotation = playerTransform.rotation;

            // إسقاط الجسم عند الضغط على الزر مرة أخرى
            if (pressedT)
            {
                pickedObject = null;
                objectRigidbody.useGravity = true;
            }
        }
        else
        {
            if (pressedT)
            {
                RaycastHit[] hits = Physics.SphereCastAll(playerTransform.position + playerTransform.forward, radius, playerTransform.forward, radius);
                int hitIndex = Array.FindIndex(hits, hit => hit.transform.tag == "Pickupable");

                if (hitIndex != -1)
                {
                    pickedObject = hits[hitIndex].transform.gameObject;
                    pickedObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
    }
}

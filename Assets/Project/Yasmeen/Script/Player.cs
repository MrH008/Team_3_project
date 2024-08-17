using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // متغيرات للحركة والرسوم المتحركة
    [SerializeField] float moveSpeed = 5f; // سرعة الحركة
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // الحصول على المدخلات الأفقية والعمودية
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // حساب الحركة
        Vector3 movement = new Vector3(x, 0f, z);
        transform.position += movement * moveSpeed * Time.deltaTime;

        // تحديث الرسوم المتحركة بناءً على الحركة
        anim.SetFloat("VerticalMovement", z); // تأكد من تطابق اسم المتغير في Animator
        anim.SetFloat("HorizontalMovement", x); // تأكد من تطابق اسم المتغير في Animator

        // تحديث حالة الجري
        if (Input.GetKey(KeyCode.LeftShift))
            anim.SetBool("Sprinting", true);
        else
            anim.SetBool("Sprinting", false);

        // تحديث حالة الخوف
        if (Input.GetKey(KeyCode.LeftControl))
            anim.SetBool("Afraid", true);
        else
            anim.SetBool("Afraid", false);
    }
}

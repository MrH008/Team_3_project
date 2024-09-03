using UnityEngine;

public class click1 : MonoBehaviour
{
    public GameObject nameofobj; // متغير لتخزين اسم الكائن الذي تم النقر عليه
    public GameObject Image; // صورة الكيبورد التي تظهر في الأسفل

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // يتم استدعاء هذه الدالة عند النقر على الكائن باستخدام الماوس
    void OnMouseDown()
    {
        
        Destroy(nameofobj); // تدمير الكيبورد الموجود في اللعبة
        Destroy(Image); // تدمير صورة الكيبورد في الأسفل
    }
}

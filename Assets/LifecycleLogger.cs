using UnityEngine;

public class LifecycleLogger : MonoBehaviour
{
    // 1. Chạy đầu tiên khi script được khởi tạo (kể cả khi chưa bật)
    void Awake()
    {
        Debug.Log("1. Awake - Tỉnh dậy!");
    }

    // 2. Chạy mỗi khi GameObject được Bật (Active)
    void OnEnable()
    {
        Debug.Log("2. OnEnable - Đã Bật");
    }

    // 3. Chạy trước frame đầu tiên (chỉ 1 lần duy nhất)
    void Start()
    {
        Debug.Log("3. Start - Bắt đầu");
    }

    // 4. Chạy liên tục mỗi frame (Dùng để xử lý logic game)
    void Update()
    {
        // Để tránh spam, mình chỉ log khi bạn nhấn phím Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("4. Update - Đang chạy (Bạn vừa nhấn Space)");
        }
    }

    // 5. Chạy mỗi khi GameObject bị Tắt (Inactive)
    void OnDisable()
    {
        Debug.Log("5. OnDisable - Đã Tắt");
    }

    // 6. Chạy khi GameObject bị Hủy hoàn toàn (Delete)
    void OnDestroy()
    {
        Debug.Log("6. OnDestroy - Đã Hủy/Chết");
    }
}
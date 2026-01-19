using UnityEngine;
using TMPro; // Thư viện để dùng TextMeshPro

public class SignedAngleRotator : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI angleLabel; // Kéo cái UI Text vào đây

    void Update()
    {
        // 1. Lấy vị trí chuột trong thế giới game (World Space)
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0; // Đảm bảo chuột nằm trên mặt phẳng 2D

        // 2. Tính Vector hướng từ Player tới Chuột
        Vector3 direction = mouseWorld - transform.position;

        // 3. --- TRỌNG TÂM LAB: SIGNED ANGLE ---
        // Tính góc hợp bởi Vector hướng lên (Up) và Vector hướng chuột.
        // SignedAngle trả về giá trị từ -180 đến 180 độ.
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        // 4. Xoay nhân vật theo góc đã tính
        // Trục xoay của 2D là trục Z
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 5. Hiển thị góc lên UI
        if (angleLabel != null)
        {
            angleLabel.text = "Angle: " + Mathf.Round(angle) + "°";
        }

        // Vẽ Debug tia màu đỏ nối từ Player tới chuột để dễ nhìn
        Debug.DrawLine(transform.position, mouseWorld, Color.red);
    }
}
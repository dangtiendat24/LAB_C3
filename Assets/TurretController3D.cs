using UnityEngine;

public class TurretController3D : MonoBehaviour
{
    [Header("Assign Objects")]
    public Transform target;          // Kéo Sphere (Target) vào đây

    [Header("Settings")]
    public bool useSmooth = true;     // Tích: Xoay mượt | Bỏ tích: Xoay ngay
    public float rotationSpeed = 5f;  // Tốc độ xoay (chỉ dùng cho Smooth)

    void Update()
    {
        // Nếu không có mục tiêu thì dừng
        if (target == null) return;

        if (useSmooth)
        {
            // --- CÁCH 2: XOAY MƯỢT (SLERP) ---

            // B1: Xác định hướng từ Turret đến Target (Đích - Gốc)
            Vector3 direction = target.position - transform.position;

            // B2: Tạo ra một góc quay (Quaternion) để nhìn theo hướng đó
            // Lưu ý: LookRotation mặc định dùng trục Z (màu xanh dương) làm hướng nhìn
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // B3: Xoay từ từ góc hiện tại sang góc đích
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // --- CÁCH 1: XOAY NGAY LẬP TỨC (LOOKAT) ---
            // Hàm này tính toán và gán góc xoay ngay trong 1 dòng
            transform.LookAt(target);
        }
    }
}

using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public Transform playerTarget; // Kéo Player vào đây
    public float rotateSpeed = 5f;

    void Update()
    {
        if (playerTarget == null) return;

        // --- Logic từ Lab 3 (2D) ---
        // 1. Tính hướng
        Vector3 direction = playerTarget.position - transform.position;
        // 2. Tính góc (Atan2)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // 3. Tạo Quaternion (Trừ 90 độ vì sprite thường hướng lên trên)
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90);
        // 4. Xoay mượt (Slerp)
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
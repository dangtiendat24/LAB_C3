using UnityEngine;

public class VectorMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
    public bool useNormalize = true; // Biến để bật/tắt tính năng chuẩn hóa (để test)

    // Biến lưu hướng di chuyển để vẽ Gizmos
    private Vector3 currentDirection;

    void Update()
    {
        // 1. Lấy tín hiệu từ bàn phím (-1 đến 1)
        float inputX = Input.GetAxisRaw("Horizontal"); // A/D hoặc Mũi tên Trái/Phải
        float inputY = Input.GetAxisRaw("Vertical");   // W/S hoặc Mũi tên Lên/Xuống

        // 2. Tạo Vector hướng đi
        // Vì là game 2D nên ta di chuyển theo trục X và Y, trục Z để là 0
        Vector3 direction = new Vector3(inputX, inputY, 0);

        // --- KIẾN THỨC CỐT LÕI: NORMALIZE ---
        // Vấn đề: Khi nhấn W+D -> Vector là (1, 1). Độ dài = căn bậc 2 của (1^2 + 1^2) ≈ 1.41
        // Nghĩa là đi chéo nhanh hơn đi thẳng 41%.

        if (useNormalize && direction.magnitude > 1)
        {
            direction = direction.normalized; // Ép độ dài vector về 1 (vẫn giữ nguyên hướng)
        }

        // Lưu lại để tí nữa vẽ Gizmos
        currentDirection = direction;

        // 3. Thực hiện di chuyển
        // Công thức: Vị trí += Hướng * Tốc độ * Thời gian
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    // Hàm vẽ debug (chỉ hiện trong cửa sổ Scene, không hiện khi chơi game thật)
    void OnDrawGizmos()
    {
        // Vẽ tia màu vàng chỉ hướng nhân vật đang đi
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, currentDirection * 2f);

        // Vẽ vòng tròn bao quanh nhân vật để dễ nhìn
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 0.6f);
    }
}

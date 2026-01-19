using UnityEngine;
using System; // Cần thư viện này để dùng Action

public class PlayerHealth : MonoBehaviour
{
    // --- KHAI BÁO SỰ KIỆN (Event) ---
    // Đây là cái "loa". Action<int> nghĩa là gửi đi kèm một số nguyên (máu hiện tại)
    public event Action<int> OnHealthChanged;

    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        // Phát sự kiện lần đầu để UI cập nhật ngay khi game bắt đầu
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        // Nhấn H để tự làm đau mình (giả lập bị trúng đạn)
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        // --- PHÁT SỰ KIỆN (Notify) ---
        // Dấu ? nghĩa là: Nếu có ai đang lắng nghe thì mới gọi, không thì thôi (tránh lỗi Null)
        OnHealthChanged?.Invoke(currentHealth);

        Debug.Log($"Player bị đau! Máu còn: {currentHealth}");
    }
}
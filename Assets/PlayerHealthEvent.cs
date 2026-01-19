using UnityEngine;
using UnityEngine.Events; // Bắt buộc để dùng UnityEvent

public class PlayerHealthEvent : MonoBehaviour
{
    // [System.Serializable] giúp Event hiện ra ngoài Inspector
    [System.Serializable]
    public class MyHealthEvent : UnityEvent<int> { }

    // Đây là cái "Danh sách việc cần làm" hiện ở Inspector
    public MyHealthEvent OnHealthChanged;

    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        // Báo cáo tình trạng sức khỏe ngay khi vào game
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        // Nhấn phím K để thử trừ máu
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        // --- HÉT LÊN CHO UI BIẾT ---
        // Gọi tất cả những ai đang đăng ký trong Inspector
        OnHealthChanged?.Invoke(currentHealth);
    }
}
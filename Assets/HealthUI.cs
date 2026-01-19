using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth; // Cần biết Player là ai để đăng ký nghe
    private TextMeshProUGUI hpText;

    void Awake()
    {
        hpText = GetComponent<TextMeshProUGUI>();
    }

    // --- ĐĂNG KÝ LẮNG NGHE ---
    void OnEnable()
    {
        if (playerHealth != null)
        {
            // Cú pháp: Sự kiện += Hàm xử lý
            playerHealth.OnHealthChanged += UpdateHP;
        }
    }

    // --- HỦY ĐĂNG KÝ (Rất quan trọng để tránh lỗi) ---
    void OnDisable()
    {
        if (playerHealth != null)
        {
            // Cú pháp: Sự kiện -= Hàm xử lý
            playerHealth.OnHealthChanged -= UpdateHP;
        }
    }

    // Hàm này sẽ tự chạy mỗi khi Player phát sự kiện
    void UpdateHP(int currentHealth)
    {
        hpText.text = "HP: " + currentHealth;
        // Đổi màu chữ nếu máu thấp
        if (currentHealth <= 30) hpText.color = Color.red;
        else hpText.color = Color.white;
    }
}
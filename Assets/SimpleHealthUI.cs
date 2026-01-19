using UnityEngine;
using TMPro;

public class SimpleHealthUI : MonoBehaviour
{
    private TextMeshProUGUI hpText;

    void Awake()
    {
        hpText = GetComponent<TextMeshProUGUI>();
    }

    // QUAN TRỌNG: Hàm phải là PUBLIC thì Inspector mới nhìn thấy để nối dây
    public void UpdateHPVisual(int amount)
    {
        hpText.text = "HP: " + amount;

        // Đổi màu cho sinh động
        if (amount <= 30) hpText.color = Color.red;
        else hpText.color = Color.white;
    }
}
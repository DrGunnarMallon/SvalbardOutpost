using UnityEngine;
using TMPro;
using System.Collections;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI coalText;

    private void Start()
    {
        moneyText.text = GameManager.Instance.ResourceManager.Money.ToString();
        coalText.text = GameManager.Instance.ResourceManager.Coal.ToString();

        GameManager.Instance.ResourceManager.onMoneyChanged += UpdateMoney;
        GameManager.Instance.ResourceManager.onCoalChanged += UpdateCoal;
    }

    private void Oestroy()
    {
        GameManager.Instance.ResourceManager.onMoneyChanged -= UpdateMoney;
        GameManager.Instance.ResourceManager.onCoalChanged -= UpdateCoal;
    }

    public void Initialize(int money, int coal, int food, int tools)
    {
        moneyText.text = money.ToString();
        coalText.text = coal.ToString();
    }

    public void UpdateMoney(int amount)
    {
        moneyText.text = "$" + amount.ToString();
    }

    public void UpdateCoal(int amount)
    {
        coalText.text = amount.ToString();
    }
}

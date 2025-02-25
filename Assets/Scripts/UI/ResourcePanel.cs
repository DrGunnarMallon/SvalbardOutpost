using UnityEngine;
using TMPro;
using System.Collections;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI coalText;
    [SerializeField] private TextMeshProUGUI foodText;

    private void Start()
    {
        moneyText.text = GameManager.Instance.ResourceManager.Money.ToString();
        coalText.text = GameManager.Instance.ResourceManager.Coal.ToString();
        foodText.text = GameManager.Instance.ResourceManager.Food.ToString();

        GameManager.Instance.ResourceManager.onMoneyChanged += UpdateMoney;
        GameManager.Instance.ResourceManager.onCoalChanged += UpdateCoal;
        GameManager.Instance.ResourceManager.onFoodChanged += UpdateFood;
    }

    private void Oestroy()
    {
        GameManager.Instance.ResourceManager.onMoneyChanged -= UpdateMoney;
        GameManager.Instance.ResourceManager.onCoalChanged -= UpdateCoal;
        GameManager.Instance.ResourceManager.onFoodChanged -= UpdateFood;
    }

    public void Initialize(int money, int coal, int food, int tools)
    {
        moneyText.text = money.ToString();
        coalText.text = coal.ToString();
        foodText.text = food.ToString();
    }

    public void UpdateMoney(int amount)
    {
        moneyText.text = "$" + amount.ToString();
    }

    public void UpdateCoal(int amount)
    {
        coalText.text = amount.ToString();
    }

    public void UpdateFood(int amount)
    {
        foodText.text = amount.ToString();
    }

}

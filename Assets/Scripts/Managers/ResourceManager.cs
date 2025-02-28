using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public int Money { get; private set; }
    public int Coal { get; private set; }
    public int Food { get; private set; }
    public int Tools { get; private set; }

    public event Action<int> onMoneyChanged;
    public event Action<int> onCoalChanged;


    public void Initialize()
    {
        Money = 1000;
        Coal = 0;
        Food = 300;
        Tools = 100;

        onMoneyChanged?.Invoke(Money);
        onCoalChanged?.Invoke(Coal);
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        onMoneyChanged?.Invoke(Money);
    }

    public void UseMoney(int amount)
    {
        Money = Mathf.Max(Money - amount, 0);
        onMoneyChanged?.Invoke(Money);
    }

    public void AddCoal(int amount)
    {
        Coal += amount;
        onCoalChanged?.Invoke(Coal);
    }
    public void UseCoal(int amount)
    {
        Coal = Mathf.Max(Coal - amount, 0);
        onCoalChanged?.Invoke(Coal);
    }
}
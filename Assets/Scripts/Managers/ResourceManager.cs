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
    public event Action<int> onFoodChanged;
    public event Action<int> onToolsChanged;


    public void Initialize()
    {
        Money = 1000;
        Coal = 0;
        Food = 300;
        Tools = 100;

        onMoneyChanged?.Invoke(Money);
        onCoalChanged?.Invoke(Coal);
        onFoodChanged?.Invoke(Food);
        onToolsChanged?.Invoke(Tools);
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

    public void AddFood(int amount)
    {
        Food += amount;
        onFoodChanged?.Invoke(Food);
    }
    public void UseFood(int amount)
    {
        Food = Mathf.Max(Food - amount, 0);
        onFoodChanged?.Invoke(Food);
    }

    public void AddTools(int amount)
    {
        Tools += amount;
        onToolsChanged?.Invoke(Tools);
    }
    public void UseTools(int amount)
    {
        Tools = Mathf.Max(Tools + amount, 0);
        onToolsChanged?.Invoke(Tools);
    }
}


// coal production
// price of coal
// food availability
// price of food
// tools availability
// price of tools
// equipment condition
// equipment maintenance
// miners
// mechanics
// worker morale
// worker health
// worker productivity
// worker availability
// worker price
// worker skills
// worker training
// worker housing
// production efficiency
// production capacity
// production cost
// production quality
// production safety
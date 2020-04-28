using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{   
    public Text HealthLabel;
    public Text MoneyLabel;
    public GameObject EndGame;

    private int _health;
    private int _money;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            HealthLabel.text = "Health: " + _health;
            if (_health<=0)
            {
                Time.timeScale = 0;
                EndGame.SetActive(!EndGame.activeSelf);
            }
        }
    }
    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            MoneyLabel.text = "Money: " + _money;
        }
    }
    void Start()
    {
        Health = 10;
        Money = 1000;
    }
}

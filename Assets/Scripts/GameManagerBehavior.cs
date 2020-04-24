using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    public Text ScoreLabel;
    public Text HealthLabel;
    public GameObject EndGame;

    private int _health;
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
                Debug.Log("Game over");
                EndGame.SetActive(!EndGame.activeSelf);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

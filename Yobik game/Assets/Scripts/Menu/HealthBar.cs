using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player player;
    public Slider slider;

    Image healthBar;
    
    void Start()
    {
        slider = transform.GetComponent<Slider>();
        slider.maxValue = player.maxHealth;
        slider.value = slider.maxValue;
    }

    void Update()
    {
        slider.value = player.HP;
    }
}

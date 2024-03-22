using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private TMP_Text carHealthTXT; 
    private float health = 100;
    public static CarHealth instance;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    void Start()
    {
        if(instance == null)
            instance = this;
    }
    void Update()
    {
        carHealthTXT.text = ((int) health).ToString()+" HP";

        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

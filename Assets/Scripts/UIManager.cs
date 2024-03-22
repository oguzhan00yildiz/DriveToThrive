using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    void Start()
    {
        
    }

    
    void Update()
    {
        ammoText.text = Gun.instance.gunData.currentAmmo.ToString()+"/"+ Gun.instance.gunData.magSize.ToString();
    }
}

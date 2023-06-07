using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    public Image TargetImage;
    public float hpMAX;
    public static float PlayerHP;
    // Update is called once per frame
    void Start()
    {
        hpMAX = 100.0f;
        PlayerHP = 100f;
    }

    void Update()
    {
        HP_Update();
    }
    public void HP_Update()
    { 
        TargetImage.fillAmount = PlayerHP / hpMAX;
        TargetImage.color = new Color(1, 0, 0);
    }

}

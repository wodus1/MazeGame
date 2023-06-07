using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunHpScript : MonoBehaviour
{
    public Image TargetImage;
    public float StaminaMAX;
    public static float PlayerStamina;
    private bool Heal = false;
    // Update is called once per frame
    void Start()
    {
        StaminaMAX = 100.0f;
        PlayerStamina = 100f;
    }

    void Update()
    {
        HP_Update();
        if (Heal == true)
        {
            PlayerStamina += 39 * Time.deltaTime;
        }
    }
    public void HP_Update()
    {
        TargetImage.fillAmount = PlayerStamina / StaminaMAX;
        TargetImage.color = new Color(0, 0, 1);
        if (PlayerStamina <= 0)
        {
            Heal = true;
        }
        else if (PlayerStamina > 100)
        {
            Heal = false;
        }
    }
}
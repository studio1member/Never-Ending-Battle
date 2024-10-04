using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPlayerVirtual : MonoBehaviour
{
    public static StatusPlayerVirtual instance;
    [Header("HP")]
    public Image hp_Image;
    public float current_HP;
    public float max_HP;
    public float hpSpeed;

    [Header("MP")]
    public Image mp_Image;
    public float current_MP;
    public float max_MP;
    public float mpSpeed;

    [Header("Damage")]
    public float damage;
    public float magical_damage;

    private bool FixHP;
    private bool FixMP;
    private void Awake()
    {
        instance = this;
        hp_Image = GameObject.Find("bar HP").GetComponent<Image>();
        hp_Image.fillAmount = current_HP / max_HP;
        mp_Image = GameObject.Find("bar MP").GetComponent<Image>();
        mp_Image.fillAmount = current_MP / max_MP;
    }
    private void Update()
    {
        if (current_HP < max_HP)
        {
            current_HP += hpSpeed * Time.deltaTime;
            current_HP = Mathf.Clamp(current_HP, 0, max_HP);
            hp_Image.fillAmount = current_HP / max_HP;
        }

        if (current_MP < max_MP)
        {
            current_MP += mpSpeed * Time.deltaTime;
            current_MP = Mathf.Clamp(current_MP, 0, max_MP);
            mp_Image.fillAmount = current_MP / max_MP;
        }
    }
}

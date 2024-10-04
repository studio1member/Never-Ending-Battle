using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillVirtual : MonoBehaviour
{
    public static SkillVirtual instance;
    public FixedTouchField Touch_Main;
    public FixedTouchField Touch_Skill_1;
    public FixedTouchField Touch_Skill_2;
    public FixedTouchField Touch_Skill_3;
    public CameraLook touchCameraLook;

    public Change_Perspective change_Perspective;

    public Image TuLuc_Image;
    public float Timer_TuLuc;
    public float TuLuc;
    public float Tuluc_Max;

    public List<Transform> effect_Attack_Button_List = new List<Transform>();
    private Transform listEffectAttacks;
    private Image attack_Button;

    public Image skill_1_Image;
    public float damage_Skill_1;

    public Image skill_2_Image;
    public float damage_Skill_2;

    public Image skill_3_Image;
    public float damage_Skill_3;

    public virtual void Awake() 
    {
        instance = this;
        change_Perspective = GameObject.Find("Main Camera").GetComponent<Change_Perspective>();
        touchCameraLook = GameObject.Find("MainCamera").GetComponent<CameraLook>();
        attack_Button = GameObject.Find("Attack Button").GetComponent<Image>();
        TuLuc_Image = GameObject.Find("Tu Luc").GetComponent<Image>();
        TuLuc_Image.gameObject.SetActive(false);
        Timer_TuLuc = 1;
        foreach (Transform checkEffect in attack_Button.transform) { effect_Attack_Button_List.Add(checkEffect); }
        skill_1_Image = GameObject.Find("Skill 1 Button").GetComponent<Image>();
        skill_2_Image = GameObject.Find("Skill 2 Button").GetComponent<Image>();
        skill_3_Image = GameObject.Find("Skill 3 Button").GetComponent<Image>();
    }
    public virtual void Attack_Down() 
    {
        attack_Button.color = new Color(0.5f, 0.5f, 0.5f);
    }
    public virtual void Attack_Up() 
    {
        attack_Button.color = new Color(1, 1, 1);
    }
    public virtual void Jump_Down() 
    {
        if (!GetComponentShikigami.instance.isCheckGround) return;
        //GetComponentShikigami.instance.rigidbody_Shikigami.velocity = Vector3.zero;
        GetComponentShikigami.instance.rigidbody_Shikigami.AddForce(transform.up * GetComponentShikigami.instance.jumpForce, ForceMode.Impulse);
    }
    public virtual void Jump_Up() { }
    public virtual void Skill_1_Down() { }
    public virtual void Skill_1_Up() { }
    public virtual void Skill_2_Down() { }
    public virtual void Skill_2_Up() { }
    public virtual void Skill_3_Down() { }
    public virtual void Skill_3_Up() { }
    public virtual void Until_Down() { }
    public virtual void Until_Up() { }
}

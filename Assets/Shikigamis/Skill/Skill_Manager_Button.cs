using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skill_Manager_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Jump Button") SkillVirtual.instance.Jump_Down();
        if (gameObject.name == "Attack Button") SkillVirtual.instance.Attack_Down();
        if (gameObject.name == "Skill 1 Button") SkillVirtual.instance.Skill_1_Down();
        if (gameObject.name == "Skill 2 Button") SkillVirtual.instance.Skill_2_Down();
        if (gameObject.name == "Skill 3 Button") SkillVirtual.instance.Skill_3_Down();
        if (gameObject.name == "Until Button") SkillVirtual.instance.Until_Down();
    }
    public void OnPointerUp(PointerEventData data) 
    {
        if (gameObject.name == "Jump Button") SkillVirtual.instance.Jump_Up();
        if (gameObject.name == "Attack Button") SkillVirtual.instance.Attack_Up();
        if (gameObject.name == "Skill 1 Button") SkillVirtual.instance.Skill_1_Up();
        if (gameObject.name == "Skill 2 Button") SkillVirtual.instance.Skill_2_Up();
        if (gameObject.name == "Skill 3 Button") SkillVirtual.instance.Skill_3_Up();
        if (gameObject.name == "Until Button") SkillVirtual.instance.Until_Up();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuLuc : MonoBehaviour
{
    private void Update()
    {
        if (SkillVirtual.instance.TuLuc >= SkillVirtual.instance.Tuluc_Max) return;
        SkillVirtual.instance.TuLuc += SkillVirtual.instance.Timer_TuLuc * Time.deltaTime;
        SkillVirtual.instance.TuLuc_Image.fillAmount = SkillVirtual.instance.TuLuc / SkillVirtual.instance.Tuluc_Max;
    }
}

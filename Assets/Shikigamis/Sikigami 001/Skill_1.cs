using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float exaggerateDamage;
    private void OnTriggerEnter(Collider other)
    {
        if ((layerMask.value & (1 << other.gameObject.layer)) != 0)
        {
            other.gameObject.GetComponent<HP_EnemyVirtual>().Apply_Damage(-StatusPlayerVirtual.instance.damage * exaggerateDamage);
            other.gameObject.GetComponent<HP_EnemyVirtual>().Apply_Knockback(transform.position, 20f);
        }
    }
}

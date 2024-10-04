using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant_Damage : MonoBehaviour
{
    [SerializeField] private float range_Damage;
    [SerializeField] LayerMask layerMask;
    [SerializeField] private float timer, timerDelay;
    [SerializeField] private bool display;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerDelay)
        {
            timer = 0f;
            Damage();
        }
    }
    private void Damage()
    {
        Collider[] getCollider = Physics.OverlapSphere(transform.position, range_Damage, layerMask);
        foreach (Collider hitDamage in getCollider)
        {
            hitDamage.GetComponent<HP_EnemyVirtual>().Apply_Damage(-Attack.instance.damage_Skill_2);
        }
    }
    private void OnDrawGizmos()
    {
        if (display) Gizmos.DrawSphere(transform.position, range_Damage);
    }
}

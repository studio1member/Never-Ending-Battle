using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2 : MonoBehaviour
{
    private Attack attack;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        attack = GameObject.Find("Skill Manager").GetComponent<Attack>();
    }
    private void Update()
    {
        if (attack.attack_Skill_2) transform.position = GetComponentShikigami.instance.transform.position;
        if (!attack.attack_Skill_2) rb.AddForce(transform.forward * 50000f * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!attack.attack_Skill_2)
        {
            attack.Activate();
        }
    }
}

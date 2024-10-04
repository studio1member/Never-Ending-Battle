using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_EnemyVirtual : MonoBehaviour
{
    public float currentHP, maxHP;
    [SerializeField] Text damage_Text;
    [SerializeField] Transform canvas;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        currentHP = maxHP;
    }
    private void Update()
    {
        canvas.transform.LookAt(transform.position + GetComponentShikigami.instance.change_Perspective.transform.forward);
    }
    public virtual void Apply_Damage(float Damage)
    {
        currentHP += Damage;
        damage_Text.text = (int)Damage + "";
        float ranX = Random.Range(-0.6f, 0.6f);
        float ranY = Random.Range(1.2f, 1.5f);
        Vector3 pos = new Vector3(canvas.position.x + ranX, canvas.position.y + ranY, canvas.position.z);
        damage_Text.transform.position = pos;
        damage_Text.transform.rotation = canvas.rotation;
        damage_Text.gameObject.SetActive(true);
        StartCoroutine(delay());
    }
    public virtual void Apply_Knockback(Vector3 attackerPosition, float knockbackForce)
    {
        Vector3 knockbackDirection = (transform.position - attackerPosition).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        damage_Text.gameObject.SetActive(false);
    }
}

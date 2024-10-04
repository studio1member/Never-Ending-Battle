using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : SkillVirtual
{
    [Header("Attack")]
    [SerializeField] Transform pointAttack;
    [SerializeField] LayerMask enemy;
    [SerializeField] private float rangeAttack;
    [SerializeField] private bool isDisplay = true;
    private int change_Effect_Attack_Button;
    private GameObject effect_1;
    private GameObject effect_2;
    private float changeAttack;
    private float timerChange;

    [Header("Skill 1")]
    //-- Cooldown
    [SerializeField] private float cooldownTime_skill1;
    [SerializeField] private float cooldown_skill1;
    //-- Other
    private bool FixButtonSkill1;
    //-- Getcomponent
    private MeshCollider rangeSkill1_Mesh;
    private GameObject effect_Skill_1;
    private Image colorIconSkill1;
    private Text cooldown_Text;

    [Header("Skill 2")]
    [SerializeField] private float cooldownTimer_skill2;
    [SerializeField] private float cooldown_skill2;
    [SerializeField] Text timer_Text;
    [SerializeField] Image timer_Image;
    [SerializeField] private float timerResetChangeAttack;
    private bool fixErrorSkill_2;
    private bool fixErrorExplostionSkill_2;
    private GameObject effect_Skill_2;
    public bool attack_Skill_2;
    public GameObject effect_Explostion_Skill_2;
    private bool fixColor;
    public override void Awake()
    {
        base.Awake();
        //Attack
        effect_1 = GameObject.Find("Attack 1 Effect");
        effect_1.SetActive(false);
        effect_2 = GameObject.Find("Attack 2 Effect");
        effect_2.SetActive(false);

        //Skill 1
        //-- Getcomponent
        effect_Skill_1 = GameObject.Find("Skill 1 Effect"); effect_Skill_1.SetActive(false);
        colorIconSkill1 = GameObject.Find("Skill 1 Button").GetComponent<Image>();
        cooldown_Text = GameObject.Find("Skill 1 Text").GetComponent<Text>(); cooldown_Text.gameObject.SetActive(false);
        rangeSkill1_Mesh = GameObject.Find("Skill 1 Range Attack").GetComponent<MeshCollider>(); rangeSkill1_Mesh.enabled = false;

        //Skill 2
        effect_Skill_2 = GameObject.Find("Skill 2 Effect");
        effect_Skill_2.SetActive(false);
        effect_Explostion_Skill_2 = GameObject.Find("Skill 2 Epxlostion Effect");
        effect_Explostion_Skill_2.SetActive(false);
        timer_Text = GameObject.Find("Skill 2 Text").GetComponent<Text>();
    }
    private void Update()
    {
        Timer();
    }
    private void Timer()
    {
        //Attack
        if (timerChange >= 0) timerChange -= Time.deltaTime;
        if (timerResetChangeAttack >= 0) timerResetChangeAttack -= Time.deltaTime;
    }
    //Attack
    public override void Attack_Down()
    {
        base.Attack_Down();
        if (timerResetChangeAttack <= 0) changeAttack = 0;
        Change_Effect_Attack_Button();

        if (changeAttack < 1 && timerChange <= 0)
        {
            Collider[] enemy = Physics.OverlapSphere(pointAttack.position, rangeAttack, this.enemy);
            foreach (Collider hitEnemy in enemy) {
                hitEnemy.GetComponent<HP_EnemyVirtual>().Apply_Damage(-StatusPlayerVirtual.instance.damage);
                hitEnemy.GetComponent<HP_EnemyVirtual>().Apply_Knockback(transform.position, 10f);
            }
            effect_1.SetActive(false);
            effect_1.SetActive(true);
            GetComponentShikigami.instance.animator_Shikigami.SetTrigger("attack");
            changeAttack = 1;
            timerChange = 0.5f;
            timerResetChangeAttack = 3f;
        }
        else if(changeAttack < 2 && timerChange <= 0)
        {
            Collider[] enemy = Physics.OverlapSphere(pointAttack.position, rangeAttack, this.enemy);
            foreach (Collider hitEnemy in enemy){
                hitEnemy.GetComponent<HP_EnemyVirtual>().Apply_Damage(-StatusPlayerVirtual.instance.damage);
                hitEnemy.GetComponent<HP_EnemyVirtual>().Apply_Knockback(transform.position, 10f);
            }
            effect_2.SetActive(false);
            effect_2.SetActive(true);
            GetComponentShikigami.instance.animator_Shikigami.SetTrigger("attack 2");
            changeAttack = 2f;
            timerChange = 0.5f;
            timerResetChangeAttack = 3f;
        }
        else if(changeAttack < 3 && timerChange <= 0)
        {
            Collider[] enemy = Physics.OverlapSphere(pointAttack.position, rangeAttack, this.enemy);
            foreach (Collider hitEnemy in enemy) {
                hitEnemy.GetComponent<HP_EnemyVirtual>().Apply_Damage(-StatusPlayerVirtual.instance.damage * 1.8f);
                hitEnemy.GetComponent<HP_EnemyVirtual>().Apply_Knockback(transform.position, 15f);
            } 

            effect_1.SetActive(false);
            effect_2.SetActive(false);
            effect_1.SetActive(true);
            effect_2.SetActive(true);
            GetComponentShikigami.instance.animator_Shikigami.SetTrigger("attack 3");
            changeAttack = 0;
            timerChange = 0.5f;
            timerResetChangeAttack = 3f;
        }
    }
    private void Change_Effect_Attack_Button()
    {
        if (change_Effect_Attack_Button == 0)
        {
            change_Effect_Attack_Button++;
            effect_Attack_Button_List[change_Effect_Attack_Button].gameObject.SetActive(false);
        }
        else if (change_Effect_Attack_Button > 0)
        {
            change_Effect_Attack_Button = 0;
            effect_Attack_Button_List[change_Effect_Attack_Button].gameObject.SetActive(false);
        }
    }
    public override void Attack_Up()
    {
        base.Attack_Up();

        effect_Attack_Button_List[change_Effect_Attack_Button].gameObject.SetActive(true);
    }
    private void OnDrawGizmos()
    {
        if (!isDisplay) return;
        Gizmos.DrawSphere(pointAttack.position, rangeAttack);
    }
    //Skill 1
    public override void Skill_1_Down()
    {
        base.Skill_1_Down();
        if (cooldown_skill1 > 0 || StatusPlayerVirtual.instance.current_MP < 20) return;
        GetComponentShikigami.instance.animator_Shikigami.SetTrigger("skill 1 activity 1");
        colorIconSkill1.color = new Color(0.5f, 0.5f, 0.5f);
        FixButtonSkill1 = false;
        touchCameraLook.SetTouch = 1;
        GetComponentShikigami.instance.autoLookSkill = true;
    }
    public override void Skill_1_Up()
    {
        base.Skill_1_Up();
        if (cooldown_skill1 > 0) return;
        if (FixButtonSkill1) return;
        StartCoroutine(Activate_Skill_1());
    }
    private IEnumerator Activate_Skill_1()
    {
        StatusPlayerVirtual.instance.current_MP -= 20f;
        FixButtonSkill1 = true;
        GetComponentShikigami.instance.animator_Shikigami.SetTrigger("skill 1 activity 2");
        cooldown_skill1 = cooldownTime_skill1;
        GetComponentShikigami.instance.autoLookSkill = false;
        touchCameraLook.SetTouch = 0;
        effect_Skill_1.SetActive(false);
        effect_Skill_1.SetActive(true);
        cooldown_Text.gameObject.SetActive(true);
        StartCoroutine(Cooldown_Skill1());
        rangeSkill1_Mesh.enabled = true;
        yield return new WaitForSeconds(0.1f);
        rangeSkill1_Mesh.enabled = false;
    }
    private IEnumerator Cooldown_Skill1()
    {
        while(cooldown_skill1 > 0)
        {
            cooldown_skill1 -= Time.deltaTime;
            cooldown_Text.text = "" + (int)cooldown_skill1;
            if (cooldown_skill1 <= 0.5f) 
            {
                colorIconSkill1.color = new Color(1, 1, 1);
                cooldown_Text.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
    //Skill 2
    public override void Skill_2_Down()
    {
        base.Skill_2_Down();
        fixErrorSkill_2 = true;
        if (cooldownTimer_skill2 > 0 || StatusPlayerVirtual.instance.current_MP < 40) return; //cooldown
        Activate_Skill_2_Down();
    }
    private void Activate_Skill_2_Down()
    {
        change_Perspective.SetPointB(2f, 0, 6f, 1);
        // tụ lực
        Timer_TuLuc = 0.7f;
        TuLuc = 0;
        Tuluc_Max = 2;
        TuLuc_Image.gameObject.SetActive(true);

        fixErrorSkill_2 = false; // fix không kích hoạt khi nhả tay khỏi nút
        touchCameraLook.SetTouch = 2; //set để xoay camera
        GetComponentShikigami.instance.isLook = true; //nhìn theo hướng camera

        // chuyển dộng, hiệu ứng, check xem đã nhả tay ra khỏi nút chx để thi triển chiêu
        GetComponentShikigami.instance.animator_Shikigami.SetTrigger("skill 2 on");
        effect_Skill_2.SetActive(true);
        attack_Skill_2 = true;
    }
    public override void Skill_2_Up()
    {
        base.Skill_2_Up();
        if (fixErrorSkill_2) return; //cooldown
        Activate_Skill_2_Up();
    }
    private void Activate_Skill_2_Up()
    {
        StatusPlayerVirtual.instance.current_MP -= 40f;
        change_Perspective.ResetPoint(1f);
        cooldownTimer_skill2 = cooldown_skill2; //reset thời gian cooldown
        TuLuc_Image.gameObject.SetActive(false); //ảnh tụ lực tắtt
        touchCameraLook.SetTouch = 0; //set touch
        StartCoroutine(GetComponentShikigami.instance.fixLook()); // fix player khi thi triển chiêu thức bị ngã
        GetComponentShikigami.instance.animator_Shikigami.SetTrigger("skill 2 off"); //tắt chuyển động chiêu 2
        GetComponentShikigami.instance.isLook = false; //không nhìn theo hướng camera
        fixErrorExplostionSkill_2 = true; //fix khi chiêu đã nổ sẽ không kích hoạt nx
        StartCoroutine(ActivateSeconds()); //kích hoạt nổ
        effect_Skill_2.transform.SetParent(null); //cho chiêu nổ ra khỏi objecct
        attack_Skill_2 = false; //chiêu phải bắn ra mới nổ
        Change_Damage_Tuluc_Skill_2(); // tính damage chiêu 2
        StartCoroutine(Cooldown_Skill2());
    }
    private IEnumerator Cooldown_Skill2()
    {
        while (cooldown_skill2 > 0)
        {
            cooldown_skill2 -= Time.deltaTime;
            yield return null;
        }
    }
    public void Activate()
    {
        fixErrorExplostionSkill_2 = false;
        effect_Explostion_Skill_2.SetActive(true);
        effect_Explostion_Skill_2.transform.position = effect_Skill_2.transform.position;
        effect_Explostion_Skill_2.transform.SetParent(null);
        effect_Skill_2.transform.SetParent(GetComponentShikigami.instance.transform);
        effect_Skill_2.transform.position = Vector3.zero;
        effect_Skill_2.SetActive(false);
        effect_Explostion_Skill_2.transform.rotation = Quaternion.Euler(0, 0, 0);
        StartCoroutine(DisableSeconds());
    }
    IEnumerator ActivateSeconds()
    {
        yield return new WaitForSeconds(1f);
        if (fixErrorExplostionSkill_2)
        {
            effect_Explostion_Skill_2.SetActive(true);
            effect_Explostion_Skill_2.transform.position = effect_Skill_2.transform.position;
            effect_Explostion_Skill_2.transform.SetParent(null);
            effect_Skill_2.transform.position = GetComponentShikigami.instance.transform.position;
            effect_Skill_2.transform.SetParent(GetComponentShikigami.instance.transform);
            effect_Skill_2.SetActive(false);
            StartCoroutine(DisableSeconds());
        }
    }
    IEnumerator DisableSeconds()
    {
        yield return new WaitForSeconds(3f);
        effect_Explostion_Skill_2.SetActive(false);
        effect_Explostion_Skill_2.transform.position = GetComponentShikigami.instance.transform.position;
        effect_Explostion_Skill_2.transform.SetParent(GetComponentShikigami.instance.transform);
        effect_Skill_2.transform.rotation = GetComponentShikigami.instance.transform.rotation;
    }
    private void Change_Damage_Tuluc_Skill_2()
    {
        damage_Skill_2 = StatusPlayer.instance.damage * ((TuLuc / Tuluc_Max) * 2.5f);
    }
}

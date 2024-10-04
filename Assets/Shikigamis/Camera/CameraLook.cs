using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform CameraMain, Camera_Look;
    public Vector2 LockAxis;
    public float Sensivity = 40f;
    public FixedTouchField touch, touch_Skill_1, touch_Skill_2, touch_Skill_3;
    public int SetTouch;
    private void Awake()
    {
        CameraMain = GameObject.Find("CameraMain").transform;
        touch = GameObject.Find("Touch").GetComponent<FixedTouchField>();
        touch_Skill_1 = GameObject.Find("Skill 1 Button").GetComponent<FixedTouchField>();
        touch_Skill_2 = GameObject.Find("Skill 2 Button").GetComponent<FixedTouchField>();
        touch_Skill_3 = GameObject.Find("Skill 3 Button").GetComponent<FixedTouchField>();
    }
    void Update()
    {
        if (SetTouch == 0) LockAxis = touch.TouchDist;
        if (SetTouch == 1) LockAxis = touch_Skill_1.TouchDist;
        if (SetTouch == 2) LockAxis = touch_Skill_2.TouchDist;
        if (SetTouch == 3) LockAxis = touch_Skill_3.TouchDist;

        XMove = LockAxis.x * Sensivity * Time.deltaTime;
        YMove = LockAxis.y * Sensivity * Time.deltaTime;
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -10f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation,0,0);
        CameraMain.Rotate(Vector3.up * XMove);
    }
}

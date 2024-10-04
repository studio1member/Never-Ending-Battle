using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class GetComponentShikigami : MonoBehaviour
{
    public static GetComponentShikigami instance;
    public bool isGetcomponent;
    [Header("Shikigami")]
    public FloatingJoystick joystick_Shikigami;
    public Rigidbody rigidbody_Shikigami;
    public Animator animator_Shikigami;
    public GameObject checkGround;
    public bool isCheckGround;
    public bool isLook;

    [Header("Jump Shikigami")]
    public float jumpForce;

    [Header("Camera")]
    public GameObject CameraMain;
    public GameObject HolderCamera;
    public GameObject change_Perspective;
    public bool autoLook;
    public bool autoLookSkill;
    public void Awake()
    {
        instance = this;

        joystick_Shikigami = GameObject.Find("Shikigami Joystick").GetComponent<FloatingJoystick>();
        rigidbody_Shikigami = GetComponent<Rigidbody>();
        animator_Shikigami = GetComponent<Animator>();
        checkGround = GameObject.Find("Check Ground");

        CameraMain = GameObject.Find("CameraMain");
        HolderCamera = GameObject.Find("Holder");
        change_Perspective = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        RotationShikigami();
    }
    public IEnumerator fixLook()
    {
        yield return new WaitForSeconds(0.1f);
        transform.forward = CameraMain.transform.forward;
    }
    private void RotationShikigami()
    {
        if (isLook)
        {
            transform.forward = change_Perspective.transform.forward;
        }
        else if (GetComponentShikigami.instance.autoLookSkill)
        {
            transform.forward = CameraMain.transform.forward;
        }
        else if (GetComponentShikigami.instance.joystick_Shikigami.Vertical != 0 || GetComponentShikigami.instance.joystick_Shikigami.Vertical != 0)
        {
            Vector3 forward = joystick_Shikigami.Vertical * CameraMain.transform.forward + joystick_Shikigami.Horizontal * CameraMain.transform.right;
            transform.forward = forward;
        }
        else if (GetComponentShikigami.instance.autoLook)
        {
            transform.forward = CameraMain.transform.forward;
        }
    }
}

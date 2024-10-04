using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSikigami : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float move_Speed;
    [SerializeField] private float groundDrag;
    [SerializeField] private float mulTiplier;

    [Header("Check Ground")]
    [SerializeField] private LayerMask whatIsGround;
    private void Update()
    {
        Check_Ground();
    }
    private void FixedUpdate()
    {
        Move_Shikigami();
    }
    private void Check_Ground()
    {
        GetComponentShikigami.instance.isCheckGround = Physics.Raycast(GetComponentShikigami.instance.checkGround.transform.position, Vector3.down, 0.1f, whatIsGround);
    }
    private void Move_Shikigami()
    {
        FloatingJoystick joystick_Shikigami = GetComponentShikigami.instance.joystick_Shikigami;
        Transform CameraMain = GetComponentShikigami.instance.CameraMain.transform;

        // move
        Vector3 move = joystick_Shikigami.Vertical * CameraMain.transform.forward + joystick_Shikigami.Horizontal * CameraMain.transform.right;

        if (GetComponentShikigami.instance.isCheckGround) GetComponentShikigami.instance.rigidbody_Shikigami.AddForce(move * move_Speed * Time.deltaTime);
        else GetComponentShikigami.instance.rigidbody_Shikigami.AddForce(move * move_Speed * mulTiplier * Time.deltaTime);
    }
}

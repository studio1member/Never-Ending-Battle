using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Perspective : MonoBehaviour
{
    public Transform change_Perspective;
    public Vector3 pointA, pointB;
    public float speed, timer;
    private void Awake()
    {
        change_Perspective = GameObject.Find("Change Perspective").transform;
        pointB = new Vector3(change_Perspective.position.x, change_Perspective.position.y, change_Perspective.position.z);
        pointA = new Vector3(change_Perspective.position.x, change_Perspective.position.y, change_Perspective.position.z);
        timer = 0.9f;
    }
    public void SetPointB(float X,float Y,float Z,float speed)
    {
        pointA = pointB;
        pointB = new Vector3(change_Perspective.localPosition.x + X, change_Perspective.localPosition.y + Y, change_Perspective.localPosition.z + Z);
        timer = 0;
        this.speed = speed;
    }
    public void ResetPoint(float speed)
    {
        pointA = pointB;
        pointB = new Vector3(change_Perspective.localPosition.x, change_Perspective.localPosition.y, change_Perspective.localPosition.z);
        timer = 0;
        this.speed = speed;
    }
    private void Update()
    {
        if (timer >= 1) return;
        transform.rotation = change_Perspective.rotation;
        timer += speed * Time.deltaTime;
        transform.localPosition = Vector3.Lerp(pointA, pointB, timer);
    }
}

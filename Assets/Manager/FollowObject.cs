using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private float axisX;
    [SerializeField] private float axisY;
    [SerializeField] private float axisZ;
    void Update()
    {
        Vector3 pos = new Vector3(GetComponentShikigami.instance.HolderCamera.transform.position.x + 
            axisX, GetComponentShikigami.instance.HolderCamera.transform.position.y + axisY, GetComponentShikigami.instance.HolderCamera.transform.position.z + axisZ);
        transform.position = pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float timerDestroy;
    void Start()
    {
        Destroy(gameObject, timerDestroy);
    }
}

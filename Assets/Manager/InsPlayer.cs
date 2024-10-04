using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsPlayer : MonoBehaviour
{
    public static InsPlayer instance;
    public GameObject preftPlayer;
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Ins_Player()
    {
        GameObject insPlayer = Instantiate(preftPlayer);
        insPlayer.name = preftPlayer.name;
    }
}

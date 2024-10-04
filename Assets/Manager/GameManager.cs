using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text shikigami_Name_Text;
    public List<GameObject> Shikigamis;
    private void Awake()
    {
        instance = this;
        shikigami_Name_Text = GameObject.Find("Shikigami Name Text").GetComponent<Text>();
    }
    public void SetShikimagi(int setShikimagi)
    {
        PlayerPrefs.SetInt("Set Shikimagi", setShikimagi);
        InsPlayer.instance.preftPlayer = Shikigamis[setShikimagi];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooseShikigami : MonoBehaviour
{
    [SerializeField] private int set_Shikigami;
    public void Choose_Shikigami()
    {
        GameManager.instance.SetShikimagi(set_Shikigami);
        ChooseShikigamiManager.instance.choose_Shikigami.transform.position = transform.position;
        ChooseShikigamiManager.instance.choose_Shikigami.SetActive(true);
    }
}

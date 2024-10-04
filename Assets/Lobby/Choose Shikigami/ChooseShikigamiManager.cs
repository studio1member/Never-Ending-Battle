using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseShikigamiManager : MonoBehaviour
{
    public GameObject choose_Shikigami;
    public static ChooseShikigamiManager instance;
    private GameObject pleaseChooseShikigami_Text;
    private void Awake()
    {
        instance = this;
        choose_Shikigami = GameObject.Find("Choose Shikigami Image");
        choose_Shikigami.SetActive(false);

        pleaseChooseShikigami_Text = GameObject.Find("Please choose shikigami Text");
        pleaseChooseShikigami_Text.SetActive(false);
    }
    public void Load_Scene()
    {
        if(InsPlayer.instance.preftPlayer == null)
        {
            pleaseChooseShikigami_Text.SetActive(true);
            StartCoroutine(delay());
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        pleaseChooseShikigami_Text.SetActive(false);
    }
}

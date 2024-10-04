using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [Header("Setting Panel")]
    private GameObject setting_Panel, openSettingPanel_Button;
    private bool isOpenOfClone;

    [Header("Sensitivity")]
    private Slider sensitivity_Slider;
    private CameraLook cameraLock;

    [Header("Auto Look")]
    private GameObject autoLook_Button;

    [Header("Shadow")]
    private Transform parentObject;
    private GameObject CastShadowsImage;
    private void Awake()
    {
        instance = this;
        if (InsPlayer.instance != null && GetComponentShikigami.instance == null) InsPlayer.instance.Ins_Player();

        //auto look
        autoLook_Button = GameObject.Find("Auto Look Button Image");
        Awake_IsAutoLook();

        //shadow
        CastShadowsImage = GameObject.Find("Cast Shadows Image");
        parentObject = GameObject.Find("Grounds").transform;
        AwakeShadows();

        //Awake Shikigami
        GetComponentShikigami.instance.isGetcomponent = true;

        //sensitivity
        cameraLock = GameObject.Find("MainCamera").GetComponent<CameraLook>();
        sensitivity_Slider = GameObject.Find("Sensitivity Slider").GetComponent<Slider>();
        Set_Sensitivity();

        //setting panel
        setting_Panel = GameObject.Find("Setting Panel");
        setting_Panel.SetActive(false);
        openSettingPanel_Button = GameObject.Find("Open Setting Panel Button");
    }
    public void OpenOfClone_Button()
    {
        if(isOpenOfClone)
        {
            setting_Panel.SetActive(false);
            isOpenOfClone = false;
            openSettingPanel_Button.SetActive(true);
        }
        else
        {
            openSettingPanel_Button.SetActive(false);
            setting_Panel.SetActive(true);
            isOpenOfClone = true;
        }
    }
    public void Sensitivity_Slider()
    {
        cameraLock.Sensivity = sensitivity_Slider.value;
        PlayerPrefs.SetFloat("sensitivity", sensitivity_Slider.value);
    }
    private void Set_Sensitivity()
    {
        cameraLock.Sensivity = PlayerPrefs.GetFloat("sensitivity");
        sensitivity_Slider.value = PlayerPrefs.GetFloat("sensitivity");
    }
    public void Lobby_Button()
    {
        SceneManager.LoadScene(0);
        Destroy(GameObject.Find("PlayerPreft"));
    }
    public void IsAutoLook()
    {
        if (PlayerPrefs.GetFloat("autoLook") == 0)
        {
            autoLook_Button.SetActive(true);
            GetComponentShikigami.instance.autoLook = true;
            PlayerPrefs.SetFloat("autoLook", 1);
        }
        else
        {
            autoLook_Button.SetActive(false);
            GetComponentShikigami.instance.autoLook = false;
            PlayerPrefs.SetFloat("autoLook", 0);
        }
    }
    public void FPS()
    {
        Application.targetFrameRate = 30;
    }
    public void FPS_()
    {
        Application.targetFrameRate = 60;
    }
    public void FPS__()
    {
        Application.targetFrameRate = 90;
    }
    public void Shadows_Button()
    {
        if (PlayerPrefs.GetFloat("isShadow") == 1)
        {
            foreach (Transform scan in parentObject)
            {
                scan.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                scan.GetComponent<MeshRenderer>().receiveShadows = false;
                PlayerPrefs.SetFloat("isShadow", 0);
                CastShadowsImage.SetActive(false);
            }
        }
        else
        {
            foreach (Transform scan in parentObject)
            {
                scan.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                scan.GetComponent<MeshRenderer>().receiveShadows = true;
                PlayerPrefs.SetFloat("isShadow", 1);
                CastShadowsImage.SetActive(true);
            }
        }
    }
    private void AwakeShadows()
    {
        if (PlayerPrefs.GetFloat("isShadow") == 0)
        {
            foreach (Transform scan in parentObject)
            {
                scan.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                scan.GetComponent<MeshRenderer>().receiveShadows = false;
                CastShadowsImage.SetActive(false);
            }
        }
        else
        {
            foreach (Transform scan in parentObject)
            {
                scan.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                scan.GetComponent<MeshRenderer>().receiveShadows = true;
                CastShadowsImage.SetActive(true);
            }
        }
    }
    private void Awake_IsAutoLook()
    {
        if (PlayerPrefs.GetFloat("autoLook") == 1)
        {
            autoLook_Button.SetActive(true);
            GetComponentShikigami.instance.autoLook = true;
        }
        else
        {
            autoLook_Button.SetActive(false);
            GetComponentShikigami.instance.autoLook = false;
        }
    }
}

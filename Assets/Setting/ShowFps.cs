using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFps : MonoBehaviour
{
    [SerializeField] private Text FPS_Text;
    private float deltaTime = 0f;
    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        float fps = 1.0f / deltaTime;

        FPS_Text.text = "FPS: " + Mathf.Ceil(fps).ToString();
    }
}

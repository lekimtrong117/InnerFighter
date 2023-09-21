using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootForDemoScence : MonoBehaviour
{
    void Start()
    {

        Debug.LogError("Start " + Time.frameCount);

        DataAPIController.Instance.InitData(() =>
        {
            ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
        }
           
        );


    }
    private void Awake()
    {
        Application.targetFrameRate = 120;
        DontDestroyOnLoad(gameObject);

        Debug.LogError("Awake " + Time.frameCount);
    }

    private void OnEnable()
    {
        Debug.LogError("OnEnable " + Time.frameCount);

    }

    private void FixedUpdate()
    {
        Debug.LogError("FixedUpdate " + Time.frameCount);

    }

    private void Update()
    {
        Debug.LogError("Update " + Time.frameCount);

    }
    private void LateUpdate()
    {
        Debug.LogError("LateUpdate " + Time.frameCount);

    }
}

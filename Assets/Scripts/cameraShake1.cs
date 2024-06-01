using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraShake1 : MonoBehaviour
{
    // Start is called before the first frame update
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float ShakeIntensity = 1f;
    private float ShakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Start()
    {
        StopShake();
    }
    private void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmc = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmc.m_AmplitudeGain = ShakeIntensity;

        timer = ShakeTime;
    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ShakeCamera();
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer > 0) 
            {
                StopShake();
            }
        }
    }
}

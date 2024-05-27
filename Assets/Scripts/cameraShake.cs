using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float ShakeIntensity = .25f;
    private float ShakeTime = 0.2f;

    private float timer;
    [SerializeField]
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private Camera _camera;

    private void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

        _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _camera = Camera.main;
    }

    private void Start()
    {
        StopShake();
    }

    public void ShakeCamera()
    {
        _cbmcp.m_AmplitudeGain = ShakeIntensity;

        timer = ShakeTime;
    }

    void StopShake()
    {
        _camera.transform.rotation = Quaternion.identity;

        _cbmcp.m_AmplitudeGain = 0f;

        timer = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShakeCamera();
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                StopShake();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCam;
    [SerializeField] Transform camerasTarget;

    private void Start()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        virtualCam.m_Follow = camerasTarget;
    }
    

}

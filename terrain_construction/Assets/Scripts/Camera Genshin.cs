using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraGenshin : MonoBehaviour
{
    [Range(0f, 10f)] private float defaultDistance = 6f;
    [Range(0f, 10f)] private float maxDistance = 1f;
    [Range(0f, 10f)] private float minDistance = 6f;

    [Range(0f, 10f)] private float smoothing = 4f;
    [Range(0f, 10f)] private float zoomSensitivity = 1f;

    private CinemachineFramingTransposer fraimingTransposer;
    private CinemachineInputProvider inputProvider;

    private float currentTargetDistance;

    private void Awake()
    {
        fraimingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
        inputProvider = GetComponent<CinemachineInputProvider>();

        currentTargetDistance = defaultDistance;
    }

    private void Update()
    {
        Zoom();
    }

    private void Zoom() 
    {
        float zoomValue = Mathf.Clamp(inputProvider.GetAxisValue(2) * zoomSensitivity, minDistance, maxDistance);

        float currentDistance = fraimingTransposer.m_CameraDistance;

        if(currentDistance == currentTargetDistance) 
        {
            return;
        }
        float lerpedZoomValue = Mathf.Lerp(currentDistance, currentTargetDistance, smoothing * Time.deltaTime);
        fraimingTransposer.m_CameraDistance = lerpedZoomValue;
    }
}

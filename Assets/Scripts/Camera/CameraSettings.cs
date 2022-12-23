using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings
{
    public float RightLimit { get; private set; }
    public float LeftLimit { get; private set; }
    public float UpperLimit { get; private set; }
    public float BottomLimit { get; private set; }

    public float ZoomMin { get; private set; }
    public float ZoomMax { get; private set; }
    public float ZoomSensitivity { get; private set; }

    public float CameraSpeed { get; private set; }
    public float ZPos { get; private set; }

    public CameraSettings(float rightLimit, float leftLimit, float upperLimit,
        float bottomLimit, float zoomMin, float zoomMax, float zoomSensitivity, float cameraSpeed, float zPos)
    {
        RightLimit = rightLimit;
        LeftLimit = leftLimit;
        UpperLimit = upperLimit;
        BottomLimit = bottomLimit;

        ZoomMin = zoomMin;
        ZoomMax = zoomMax;
        ZoomSensitivity = zoomSensitivity;
        CameraSpeed = cameraSpeed;
        ZPos = zPos;
    }
}

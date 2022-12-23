using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveBehevior : ICameraBehivior
{
    private Vector3 camPos;
    private Vector3 direction;
    private Camera mainCamera;
    private CameraSettings _cameraSettings;

    public void Enter(CameraSettings cameraSettings)
    {
        _cameraSettings = cameraSettings;
        camPos = Vector3.zero;
        direction = Vector3.zero;
        mainCamera = Camera.main;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            camPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.touchCount == 2)
        {
            Zoom();
        }
        else if (Input.GetMouseButton(0))
        {
            Move();
        }
    }

    private void Move()
    {
        direction = camPos - mainCamera.ScreenToWorldPoint(Input.mousePosition);

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, mainCamera.transform.position + direction, Time.deltaTime * _cameraSettings.CameraSpeed);

        mainCamera.transform.position = new Vector3(
            Mathf.Clamp(mainCamera.transform.position.x, _cameraSettings.LeftLimit, _cameraSettings.RightLimit),
            Mathf.Clamp(mainCamera.transform.position.y, _cameraSettings.BottomLimit, _cameraSettings.UpperLimit),
            _cameraSettings.ZPos);
    }

    private void Zoom()
    {
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOneLastPos = touchOne.position - touchOne.deltaPosition;

        float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
        float currentDistTouch = (touchZero.position - touchOne.position).magnitude;

        float difference = (currentDistTouch - distTouch) * _cameraSettings.ZoomSensitivity;

        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize - difference, _cameraSettings.ZoomMin, _cameraSettings.ZoomMax);

    }
}

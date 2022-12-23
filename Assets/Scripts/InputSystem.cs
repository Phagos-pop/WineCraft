using System;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private float rightLimit;
    [SerializeField] private float leftLimit;
    [SerializeField] private float upperLimit;
    [SerializeField] private float bottomLimit;

    [SerializeField] private float zoomMin;
    [SerializeField] private float zoomMax;
    [SerializeField] private float zoomSensitivity;

    [SerializeField] private float cameraSpeed;
    [SerializeField] private float zPos;

    private CameraSettings cameraSettings;
    private ICameraBehivior currentCameraBehivior;
    private Dictionary<Type, ICameraBehivior> beheviorMap;
    private Camera mainCamera;

    public event Action<Vector3> ClickPosEvent;

    private void Start()
    {
        mainCamera = Camera.main;
        InitCameraSettings();
        InitCameraBehevior();
        SetBeheviorByDefult();
    }

    private void Update()
    {
        CheckClick();

        if (currentCameraBehivior != null)
            currentCameraBehivior.Update();
    }

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            ClickPosEvent?.Invoke(clickWorldPosition);
        }
    }

    #region CameraBehevior

    private void InitCameraSettings()
    {
        cameraSettings = new CameraSettings(rightLimit, leftLimit, upperLimit,
            bottomLimit, zoomMin, zoomMax, zoomSensitivity, cameraSpeed, zPos);
    }

    private void SetBeheviorByDefult()
    {
        SetCameraMoveBehevior();
    }

    private void InitCameraBehevior()
    {
        this.beheviorMap = new Dictionary<Type, ICameraBehivior>();

        this.beheviorMap[typeof(CameraMoveBehevior)] = new CameraMoveBehevior();
        this.beheviorMap[typeof(CameraStaticBehevior)] = new CameraStaticBehevior();
    }

    private void SetBehevior(ICameraBehivior newCameraBehivior)
    {
        if (this.currentCameraBehivior != null)
        {
            this.currentCameraBehivior.Exit();
        }
        this.currentCameraBehivior = newCameraBehivior;
        this.currentCameraBehivior.Enter(cameraSettings);
    }

    private ICameraBehivior GetBehivior<T>() where T : ICameraBehivior
    {
        var type = typeof(T);
        return this.beheviorMap[type];
    }



    public void SetCameraMoveBehevior()
    {
        var behevior = this.GetBehivior<CameraMoveBehevior>();
        this.SetBehevior(behevior);
    }

    public void SetCameraStaticBehevior()
    {
        var behevior = this.GetBehivior<CameraStaticBehevior>();
        this.SetBehevior(behevior);
    }
    #endregion
}

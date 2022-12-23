using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraBehivior
{
    void Enter(CameraSettings cameraSettings);

    void Exit();

    void Update();
}

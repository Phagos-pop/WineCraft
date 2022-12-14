using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float rightLimit;
    [SerializeField] private float leftLimit;
    [SerializeField] private float upperLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float speed;

    private Vector3 CamPos;
    private Vector3 direction;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CamPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        if (Input.GetMouseButton(0))
        {
            Move();
        }
    }

    private void Move()
    {
        direction = CamPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);



        var nextPosition = Vector3.Lerp(transform.position, this.transform.position + direction, Time.deltaTime*speed);

        transform.position = nextPosition;

        transform.position = new Vector3(
            Mathf.Clamp(this.transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(this.transform.position.y, bottomLimit, upperLimit),
            this.transform.position.z);
    }
}

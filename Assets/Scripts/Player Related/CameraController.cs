using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Created by Shane
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Transform target, player;
    [SerializeField] private float touchX, touchY;


    //Only works on pc for now
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            touchX += Input.GetAxis("Mouse X") * rotationSpeed;
            touchY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            touchY = Mathf.Clamp(touchY, -35, 60);

            transform.LookAt(target);

            target.rotation = Quaternion.Euler(touchY, touchX, 0);
        }
    }
}

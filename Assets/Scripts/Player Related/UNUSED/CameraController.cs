using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Created by Shane
    [SerializeField] private float rotationSpeed;
    public float touchX = 0, touchY = 0;
    [SerializeField] private Transform target, player;
    private Vector2 initPos;
    private void LateUpdate()
    {
        /*if (Input.GetMouseButton(0))
        {
            touchX += Input.GetAxis("Mouse X") * rotationSpeed;
            touchY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            touchY = Mathf.Clamp(touchY, -35, 60);

            Debug.Log(touchX);
            transform.LookAt(target);

            target.rotation = Quaternion.Euler(touchY, touchX, 0);
        }*/
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began) initPos = Camera.main.ScreenToViewportPoint(touch.position); //Gets initial position of finger tap
            if (touch.phase == TouchPhase.Moved)
            {
                CameraMovement(touch, initPos);
            }
            if (touch.phase == TouchPhase.Ended) initPos = new Vector2(0, 0);
        } 
    }

    private void CameraMovement(Touch touch, Vector2 init)
    {
        touchX += (Camera.main.ScreenToViewportPoint(touch.position).x - init.x) * rotationSpeed; //Compares current finger X position to initial and changes rotation
        touchY -= (Camera.main.ScreenToViewportPoint(touch.position).y - init.y) * rotationSpeed; //Compares current finger Y position to initial and changes rotation

        touchY = Mathf.Clamp(touchY, -35, 60); //Locks the camera's Y position between -35 and 60

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(touchY, touchX, 0); //Applying changes
    }
}

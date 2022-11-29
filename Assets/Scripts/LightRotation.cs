using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    Vector3 rotation;
    [SerializeField] float rotationTimer = 1;
    [SerializeField] float degrees;

    float tempTimer;

    private void Awake()
    {
        rotation = new(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        tempTimer = rotationTimer;
    }

    private void Update()
    {
        rotationTimer -= Time.deltaTime;
        if (rotationTimer <= 0)
        {
            rotation.y += degrees;
            rotationTimer = tempTimer;

            if (rotation.y >= 360)
            {
                rotation.y = 0;
            }
            transform.eulerAngles = new Vector3(rotation.x, rotation.y, rotation.z);
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 objectPosition;

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        objectPosition = transform.position;
        mousePosition.z = objectPosition.z;

        transform.LookAt(mousePosition, Vector3.forward);
        transform.Rotate(new Vector3(0, 0, 1), 180);
    }
}

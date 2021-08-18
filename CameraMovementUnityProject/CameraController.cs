using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;

    public float mouseSensitivity = 1f;
    public float upLimit = -50;
    public float downLimit = 50;

    float cameraDistanceMax = 20f;
    float cameraDistanceMin = 5f;
    float cameraDistance = 10f;
    float scrollSpeed = 0.5f;

    float minFov = 15f;
    float maxFov = 90f;
    float sensitivity = 10f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CameraRotate();
        }
        CameraZoom();
        transform.LookAt(target);
    }

    public void CameraZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Translate(0, 0, Time.deltaTime * 60, transform);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Translate(0, 0, -Time.deltaTime * 60, transform);
        }
    }

    public void CameraFov()
    {
        var fov = GetComponent<Camera>().fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        GetComponent<Camera>().fieldOfView = fov;
    }

    public void CameraRotate()
    {
        var distanceFromTarget = Vector3.Distance(transform.position, transform.parent.position);

        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Translate(- horizontalRotation * mouseSensitivity, - verticalRotation * mouseSensitivity, 0);

        Vector3 currentRotation = transform.localEulerAngles;
        if (currentRotation.x > 90) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        transform.localRotation = Quaternion.Euler(currentRotation);

        var distanceFromTargetAfterRotation = Vector3.Distance(transform.position, transform.parent.position);
        /*
        while(distanceFromTargetAfterRotation > distanceFromTarget)
        {
            transform.Translate(0, 0, Time.deltaTime * 300, transform);
        }  
        */ //TODO: Fix zooming out
    }

    /*        // transform.Translate(- horizontalRotation * mouseSensitivity, - verticalRotation * mouseSensitivity, 0);
    if(horizontalRotation< 0)
    {
        transform.RotateAround(target.transform.position, Vector3.down* horizontalRotation, 120 * horizontalRotation* Time.deltaTime);
}
    else
{
transform.RotateAround(target.transform.position, Vector3.up * horizontalRotation, 120 * horizontalRotation * Time.deltaTime);
}

if (verticalRotation < 0)
{
transform.RotateAround(target.transform.position, Vector3.right * verticalRotation, 120 * verticalRotation * Time.deltaTime);
}
else
{
transform.RotateAround(target.transform.position, Vector3.left * verticalRotation, 120 * verticalRotation * Time.deltaTime);
}
*/
}

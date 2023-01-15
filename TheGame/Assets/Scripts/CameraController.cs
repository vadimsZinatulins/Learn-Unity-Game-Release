using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float sensitivity = 1.5f;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float minPitchAngle = -40f;
    [SerializeField] private float maxPitchAngle = 65f;

    private float pitch;
    private float yaw;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var rotationSpeed = 180f * sensitivity * Time.deltaTime;

        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, minPitchAngle, maxPitchAngle);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        transform.position = player.transform.position + transform.forward * -distance;
    }
}

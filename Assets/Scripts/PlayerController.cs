using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float turnSpeed = 0.1f;

    private float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move.magnitude > 1f)
        {
            move.Normalize();
        }

        var targetRotation = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

        if (move != Vector3.zero)
        {
            var rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSpeed);

            transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        }

        var targetDirection = Quaternion.Euler(0f, targetRotation, 0f) * Vector3.forward;

        transform.Translate(targetDirection.normalized * move.magnitude * speed * Time.deltaTime);
    }
}

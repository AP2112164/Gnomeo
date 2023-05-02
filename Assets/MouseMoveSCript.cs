using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveSCript : MonoBehaviour
{

    public Transform mainCamera;
    float angle = 0;
    Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * 5);

        angle = Mathf.Clamp(Input.GetAxis("Mouse Y") * -5 + angle, -60, 60);
        mainCamera.localRotation = Quaternion.Euler(new Vector3(angle, 0, 0));

        Vector3 velocity = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * 1;
        velocity.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = velocity;
    }
}

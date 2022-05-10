using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cam;
    public Rigidbody ball;
    public float speed;
    public float jumpForce;
    bool CanJump;

    void Start()
    {
        LockMouse();
    }

    void Update()
    {
        CheckInput();
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CheckInput()
    {
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;
        Vector3 up = cam.up;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            ball.AddForce(forward * speed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            ball.AddForce(right * speed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            ball.AddForce(right * -speed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            ball.AddForce(forward * -speed, ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            ball.AddForce(up * jumpForce, ForceMode.Impulse);
            OnCollisionExit();
        }
    }

    private void OnCollisionEnter()
    {
        GetComponent<Renderer>().material.color = Color.green;
        CanJump = true;
    }

    private void OnCollisionExit()
    {
        GetComponent<Renderer>().material.color = Color.red;
        CanJump = false;
    }
}

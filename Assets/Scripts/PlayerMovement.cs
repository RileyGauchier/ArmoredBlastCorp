using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float roatationSpeed = 120.0f;
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;

    public float wheelRoationSpeed = 200.0f;

    private Rigidbody _rigidbody;
    private float _moveInput;
    private float _rotationInput;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = Input.GetAxis("Vertical");
        _rotationInput = Input.GetAxis("Horizontal");

        RotateWheels(_moveInput, _rotationInput);
    }

    void FixedUpdate()
    {
        MoveTankObj(_moveInput);
        RotateTank(_rotationInput);
    }

    void MoveTankObj(float input)
    {
        Vector3 moveDirection = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + moveDirection);        
    }

    void RotateTank(float input)
    {
        float rotation = input * roatationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        _rigidbody.MoveRotation(_rigidbody.rotation *  turnRotation);
    }

    void RotateWheels(float moveInput, float rotationInput)
    {
        float wheelRotation = moveInput * wheelRoationSpeed * Time.deltaTime;
        foreach(GameObject wheel in leftWheels) 
            if (wheel != null)
                {
                wheel.transform.Rotate(wheelRotation - rotationInput * wheelRoationSpeed * Time.deltaTime, 0.0f, 0.0f);
                }
        foreach (GameObject wheel in rightWheels)
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation + rotationInput * wheelRoationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }

    }
}

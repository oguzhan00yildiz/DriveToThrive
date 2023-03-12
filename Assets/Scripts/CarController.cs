using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarController : MonoBehaviour
{
   private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;
    private float spd;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;
    [SerializeField] private float  maxSpeed;
    [SerializeField] private bool fourWheelDrive, frontWheelDrive,brakeFourWheel,brakeFrontWheel;
    [SerializeField]private TMP_Text speedText;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;



    private void FixedUpdate() {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
}

private void GetInput() {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");
        // Acceleration Input
       // verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput =1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (spd<=8)
            {
               verticalInput =-1f; 
            }
            else
            {
                isBreaking = true;
                ApplyBreaking();
            }
            
        }
        else
        {
            verticalInput=0f;
        }
    }

    private void HandleMotor() {
        if (fourWheelDrive)
        {
            frontWheelDrive=false;
            rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
            rearRightWheelCollider.motorTorque = verticalInput * motorForce;
            frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
            frontRightWheelCollider.motorTorque = verticalInput * motorForce;
            
        }
        else if (frontWheelDrive)
        {
            frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
            frontRightWheelCollider.motorTorque = verticalInput * motorForce;
            
        }
        else
        {
            rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
            rearRightWheelCollider.motorTorque = verticalInput * motorForce;
            
        }
        

        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking() 
    {
        if (brakeFourWheel)
        {
            brakeFrontWheel=false;
            frontRightWheelCollider.brakeTorque = currentbreakForce;
            frontLeftWheelCollider.brakeTorque = currentbreakForce;
            rearLeftWheelCollider.brakeTorque = currentbreakForce;
            rearRightWheelCollider.brakeTorque = currentbreakForce;
        }
        else if (brakeFrontWheel)
        {
            frontRightWheelCollider.brakeTorque = currentbreakForce;
            frontLeftWheelCollider.brakeTorque = currentbreakForce;
        }
        else
        {
            rearLeftWheelCollider.brakeTorque = currentbreakForce;
            rearRightWheelCollider.brakeTorque = currentbreakForce;
        }
        
            
        
    }

    private void HandleSteering() 
    
    {
        float speedFactor = GetComponent<Rigidbody>().velocity.magnitude / maxSpeed; // Calculate the speed factor
        float currentSpeedSteering = Mathf.Lerp(0, maxSteerAngle, speedFactor); // Interpolate the steering angle based on speed
        currentSteerAngle = (maxSteerAngle-currentSpeedSteering) * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
        spd =GetComponent<Rigidbody>().velocity.magnitude;
        speedText.text= ((int)spd).ToString() ; 
    }

    private void UpdateWheels() {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
     {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

}

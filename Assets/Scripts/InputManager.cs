using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions OnFoot;
    private Vector2 MovmentInput;
    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        
        OnFoot.Jump.performed += ctx => motor.Jump();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playermotor to move using the value from our movment ation.
        motor.ProcessMove(OnFoot.Movment.ReadValue<Vector2>());

    }
    private void LateUpdate()
    {
        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        OnFoot.Enable();
    }
    private void OnDisable()
    {
        OnFoot.Disable();
    }
}

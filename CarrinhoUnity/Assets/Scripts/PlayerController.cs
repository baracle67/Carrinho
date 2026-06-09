using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 45f;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] InputActionAsset inputActions;
    InputAction moveAction;

    void Awake ()
    {
        moveAction = inputActions.FindAction("Move");
    }

    void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable(); 
        inputActions.FindActionMap("UI").Disable(); 
    }

    void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable(); 
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
    
        if (verticalInput > 0)
        {
            // Move o ve�culo para frente a partir do Input vertical
            transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        }
        // Rotaciona o carro a partir do Input horizontal
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x);
    }
}

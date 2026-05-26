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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        verticalInput = moveAction.ReadValue<Vector2>().y;
        if (verticalInput > 0)
        {
            // Move o ve�culo para frente a partir do Input vertical
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }
        // Rotaciona o carro a partir do Input horizontal
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}

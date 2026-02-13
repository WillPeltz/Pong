using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;
    public float maxZ = 5f;
    public Key upKey;
    public Key downKey;
    public bool left = true;

    [Header("Input System")]
    public InputActionReference moveAction;

    void OnEnable()
    {
        if (moveAction != null)
            moveAction.action.Enable();
    }

    void OnDisable()
    {
        if (moveAction != null)
            moveAction.action.Disable();
    }

    void Update()
    {
        if (moveAction == null) return;

        float move = moveAction.action.ReadValue<float>();

        Vector3 newPosition = transform.position +
            new Vector3(0f, 0f, move * speed) * Time.deltaTime;

        newPosition.z = Mathf.Clamp(newPosition.z, -maxZ, maxZ);
        transform.position = newPosition;
    }
}

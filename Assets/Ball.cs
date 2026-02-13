using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 8f;
    public float acceleration = 0.75f;
    public float maxAngle = 60f;

    public Transform spawnPoint;

    private Rigidbody rb;
    private float currentSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;

        currentSpeed = speed;
    }

    public void Reset(bool left)
    {
        currentSpeed = speed;
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Vector3 direction = left ? Vector3.left : Vector3.right;
        rb.velocity = direction * currentSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if (paddle == null) return;

        currentSpeed += acceleration;

        float offset = (transform.position.z - paddle.transform.position.z) / 2;
        float xDir = paddle.left ? 1f : -1f;

        Vector3 dir = new Vector3(xDir, 0f, offset).normalized;
        rb.velocity = dir * currentSpeed;
    }
}

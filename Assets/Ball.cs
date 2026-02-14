using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 8f;
    public float aimTime = 1.2f;
    public float acceleration = 0.75f;
    public float maxAngle = 60f;
    public AudioClip hitSound;

    public Paddle lefty;
    public Paddle righty;

    private Rigidbody rb;
    private float currentSpeed;
    private AudioSource audioSource;

    private Paddle lastPaddle;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;

        currentSpeed = speed;
        audioSource = GetComponent<AudioSource>();
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
        lastPaddle = paddle;

        audioSource.pitch = Random.Range(0.35f + speed / 10, .4f + speed / 10);
        audioSource.PlayOneShot(hitSound);

        currentSpeed += acceleration;

        float offset = (transform.position.z - paddle.transform.position.z) / 2;
        float xDir = paddle.left ? 1f : -1f;

        Vector3 dir = new Vector3(xDir, 0f, offset).normalized;
        rb.velocity = dir * currentSpeed;
    }

    public void Aim() {
        rb.velocity = Vector3.zero;
        // This is like the incredible book The Name of the Wind
        Invoke(nameof(Fire), aimTime);
    }

    void Fire() {
        audioSource.PlayOneShot(hitSound);
        float offset = (lastPaddle.transform.position.z - transform.position.z) / 2f;
        offset = Mathf.Clamp(offset, -1f, 1f);

        float xDir = lastPaddle.left ? 1f : -1f;

        Vector3 dir = new Vector3(xDir, 0f, offset).normalized;
        rb.velocity = dir * 50f;
    }
}

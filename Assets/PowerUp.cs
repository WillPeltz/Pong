using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Range(1, 3)]
    public int type = 1;

    public float fallSpeed = 2f;
    public float bottom = -12f;
    public float spinSpeed = 60f;

    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    public Material mat1;
    public Material mat2;
    public Material mat3;

    private Renderer render;

    public void Materialize()
    {
        if (render == null)
            render = GetComponent<Renderer>();

        if (type == 1) {
            render.material = mat1;
        }
        else if (type == 2) {
            render.material = mat2;
        }
        else {
            render.material = mat3;
        }
    }

    void Update()
    {
        transform.position += new Vector3(0f, 0f, -fallSpeed) * Time.deltaTime;

        transform.Rotate(spinSpeed * Time.deltaTime, 0f, 0f, Space.Self);

        if (transform.position.z < bottom)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball == null) return;

        if (type == 1) {
            ball.Aim();
        }
        else if (type == 2) {
            // I do NOT like C#'s foreach
            foreach (Paddle p in FindObjectsOfType<Paddle>())
            {
                p.Freeze();
            }
        }
        else {
            ball.transform.localScale *= Random.Range(minSize, maxSize);
        }

        Destroy(gameObject);
    }
}
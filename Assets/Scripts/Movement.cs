using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime * acceleration;
        rb.velocity = transform.forward * speed;
    }
}

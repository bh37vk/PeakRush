using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float timeTillAccel;
    public float intervalBetweenAccel;
    // Start is called before the first frame update
    void increaseSpeed()
    {
        speed = speed + acceleration;
    }
    void Start()
    {
        InvokeRepeating("increaseSpeed", timeTillAccel, intervalBetweenAccel);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

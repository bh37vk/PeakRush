using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed;
    public int acceleration;
    public int timeTillAccel;
    public int intervalBetweenAccel;
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

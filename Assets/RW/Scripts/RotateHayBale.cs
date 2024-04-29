using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHayBale : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public float translationSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
        //transform.Translate(0, 0, translationSpeed);
    }
}

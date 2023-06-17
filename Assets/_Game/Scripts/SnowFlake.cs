using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : MonoBehaviour
{
    public float fallSpeed = 1f;// Toc do roi cua bang
    public float rotationSpeed = 50f; // Toc do quay cua bang

    // Update is called once per frame
    void Update()
    {
        // Di chuyen bang roi theo truc y
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        // Quay bang theo toc do quay
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}

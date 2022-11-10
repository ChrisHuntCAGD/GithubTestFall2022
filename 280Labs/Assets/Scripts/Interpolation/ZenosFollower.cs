using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenosFollower : MonoBehaviour
{
    public GameObject poi;
    public float u = 0.1f;
    public Vector3 p0, p1, p01;

    private void Update()
    {
        p0 = transform.position;
        p1 = transform.position;

        p01 = (1 - u) * p0 + u * p1;

        transform.position = p01;
    }
}

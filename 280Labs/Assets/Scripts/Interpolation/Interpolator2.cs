using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public enum EasingType
{
    linear,
    easeIn,
    easeOut,
    easeInOut,
    sin,
    sinIn,
    sinOut,
}


public class Interpolator2 : MonoBehaviour
{
    public Transform c0, c1;
    public float timeDuration = 1f;
    public bool checkToCalculate;

    public Vector3 p01;
    public Color c01;
    public Quaternion r01;
    public Vector3 s01;
    public bool moving = false;
    public float timeStart;

    public bool loopMove = true;

    [SerializeField]
    private float uMin = 0f;
    [SerializeField]
    private float uMax = 1f;
    [SerializeField]
    private EasingType easingType = EasingType.linear;
    [SerializeField]
    private float easingMod = 2;

    void Update()
    {
        if(checkToCalculate)
        {
            checkToCalculate = false;
            moving = true;
            timeStart = Time.time;
        }

        if(moving)
        {
            float u = (Time.time - timeStart) / timeDuration;

            if(u >= 1)
            {
                if(loopMove)
                {
                    timeStart = Time.time;
                }
                else
                {
                    moving = false;
                }
            }

            //adjust u to the range from uMin to uMax
            //u = (1 - u) * uMin + u * uMax;
            u = EaseU(u, easingType, easingMod);

            //standard linear interpolation
            p01 = (1 - u) * c0.position + u * c1.position;
            c01 = (1 - u) * c0.GetComponent<Renderer>().material.color + u * c1.GetComponent<Renderer>().material.color;
            s01 = (1 - u) * c0.localScale + u * c1.localScale;

            //rotations are different because
            //quaternions are weird

            r01 = Quaternion.Slerp(c0.rotation, c1.rotation, u);

            //apply the new values to the cube in order to morph
            transform.position = p01;
            GetComponent<Renderer>().material.color = c01;
            transform.localScale = s01;
            transform.rotation = r01;
        }
    }

    private float EaseU(float u, EasingType eType, float eMod)
    {
        float u2 = u;

        switch (eType)
        {
            case EasingType.linear:
                break;
            case EasingType.easeIn:
                u2 = Mathf.Pow(u, eMod);
                break;
            case EasingType.easeOut:
                u2 = 1 - Mathf.Pow(1 - u, eMod);
                break;
            case EasingType.easeInOut:
                if(u <= 0.5f)
                {
                    u2 = 0.5f * Mathf.Pow(u * 2, eMod);
                }
                else
                {
                    u2 = 0.5f + 0.5f * (1 - Mathf.Pow(1 - (2 * (u - 0.5f)), eMod));
                }
                break;
            case EasingType.sin:
                u2 = u + eMod * Mathf.Sin(2 * Mathf.PI * u);
                break;
            case EasingType.sinIn:
                u2 = 1 - Mathf.Cos(u * Mathf.PI * 0.5f);
                break;
            case EasingType.sinOut:
                u2 = Mathf.Sin(u * Mathf.PI * 0.5f);
                break;
            default:
                print("What EaseU?");
                break;
        }

        return u2;
    }
}
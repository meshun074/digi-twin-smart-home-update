using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunOperation : MonoBehaviour
{
    //axes of the sun
    public GameObject sunRotationAxis;
    //speed of the sun rotation
    private float sunRotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        sunRotationSpeed = 5 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the sun around its axis on the z axis
        GetComponent<Transform>().RotateAround(sunRotationAxis.transform.position, Vector3.back, sunRotationSpeed);
        //Debug.Log(GetComponent<Transform>().rotation.x);
    }
}

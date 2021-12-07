using System.Collections;
using UnityEngine;

public class mainDoorSensor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
      if(securitycontrol.mainDoorInstance.transform.localRotation.z<=0)
        {
            securitycontrol.mainDoorSensor = true;
            securitycontrol.mainDoorControl();
        }
                   
    }

    private void OnTriggerExit(Collider other)
    {
        securitycontrol.mainDoorSensor = true;
        securitycontrol.mainDoorControl();
    }
}
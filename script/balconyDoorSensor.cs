using UnityEngine;

public class balconyDoorSensor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(securitycontrol.baconyDoorInstance.transform.localRotation.z<=0)
        {
            securitycontrol.baconyDoorSensor = true;
            securitycontrol.baconyDoorControl();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        securitycontrol.baconyDoorSensor = true;
        securitycontrol.baconyDoorControl();
    }
}
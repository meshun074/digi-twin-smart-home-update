using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    public GameObject maincamera;

    // Update is called once per frame
    void Update()
    {
        if(serverControlHub.getClientMessage()== "F" /*Input.GetKeyDown(KeyCode.F)*/)
        {
            serverControlHub.msg = "";
            if (GetComponent<AudioSource>().isPlaying==true)
            {
                GetComponent<AudioSource>().Stop();
            }
            else
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==maincamera)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}

//F
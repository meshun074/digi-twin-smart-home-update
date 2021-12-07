using UnityEngine.Audio;
using UnityEngine;

public class climateChangeSystem : MonoBehaviour
{
    //declaring the closing fence of the AC
    public GameObject close_1;
    public GameObject close_2;
    private bool on=false;
    private bool operate = false;
 
    void Update()
    {
        //If a is pressed AC is turn off or on and the fence starts operating
        if(serverControlHub.getClientMessage() == "A"/* Input.GetKeyDown(KeyCode.A)*/)
        {
            serverControlHub.msg = "";
            on = !on;
            operate = true;
            //if, on play sound
            if(on)
            {
                close_1.GetComponent<AudioSource>().PlayDelayed(2f);
                close_2.GetComponent<AudioSource>().PlayDelayed(2f);
            }
            else
            {//stop playing sound if off
                close_1.GetComponent<AudioSource>().Stop();
                close_2.GetComponent<AudioSource>().Stop();
            }
        }
        operateAC();
        
    }

    private void operateAC()
    {
        if (operate)
        {//when on, operate fence when it has not open to it limits
            if (on)
            {
                if (close_1.transform.localPosition.y < 3f)
                {
                    operate = false;
                }
                else
                {
                    close_1.transform.Translate(Vector3.back * 0.007f);
                    close_2.transform.Translate(Vector3.back * 0.007f);
                }

            }//when off, stop operating when it has close to  its limits
            else
            {
                if (close_1.transform.localPosition.y > 4.04f)
                {
                    operate = false;
                }
                else
                {
                    close_1.transform.Translate(Vector3.forward * 0.007f);
                    close_2.transform.Translate(Vector3.forward * 0.007f);
                }
            }
        }
    }
}
//input
//A
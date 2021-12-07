using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Renderer))]
public class entertainmentSystem : MonoBehaviour
{
    public GameObject speaker;
    public GameObject player;
    public GameObject videoPlayer;
    public GameObject hallTV;
    public GameObject MBTV;
    private bool musicPlay=false;
    private bool tvPlay = false;
    private bool pause = false;
    private int music = 1;
    private bool flashLight = true;
    Material[] playerMat;
    Material[] hallTVMat;
    Material[] mbTVMat;
    new  Renderer renderer; // new hides the parent <renderer> property.
    Material speakerMat;
    Color emissionColor;
    Color tvColor;

    private void Start()
    {
        //get player material component
        playerMat = player.GetComponent<Renderer>().materials;
        hallTVMat = hallTV.GetComponent<Renderer>().materials;
        mbTVMat = MBTV.GetComponent<Renderer>().materials;
        // Gets access to the renderer and material components of s[eaker as we need to
        // modify them during runtime.
        renderer =speaker.GetComponent<Renderer>();
        speakerMat = renderer.material;

        //store the colour of emmission for speaker
        emissionColor = Color.cyan;
        tvColor = hallTVMat[1].GetColor("_EmissionColor");

        
    }

    // Update is called once per frame
    void Update()
    {
     if (serverControlHub.getClientMessage() == "P"/* Input.GetKeyDown(KeyCode.P)*/)
        {
            serverControlHub.msg = "";
            musicPlay = !musicPlay;
            if(musicPlay)
            {
                playerMat[1].EnableKeyword("_EMISSION");
                playerMat[1].SetColor("_EmissionColor",Color.cyan);
                playerMat[2].EnableKeyword("_EMISSION");
                playerMat[2].SetColor("_EmissionColor", Color.cyan);
                flashLight = true;
                // Start a coroutine to toggle the light on / off.
                StartCoroutine(Toggle());
                FindObjectOfType<audioManager>().playSound(music.ToString());
            }
            else
            {
                playerMat[1].DisableKeyword("_EMISSION");
                playerMat[2].DisableKeyword("_EMISSION");
                flashLight = false;
                StartCoroutine("stopFlashLight");
                FindObjectOfType<audioManager>().stopSound(music.ToString());
            }
        }
        if (musicPlay)
        {
            
        if (serverControlHub.getClientMessage() == "H"/* Input.GetKeyDown(KeyCode.H)*/)
        {
                serverControlHub.msg = "";
                FindObjectOfType<audioManager>().stopSound(music.ToString());
                music++;
            if(music>=7)
            {
                music = 1;
            }
            FindObjectOfType<audioManager>().playSound(music.ToString());
        }
        if (serverControlHub.getClientMessage() == "U"/* Input.GetKeyDown(KeyCode.U)*/)
        {
                serverControlHub.msg = "";
                pause = !pause;
            if (pause)
            {
                FindObjectOfType<audioManager>().pauseSound(music.ToString());
            }
            else
            FindObjectOfType<audioManager>().resumeSound(music.ToString());
        }
        }
        if (serverControlHub.getClientMessage() == "E"/* Input.GetKeyDown(KeyCode.E)*/)
        {
            serverControlHub.msg = "";
            tvPlay = !tvPlay;
            if(tvPlay)
            {
                hallTVMat[1].SetColor("_EmissionColor", tvColor);
                mbTVMat[1].SetColor("_EmissionColor", tvColor);
                videoPlayer.GetComponent<VideoPlayer>().Play();
            }
            else
            {
                videoPlayer.GetComponent<VideoPlayer>().Stop();
                hallTVMat[1].SetColor("_EmissionColor", Color.black);
                mbTVMat[1].SetColor("_EmissionColor", Color.black);
            }
        }
    }

    IEnumerator Toggle()
    {
        bool toggle = false;
        while (flashLight)
        {
            yield return new WaitForSeconds(0.8f);
            Activate(toggle, Random.Range(0.5f, 2f));
            toggle = !toggle;
        }
    }

    IEnumerator stopFlashLight()
    {        
        yield return new WaitForSeconds(1.5f);
        speakerMat.DisableKeyword("_EMISSION");
        speakerMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;

        speakerMat.SetColor("_EmissionColor", Color.black);
        RendererExtensions.UpdateGIMaterials(renderer);

        DynamicGI.SetEmissive(renderer, Color.black);
        DynamicGI.UpdateEnvironment();
    }
    // Call this method to turn on or turn off emissive light.
    public void Activate(bool on, float intensity = 1f)
    {
        if (on)
        {

            // Enables emission for the material, and make the material use
            // realtime emission.
            speakerMat.EnableKeyword("_EMISSION");
            speakerMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

            // Update the emission color and intensity of the material.
            speakerMat.SetColor("_EmissionColor", emissionColor * intensity);

            // Makes the renderer update the emission and albedo maps of our material.
            RendererExtensions.UpdateGIMaterials(renderer);

            // Inform Unity's GI system to recalculate GI based on the new emission map.
            DynamicGI.SetEmissive(renderer, emissionColor * intensity);
            DynamicGI.UpdateEnvironment();

        }
        else
        {

            speakerMat.DisableKeyword("_EMISSION");
            speakerMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;

            speakerMat.SetColor("_EmissionColor", Color.black);
            RendererExtensions.UpdateGIMaterials(renderer);

            DynamicGI.SetEmissive(renderer, Color.black);
            DynamicGI.UpdateEnvironment();

        }
    }

}
//Inputs
//P,H,U,E
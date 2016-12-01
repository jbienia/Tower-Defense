using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

   
    private AudioSource source;
    public float timeStepper = 0.05f;
    bool stopPlaying = false;
   public float counter;
    private float walkingRhythm;

    public static AudioManager audioManager;



    public void Awake()
    {
        walkingRhythm = counter;
        source = GetComponent<AudioSource>();

        if(audioManager == null)
        {
            audioManager = this;
        }
        
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        /*
        timeStepper -= Time.deltaTime;

        if (timeStepper <= 0)
        {
            source.PlayOneShot(basicEnemySteps, 0.5f);
            timeStepper = .05f;
        }
        */
    }

    public IEnumerator PlayBasicEnemyFootsteps(AudioClip enemySteps)
    {
        while(stopPlaying != true)
        {

            counter -= Time.deltaTime;

            if(counter <= 0)
            {
                source.PlayOneShot(enemySteps, 0.07f);
                counter = walkingRhythm;
            }

            yield return null;
        }

        
         
    }

    public void ArrowSound(AudioClip arrowSound)
    {
        source.PlayOneShot(arrowSound, 1f);
    }

    public void ArrowThud(AudioClip arrowThud)
    {
        source.PlayOneShot(arrowThud, 1f);
    }

    public void canonExplosion(AudioClip canonExplosion)
    {
        source.PlayOneShot(canonExplosion);
    }

    public void stopPlayingEnemyFootsteps()
    {
        stopPlaying = true;
    }
}

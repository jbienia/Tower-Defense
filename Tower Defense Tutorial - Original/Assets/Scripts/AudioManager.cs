using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

   
    private AudioSource source;
    public float timeStepper = 0.05f;
    bool stopPlaying = false;
    public float counter;
    private float walkingRhythm;
    public AudioClip backingTrack;
    public AudioClip basicEnemyHurtSound;
    public AudioClip flyingEnemyHurtSound;
    public AudioClip fastEnemyHurtSound;
    public AudioClip tankHurtSound;
    public AudioClip basicEnemyDeathSound;
    public AudioClip flyingEnemyDeathSound;
    public AudioClip fastEnemyDeathSound;
    public AudioClip tankDeathSound;
    public AudioClip basicLaugh;
    public AudioClip fastEnemyLaugh;
    public AudioClip tankEnemyLaugh;
    public AudioClip flyingEnemyLaugh;

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
        source.loop = true;
        this.playBackingTrack(backingTrack);
    }
	
	// Update is called once per frame
	void Update () {
        
        
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

    public void PlayFinalBleepOfCountdown(AudioClip finalBleep)
    {
        source.PlayOneShot(finalBleep,1f);

    }

    public void PlayCountdownBlips(AudioClip countdownBlips)
    {
        source.PlayOneShot(countdownBlips, 1f);
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
        source.PlayOneShot(canonExplosion,0.8f);
    }

    public void canonShot(AudioClip canonShot)
    {
        source.PlayOneShot(canonShot,0.9f);
    }

    public void playBackingTrack(AudioClip backingTrack)
    {
        source.volume = 0.5f;
        source.Play();
        //source.PlayOneShot(backingTrack, 0.5f);
        source.loop = true;
    }
    
    public void playCoinDrop(AudioClip coinDrop)
    {
        source.PlayOneShot(coinDrop, 1f);
    }

    public void playBoxClick(AudioClip click)
    {
        source.PlayOneShot(click, 0.7f);
    }

    //public void playBasicEnemyLaugh(AudioClip basicLaugh)
    //{
    //    source.PlayOneShot(basicLaugh, 0.7f);
    //}

    //public void playFastEnemyLaugh(AudioClip fastEnemyLaugh)
    //{
    //    source.PlayOneShot(fastEnemyLaugh, 0.7f);
    //}

    //public void playTankEnemyLaugh(AudioClip tankEnemyLaugh)
    //{
    //    source.PlayOneShot(tankEnemyLaugh, 0.7f);
    //}

    //public void playFlyingEnemyLaugh(AudioClip flyingEnemyLaugh)
    //{
    //    source.PlayOneShot(flyingEnemyLaugh, 0.7f);
    //}



    public void stopPlayingEnemyFootsteps()
    {
        stopPlaying = true;
    }

    public void playTurretChoiceBloop(AudioClip turretChoiceBloop)
    {
        source.PlayOneShot(turretChoiceBloop, 0.7f);
    }

    public void PlayEnemyLaughSound(string enemyTag)
    {
        switch (enemyTag)
        {
            case "Enemy":
                source.PlayOneShot(basicLaugh, 0.5f);
                break;

            case "FastEnemy":
                source.PlayOneShot(fastEnemyLaugh, 0.5f);
                break;

            case "Tank":
                source.PlayOneShot(tankEnemyLaugh, 0.5f);
                break;

            case "FlyingEnemy":
                source.PlayOneShot(flyingEnemyLaugh, 0.5f);
                break;

        }
    }


    public void PlayEnemyHurtSound(string enemyTag)
    {
        switch(enemyTag)
            {
            case "Enemy":
                source.PlayOneShot(basicEnemyHurtSound,0.5f);
                break;

            case "FastEnemy":
                source.PlayOneShot(fastEnemyHurtSound, 0.5f);
                break;

            case "Tank":
                source.PlayOneShot(tankHurtSound, 0.5f);
                break;

            case "FlyingEnemy":
                source.PlayOneShot(flyingEnemyHurtSound, 0.5f);
                break;

        }
    }

    public void PlayeEnemyDeathSound(string enemyTag)
    {
        switch(enemyTag)
        {
            case "Enemy":
                source.PlayOneShot(basicEnemyDeathSound, 0.5f);
                break;

            case "FastEnemy":
                source.PlayOneShot(fastEnemyDeathSound, 0.5f);
                break;

            case "Tank":
                source.PlayOneShot(tankDeathSound, 0.5f);
                break;

            case "FlyingEnemy":
                source.PlayOneShot(flyingEnemyDeathSound, 0.5f);
                break;
        }
    }

    
}

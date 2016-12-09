﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{

    public static GameplayUI inGameUserInterface = null;
    public Transform[] userComponents;
    private int childCount;
    public Text bank;
    public Text lives;
    public Image enemyImage;
    public Transform panel;
    public Text countdown;
    public Animator countBouncer;
    public GameObject coin;
    private Transform coinPlaceholder;
    private GameObject coinBounceReference;
    private float number = 0.5f;
    float i;

    public AudioClip coinDropSound;


    // Use this for initialization
    void Start()
    {

        if (inGameUserInterface == null)
        {
            inGameUserInterface = this;
        }

      
        panel = inGameUserInterface.transform.GetChild(0);


        childCount = panel.childCount;

       

        for (int i = 0; i < childCount; i++)
        {
            userComponents = new Transform[childCount];

            userComponents[i] = panel.transform.GetChild(i);

            if (userComponents[i].name == "Bank")
            {
                bank = userComponents[i].GetComponent<Text>();
            }

            else if (userComponents[i].name == "Lives")
            {
                lives = userComponents[i].GetComponent<Text>();
            }

            if (userComponents[i].name == "Enemy")
            {
                enemyImage = userComponents[i].GetComponent<Image>();

            }

            if (userComponents[i].name == "Countdown")
            {
                countdown = userComponents[i].GetComponent<Text>();
                countBouncer = userComponents[i].GetComponent<Animator>();
                countBouncer.enabled = false;
            }

            if (userComponents[i].name == "BounceCoinPlaceholder")
            {
                coinPlaceholder = userComponents[i];
            }
        }
   }

    public IEnumerator CoinBounceAnimation()
    {


        if (inGameUserInterface.number == 0.5f)
        {
            inGameUserInterface.number = 0.1f;
        }
        else if (inGameUserInterface.number == 0.5f)
        {
            inGameUserInterface.number = 0.3f;
        }
        else
        {
            inGameUserInterface.number = 0.5f;
        }

        AudioManager.audioManager.playCoinDrop(coinDropSound);
        yield return new WaitForSeconds(inGameUserInterface.number);

       
        GameObject go = (GameObject)Instantiate(coin, coinPlaceholder.position, coinPlaceholder.rotation, panel);

       

    }

}

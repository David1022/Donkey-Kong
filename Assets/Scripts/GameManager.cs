using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int time;
    public int score;
    public int countDown;

    public Text timeLabel;
    public Text scoreLabel;
    public Text countDownLabel;

    private static AudioSource audio;

    public const int ENEMY_SCORE = 100;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        Initialize();

        time = 0;
        score = 0;
        countDown = 3;

        timeLabel.text = "Time : " + time + " s";
        scoreLabel.text = "Score : " + score;

        StartCoroutine("CountDown");
    }

    void Initialize() {
        audio = GetComponent<AudioSource>();
    }

    void Chrono()
    {
        time++;
        timeLabel.text = "Time : " + time + " s";
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreLabel.text = "Score : " + score;
    }

    IEnumerator CountDown() {
        for (countDown = 3; countDown > 0; countDown--) {
            countDownLabel.text = countDown.ToString();
            yield return new WaitForSeconds(1f);
        }
        countDownLabel.gameObject.SetActive(false);
        audio.Play();
        InvokeRepeating("Chrono", 1f, 1f);
        MarioController.SetCanPlay();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public static void StopAudio() {
        audio.Stop();
    }
}

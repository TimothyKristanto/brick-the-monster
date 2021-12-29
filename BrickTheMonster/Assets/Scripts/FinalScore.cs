using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public GameController gameController;
    public Text scoreUI;
    private int finalScore;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        finalScore = PlayerPrefs.GetInt("score");
        scoreUI.text = "Your Score : " + finalScore;
    }
}

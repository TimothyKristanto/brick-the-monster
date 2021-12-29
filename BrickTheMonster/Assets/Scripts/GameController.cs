using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text levelUI, scoreUI;

    public GameObject monster;
    public GameObject brick1;
    public GameObject brick2;
    public GameObject brick3;
    public GameObject brick4;
    public GameObject brick5;

    private int level = 1;
    private int score = 0;
    private long deathCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        instantiateMonster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void countDeath()
    {
        deathCounter++;
        score += 100;
        scoreUI.text = "Score " + score;

        if (deathCounter >= level)
        {
            deathCounter = 0;
            level += 1;
            levelUI.text = "Level " + level;

            instantiateMonster();

            StartCoroutine(instantiateMonsterWithTimer());
        }

        if(level == 4)
        {
            brick1.SetActive(true);
            brick4.SetActive(true);
        }

        if(level == 6)
        {
            brick3.SetActive(true);
        }

        if(level == 8)
        {
            brick2.SetActive(true);
            brick5.SetActive(true);
        }
    }

    void instantiateMonster()
    {
        GameObject newMonster = Instantiate(monster);
        newMonster.GetComponent<MonsterBehaviour>().gameController = this;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("score", score);
    }

    IEnumerator instantiateMonsterWithTimer()
    {
        int i = 0;

        while (i < level - 1)
        {
            yield return new WaitForSeconds(1.5f);
            instantiateMonster();
            i++;
        }

    }
}

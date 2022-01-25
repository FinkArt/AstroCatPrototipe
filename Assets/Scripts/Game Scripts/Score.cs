using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 10;
    [SerializeField] public GameObject scorePanel;
    public static int scoreFish = 0;
    [SerializeField] public GameObject scoreFishPanel;

    private void Start()
    {
        StartCoroutine(CountScore());
        
    }

    private void Repeat()
    {
        StartCoroutine(CountScore());
    }

    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.5f);

        scorePanel.GetComponent<Text>().text = score.ToString();
        score += 10;
        Repeat();
    }

    private void Update()
    {
        scoreFishPanel.GetComponent<Text>().text = scoreFish.ToString();
        
    }

}

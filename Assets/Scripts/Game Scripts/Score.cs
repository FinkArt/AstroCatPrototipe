using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private GameObject scorePanel;
    public static int scoreFish = 0;
    [SerializeField] private GameObject scoreFishPanel;
    public static int highScore = 0;
    [SerializeField] private GameObject highScorePanel;
    public static int scoreOfRound = 0;
    [SerializeField] private GameObject scoreOfRoundPanel; 
   

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
        if (highScore < score)
            highScore = score; //���������� ���������� ���������� ����� � �������, ���� ������ ��������, �� ������� ����� ������ ����
        Text highSc = highScorePanel.GetComponent<Text>(); //�������� ������ � ������ ������� �����
        highSc.text = "������ ����: " + highScore; // ���������� ������ � �����
        
        Text sc = scoreOfRoundPanel.GetComponent<Text>();
        sc.text = "���� ����� ������: " + score;

    }

}

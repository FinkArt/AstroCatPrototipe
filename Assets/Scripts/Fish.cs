using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Entity
{
    [SerializeField] private Transform posFishScore; //пременная с типом данных Transform для перемещения объекта Fish после ловли игроком в точку со счетом с иконкой рыбки
    private bool move = true;

    private void Update()
    {
        if (move == true)
            Move();

        if (move == false)
            MoveToFishScore();

        if (transform.position == posFishScore.transform.position)
        {
            Die();
            Score.scoreFish += 1;
        }

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Cat")
        {
            move = false;
        }

        if (collision.CompareTag("DeleteArea"))
            Die();

    }
    
    private void MoveToFishScore()
    {
        float step = 55f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, posFishScore.position, step);
    }

}

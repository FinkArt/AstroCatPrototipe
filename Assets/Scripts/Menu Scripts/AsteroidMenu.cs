using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidMenu : MonoBehaviour //скрипт для класса движения астероидов в главном меню игры
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 dir;

    private void Start()
    {
        if (transform.position.x < 0) //условие для движения астероидов относительно респауна, если астероид появился и позиция по оси Х меньше нуля, то направление меняется и уменьшается скорость
        {
            dir.x = dir.x * (-1);
            speed = speed - 0.1f;

        }
        else  // в других условиях скорость и направление движения остаются прежними, это сделано для того, чтобы по разные стороны экрана создавался эффект менее хаотичного движения
            dir.x = dir.x * 1;
    }
    private void FixedUpdate()
    {
        MoveAsteroid();

    }


    private void MoveAsteroid () //метод для движения астероида  (задаем в инспекторе направление движение по оси У и Х)
    {
        transform.Translate (dir.normalized * speed, Space.World);
        
    }

    private void OnTriggerExit2D(Collider2D collision) // метод для удаления астероида, если он выходит из триггера пространства DeleteStars
    {
        if (collision.CompareTag("DeleteStars")) 
        {
            Destroy(this.gameObject);
        }
    }

}

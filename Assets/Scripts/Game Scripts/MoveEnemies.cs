using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemies : Entity
{
    //speed � direction - ������ ���������� ��������� � ������������� ������ Entity 

    private void Start()
    {
        if (transform.position.y >= 15)
        {
            speed = 0.5f;
        }

    }

    private void Update()
    {
        transform.Rotate(0, 0, 150 * Time.deltaTime); //������ �������� ��� �������

    }

    private void FixedUpdate()
    {
        Move();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeleteArea"))
            Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Cat.Instance.gameObject)
            Cat.Instance.DieCat();

    }

}

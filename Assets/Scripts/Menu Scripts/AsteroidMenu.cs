using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidMenu : MonoBehaviour //������ ��� ������ �������� ���������� � ������� ���� ����
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 dir;

    private void Start()
    {
        if (transform.position.x < 0) //������� ��� �������� ���������� ������������ ��������, ���� �������� �������� � ������� �� ��� � ������ ����, �� ����������� �������� � ����������� ��������
        {
            dir.x = dir.x * (-1);
            speed = speed - 0.1f;

        }
        else  // � ������ �������� �������� � ����������� �������� �������� ��������, ��� ������� ��� ����, ����� �� ������ ������� ������ ���������� ������ ����� ���������� ��������
            dir.x = dir.x * 1;
    }
    private void FixedUpdate()
    {
        MoveAsteroid();

    }


    private void MoveAsteroid () //����� ��� �������� ���������  (������ � ���������� ����������� �������� �� ��� � � �)
    {
        transform.Translate (dir.normalized * speed, Space.World);
        
    }

    private void OnTriggerExit2D(Collider2D collision) // ����� ��� �������� ���������, ���� �� ������� �� �������� ������������ DeleteStars
    {
        if (collision.CompareTag("DeleteStars")) 
        {
            Destroy(this.gameObject);
        }
    }

}

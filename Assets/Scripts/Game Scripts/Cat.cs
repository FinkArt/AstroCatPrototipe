using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private float speed = 8f;
    private Rigidbody2D rb;

    [SerializeField] private Transform planetPosition;
    [SerializeField] private float gravityForce = 5f;
    [SerializeField] public static bool gravityPlanet = true;

    public static Cat Instance { get; set; } // ����� ���������� �� ���� ���������� � ������� ������ Cat �� �������� ��� �����������


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    private void FixedUpdate()
    {
        if (gravityPlanet == false) //������� ��� ������� ������� ����� ����������� ��������� � ������ ������
        {
            rb.AddForce((planetPosition.position - transform.position).normalized * gravityForce);
        }
    }

    private void Update()
    {
        //if (gravityPlanet == true) //������� ��� ������� ���������� ����� Fly() ��� �������� ��������� ������������ �������� �����
        //    Fly();

        if (Input.GetButton("Horizontal") && gravityPlanet == true) //������� ��� ������� ���������� ����� Move() ��� �������� ��������� �������� ���� � ������� ������ ������ � ����� 
        {
            Move();
            
        }

        else
        {
            rb.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Fly() //����� ��� ������������ �������� �����
    {
        transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
        rb.freezeRotation = true;

    }

    private void Move() // ����� ��� ����������� ��������� ������ � �����
    {
        //Vector3 dir = transform.right * speed * Input.GetAxis("Horizontal");
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);

        float moveHorizontal = Input.GetAxis("Horizontal");

        //float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + movement, speed * Time.deltaTime);

        if (movement.x < 0.0f) //������� ��� ����, ����� ��� �������� ����� ������� ����� ��� ����� (������������ � ������� �����������)
            rb.transform.rotation = Quaternion.Euler(0, 0, 30f);
        if (movement.x > 0.0f) //������� ��� ����, ����� ��� �������� ������ ������� ����� ��� ������ (������������ � ������� �����������)
            rb.transform.rotation = Quaternion.Euler(0, 0, -30f);
        
    }

    public void DieCat()
    {
        Destroy(this.gameObject);
        Time.timeScale = 0f;
    }

}

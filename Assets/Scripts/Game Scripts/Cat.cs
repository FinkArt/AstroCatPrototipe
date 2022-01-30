using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private Rigidbody2D rb;

    [SerializeField] private Transform planetPosition;
    [SerializeField] private float gravityForce = 5f;
    [SerializeField] public static bool gravityPlanet = true;

    private Animator anim;
    private bool isMove = true;

    [SerializeField] private GameObject losePanel;

    public static Cat Instance { get; set; } // ����� ���������� �� ���� ���������� � ������� ������ Cat �� �������� ��� �����������


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Instance = this;
    }

    private void Start()
    {
        if (isMove == false)
            Invoke("LosePanel", 0.5f);
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

    private void Move() // ����� ��� ����������� ��������� ������ � �����
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        //float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + movement, speed * Time.deltaTime);

        if (movement.x < 0.0f) //������� ��� ����, ����� ��� �������� ����� ������� ����� ��� ����� (������������ � ������� �����������)
            rb.transform.rotation = Quaternion.Euler(0, 0, 30f);
        if (movement.x > 0.0f) //������� ��� ����, ����� ��� �������� ������ ������� ����� ��� ������ (������������ � ������� �����������)
            rb.transform.rotation = Quaternion.Euler(0, 0, -30f);

        if (isMove == true) State = States.FireIdleCat; //�������� �������� �����

    }

    public void DieCat()
    {
        isMove = false; //������� ��� ���������� �������� ��������
        State = States.Crash; //�������� ������ ��� ������������
        Destroy(this.gameObject, 1f);
        
        
    }

    private void LosePanel()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public enum States
    {
        FireIdleCat,
        Crash
    }

    private States State
    {
        get { return (States)anim.GetInteger("State"); } // c ������� get �������� �������� ����� �� ���������
        set { anim.SetInteger("State", (int)value); } //C ������� set ������ �������� �����

    }


}

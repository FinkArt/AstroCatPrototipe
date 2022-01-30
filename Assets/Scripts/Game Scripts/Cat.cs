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

    public static Cat Instance { get; set; } // можем обращаться ко всем параметрам и методам класса Cat не создавая его экземпляров


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
        if (gravityPlanet == false) //условие при котором планета будет притягивать персонажа к своему центру
        {
            rb.AddForce((planetPosition.position - transform.position).normalized * gravityForce);
        }
    }

    private void Update()
    {
        //if (gravityPlanet == true) //условия при котором срабатывал метод Fly() для придания персонажу бесконечного движения вверх
        //    Fly();

        if (Input.GetButton("Horizontal") && gravityPlanet == true) //условия при котором срабатывал метод Move() для придания персонажу движения вбок с помощью кнопок вправо и влево 
        {
            Move();

        }

        else
        {
            rb.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Move() // метод для перемещения персонажа вправо и влево
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        //float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + movement, speed * Time.deltaTime);

        if (movement.x < 0.0f) //условие для того, чтобы при движении влево поворот героя был влево (поворачиваем с помощию кватерниона)
            rb.transform.rotation = Quaternion.Euler(0, 0, 30f);
        if (movement.x > 0.0f) //условие для того, чтобы при движении вправо поворот героя был вправо (поворачиваем с помощию кватерниона)
            rb.transform.rotation = Quaternion.Euler(0, 0, -30f);

        if (isMove == true) State = States.FireIdleCat; //анимация движения героя

    }

    public void DieCat()
    {
        isMove = false; //условие для отключения анимации движения
        State = States.Crash; //анимация взрыва при столкновении
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
        get { return (States)anim.GetInteger("State"); } // c помощью get получаем значение Стэйт из аниматора
        set { anim.SetInteger("State", (int)value); } //C помощью set меняем значение Стэйт

    }


}

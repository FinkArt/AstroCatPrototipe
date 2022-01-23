using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStarsBackgound : MonoBehaviour
{
    public float starsSpeed;
    [SerializeField] private Vector2 starsDirection;
    [SerializeField] private Transform placeOfStarsSpawn;
    

    
    private void FixedUpdate()
    {
        transform.Translate(starsDirection * starsSpeed, Space.World);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DeleteStars"))
        {
            transform.position = placeOfStarsSpawn.transform.position;
        }
    }

}

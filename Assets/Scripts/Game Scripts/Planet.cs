using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
     
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cat")
        {
            Cat.gravityPlanet = false;
        }

        if (collision.CompareTag("DeleteArea"))
            Destroy(this.gameObject);
    }

  
}

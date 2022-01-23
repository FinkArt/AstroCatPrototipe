using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sputnik : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeleteArea"))
            Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Vector2 direction = new Vector2(0, -1);
    protected float speed = 0.05f;
    public virtual void Move()
    {
        transform.Translate(direction.normalized * speed, Space.World);
        
    }

    public virtual void Die()
    {
        Destroy(this.gameObject); 

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;
    public float speed = 5f;

    private void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<Cat>().transform;
        }
    }

    void LateUpdate()
    {
        pos = player.position;
        pos.z = -10f;
        pos.x = 0f;
        transform.position = Vector3.LerpUnclamped(transform.position, pos, speed * Time.deltaTime);
    }
}

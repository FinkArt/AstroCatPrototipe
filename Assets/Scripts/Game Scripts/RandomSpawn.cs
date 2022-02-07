using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] prefabs; //массив с префабами, которые должны рандомно появляться
    [HideInInspector]public float timeStep; //переменная для временного диапазона появления объектов
    Vector2 whereToSpawn; //переменная для того, чтобы показать место где будет появляться наши объекты
    private float [] respawns = new float [] {-4.8f, -1.4f, 1.4f, 4.8f }; //позиции для появления астероидов и сушинок(fish)
    int lastPoint;
        
    private void Start()
    {
        StartCoroutine(MoveAsteroids());
        StartCoroutine(CrazyAsteriod());

    }

    private void RepeatForMoveAsteroids()
    {
        StartCoroutine(MoveAsteroids());
        
    }
    
    private void RepeatForCrazyAsteroids()
    {
        StartCoroutine(CrazyAsteriod());
    }


    public IEnumerator MoveAsteroids()
    {
        timeStep = 1.2f;
        yield return new WaitForSeconds(timeStep);
        int randX = Random.Range(0, respawns.Length-1); //рандомный перебор значений по оси Х
        Debug.Log("RandX = " + randX);
        int randPrefabs = Random.Range(0, prefabs.Length); //рандомный перебор в массиве с префабами астероидов
        
        if (randX == lastPoint && randX != respawns.Length)
        {
            whereToSpawn = new Vector2(respawns[randX+1], transform.position.y); //переменная появления префабов, позиция Х изменяется рандомной, позиция У статичная, в зависимости от того, где установлена точка респауна
            lastPoint = randX + 1;
        }
        //else if (randX == lastPoint && randX == respawns.Length)
        //{
        //    whereToSpawn = new Vector2(respawns[randX-1], transform.position.y); //переменная появления префабов, позиция Х изменяется рандомной, позиция У статичная, в зависимости от того, где установлена точка респауна
        //    lastPoint = randX - 1;
        //}
        else 
        {
            whereToSpawn = new Vector2(respawns[randX], transform.position.y); //переменная появления префабов, позиция Х изменяется рандомной, позиция У статичная, в зависимости от того, где установлена точка респауна
            lastPoint = randX;
        }
        Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //появление префабов(астероидов из массива) в заданном месте с рандомным изменением по оси Х
        Debug.Log("lastPoint = " + lastPoint);
        RepeatForMoveAsteroids();
    }
    
    public IEnumerator CrazyAsteriod()
    {
        timeStep = Random.Range(10f, 15f);
        yield return new WaitForSeconds(timeStep);
        int randX = Random.Range(0, respawns.Length); //рандомный перебор значений по оси Х
        int randPrefabs = Random.Range(0, prefabs.Length); //рандомный перебор в массиве с префабами астероидов
        whereToSpawn = new Vector2(respawns[randX], 15.3f); //переменная появления префабов, позиция Х изменяется рандомной, позиция У статичная, в зависимости от того, где установлена точка респауна
        Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //появление префабов(астероидов из массива) в заданном месте с рандомным изменением по оси Х
        RepeatForCrazyAsteroids();
    }

}

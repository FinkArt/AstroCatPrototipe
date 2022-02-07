using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] prefabs; //������ � ���������, ������� ������ �������� ����������
    [HideInInspector]public float timeStep; //���������� ��� ���������� ��������� ��������� ��������
    Vector2 whereToSpawn; //���������� ��� ����, ����� �������� ����� ��� ����� ���������� ���� �������
    private float [] respawns = new float [] {-4.8f, -1.4f, 1.4f, 4.8f }; //������� ��� ��������� ���������� � �������(fish)
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
        int randX = Random.Range(0, respawns.Length-1); //��������� ������� �������� �� ��� �
        Debug.Log("RandX = " + randX);
        int randPrefabs = Random.Range(0, prefabs.Length); //��������� ������� � ������� � ��������� ����������
        
        if (randX == lastPoint && randX != respawns.Length)
        {
            whereToSpawn = new Vector2(respawns[randX+1], transform.position.y); //���������� ��������� ��������, ������� � ���������� ���������, ������� � ���������, � ����������� �� ����, ��� ����������� ����� ��������
            lastPoint = randX + 1;
        }
        //else if (randX == lastPoint && randX == respawns.Length)
        //{
        //    whereToSpawn = new Vector2(respawns[randX-1], transform.position.y); //���������� ��������� ��������, ������� � ���������� ���������, ������� � ���������, � ����������� �� ����, ��� ����������� ����� ��������
        //    lastPoint = randX - 1;
        //}
        else 
        {
            whereToSpawn = new Vector2(respawns[randX], transform.position.y); //���������� ��������� ��������, ������� � ���������� ���������, ������� � ���������, � ����������� �� ����, ��� ����������� ����� ��������
            lastPoint = randX;
        }
        Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //��������� ��������(���������� �� �������) � �������� ����� � ��������� ���������� �� ��� �
        Debug.Log("lastPoint = " + lastPoint);
        RepeatForMoveAsteroids();
    }
    
    public IEnumerator CrazyAsteriod()
    {
        timeStep = Random.Range(10f, 15f);
        yield return new WaitForSeconds(timeStep);
        int randX = Random.Range(0, respawns.Length); //��������� ������� �������� �� ��� �
        int randPrefabs = Random.Range(0, prefabs.Length); //��������� ������� � ������� � ��������� ����������
        whereToSpawn = new Vector2(respawns[randX], 15.3f); //���������� ��������� ��������, ������� � ���������� ���������, ������� � ���������, � ����������� �� ����, ��� ����������� ����� ��������
        Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //��������� ��������(���������� �� �������) � �������� ����� � ��������� ���������� �� ��� �
        RepeatForCrazyAsteroids();
    }

}

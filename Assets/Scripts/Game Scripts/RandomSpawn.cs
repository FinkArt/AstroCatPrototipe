using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] prefabs; //������ � ���������, ������� ������ �������� ����������
    public float timeStep; //���������� ��� ���������� ��������� ��������� ��������
    Vector2 whereToSpawn; //���������� ��� ����, ����� �������� ����� ��� ����� ���������� ���� �������
    private float [] respawns = new float [] {-4.8f, -1.4f, 1.4f, 4.8f }; //������� ��� ��������� ���������� � �������(fish)
    


    //[SerializeField] private GameObject spawner;

    //private void Start()
    //{
    //    StartCoroutine(SpawnObjects());
    //}

    //private void Repeat()
    //{
    //    StartCoroutine(SpawnObjects());
    //}

    //private IEnumerator SpawnObjects ()
    //{
    //    yield return new WaitForSeconds(timeStep); //������ ����� , ����� ������� ����� ���������� ������� ����������
    //    float randX = Random.Range(0, respawns.Length); //��������� ������� �������� �� ��� �
    //    int randPrefabs = Random.Range(0, prefabs.Length); //��������� ������� � ������� � ��������� ����������
    //    whereToSpawn = new Vector2(randX, transform.position.y); //���������� ��������� ��������, ������� � ���������� ���������, ������� � ���������, � ����������� �� ����, ��� ����������� ����� ��������

    //    Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //��������� ��������(���������� �� �������) � �������� ����� � ��������� ���������� �� ��� �
    //    Repeat();
    //}

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
        timeStep = 1f;
        yield return new WaitForSeconds(timeStep);
        int randX = Random.Range(0, respawns.Length); //��������� ������� �������� �� ��� �
        int randPrefabs = Random.Range(0, prefabs.Length); //��������� ������� � ������� � ��������� ����������
        whereToSpawn = new Vector2(respawns[randX], transform.position.y); //���������� ��������� ��������, ������� � ���������� ���������, ������� � ���������, � ����������� �� ����, ��� ����������� ����� ��������
        Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //��������� ��������(���������� �� �������) � �������� ����� � ��������� ���������� �� ��� �
        RepeatForMoveAsteroids();     
    }

    public IEnumerator CrazyAsteriod()
    {
        timeStep = Random.Range(12f, 20f);
        yield return new WaitForSeconds(timeStep);
        int randX = Random.Range(0, respawns.Length); //��������� ������� �������� �� ��� �
        int randPrefabs = Random.Range(0, prefabs.Length); //��������� ������� � ������� � ��������� ����������
        whereToSpawn = new Vector2(respawns[randX], 15.3f); //���������� ��������� ��������, ������� � ���������� ���������, ������� � ���������, � ����������� �� ����, ��� ����������� ����� ��������
        Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //��������� ��������(���������� �� �������) � �������� ����� � ��������� ���������� �� ��� �
        RepeatForCrazyAsteroids();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] prefabs; //������ � ���������, ������� ������ �������� ����������
    public float timeStep = 1f; //���������� ��� ���������� ��������� ��������� ��������
    Vector2 whereToSpawn; //���������� ��� ����, ����� �������� ����� ��� ����� ���������� ���� �������
    public float [] respawns; //������� ��� ��������� ���������� � �������(fish)


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
        StartCoroutine(FastMove());

    }

    private void Repeat()
    {
        StartCoroutine(FastMove());
    }
    public IEnumerator FastMove()
    {
        timeStep = Random.Range(12f, 20f);
        yield return new WaitForSeconds(timeStep);
            float randX = Random.Range(-5.3f, 5.3f); //��������� ������� �������� �� ��� �
            int randPrefabs = Random.Range(0, prefabs.Length); //��������� ������� � ������� � ��������� ����������
            whereToSpawn = new Vector2(randX, transform.position.y); //���������� ��������� ��������, ������� � ���������� ���������, ������� � ���������, � ����������� �� ����, ��� ����������� ����� ��������
            Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //��������� ��������(���������� �� �������) � �������� ����� � ��������� ���������� �� ��� �
        
        Repeat();
                
    }

}

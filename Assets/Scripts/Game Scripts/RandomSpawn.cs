using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] prefabs; //������ � ���������, ������� ������ �������� ����������
    public float timeStep = 1f; //���������� ��� ���������� ��������� ��������� ��������
    float randX; // ��������� �������� �������� �� �, ������� � ��� ����� ����������
    Vector2 whereToSpawn; //���������� ��� ����, ����� �������� ����� ��� ����� ���������� ���� �������

    [SerializeField] private GameObject spawner;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private void Repeat()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects ()
    {
        yield return new WaitForSeconds(timeStep); //������ ����� , ����� ������� ����� ���������� ������� ����������
        randX = Random.Range(-5.3f, 5.3f); //��������� ������� �������� �� ��� �
        int randPrefabs = Random.Range(0, prefabs.Length); //��������� ������� � ������� � ��������� ����������
        whereToSpawn = new Vector2(transform.position.x, transform.position.y); //���������� ��������� ��������, ������� � ���������� ���������, ������� � ���������, � ����������� �� ����, ��� ����������� ����� ��������
        Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //��������� ��������(���������� �� �������) � �������� ����� � ��������� ���������� �� ��� �
        Repeat();
    }

}

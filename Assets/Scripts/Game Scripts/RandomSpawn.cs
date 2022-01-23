using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] prefabs; //массив с префабами, которые должны рандомно по€вл€тьс€
    public float timeStep = 1f; //переменна€ дл€ временного диапазона по€влени€ объектов
    float randX; // вычисл€ем значени€ объектов по ’, которые у нас будут по€вл€тьс€
    Vector2 whereToSpawn; //переменна€ дл€ того, чтобы показать место где будет по€вл€тьс€ наши объекты

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
        yield return new WaitForSeconds(timeStep); //задаем врем€ , через которое будет по€вл€тьс€ префабы астероидов
        randX = Random.Range(-5.3f, 5.3f); //рандомный перебор значений по оси ’
        int randPrefabs = Random.Range(0, prefabs.Length); //рандомный перебор в массиве с префабами астероидов
        whereToSpawn = new Vector2(transform.position.x, transform.position.y); //переменна€ по€влени€ префабов, позици€ ’ измен€етс€ рандомной, позици€ ” статична€, в зависимости от того, где установлена точка респауна
        Instantiate(prefabs[randPrefabs], whereToSpawn, Quaternion.identity); //по€вление префабов(астероидов из массива) в заданном месте с рандомным изменением по оси ’
        Repeat();
    }

}

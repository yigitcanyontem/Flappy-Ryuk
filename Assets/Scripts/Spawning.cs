using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] prefabs_reverse;
    public float spawnRate = 0.8f;
    public float maxHeight;


    private void OnEnable()
    {
        InvokeRepeating(nameof(Randomize), spawnRate, spawnRate);
    }


    private void OnDisable()
    {
        CancelInvoke(nameof(Randomize));
    }

    private void Randomize()
    {
        GameObject[] array;
        int index = Random.Range(0, 2);

        if (index == 0){
            array = prefabs;
            maxHeight = 5f;
}
        else{
            array = prefabs_reverse;
            maxHeight = 11.1f;
        }


        Spawn(array);
    }

    private void Spawn(GameObject[] array)
    {
        int index = Random.Range(0, array.Length);

        GameObject pipes = Instantiate(array[index], transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up *maxHeight; ;
    }

}

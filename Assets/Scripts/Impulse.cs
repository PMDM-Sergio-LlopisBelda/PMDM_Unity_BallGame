using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public GameObject[] prefabs;
    public float fireRate = 0.5f;
    public float initialDelayTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowStone());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(prefab, transform.position, Random.rotation);
        }*/
    }

    IEnumerator ThrowStone() {
        yield return new WaitForSeconds(initialDelayTime);
        while(true) {
            GameObject randomObject = prefabs[Random.Range(0, prefabs.Length)];
            Instantiate(randomObject, transform.position, Random.rotation);
            yield return new WaitForSeconds(fireRate);
        }

    }

}

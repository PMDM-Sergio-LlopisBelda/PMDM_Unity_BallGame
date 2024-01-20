using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlopeGenerator : MonoBehaviour
{
    public GameObject[] slopes;
    public GameObject firstSlope;
    private float timeBetweenSlopes = 6;
    private float heightDestroyObjects = 300f;
    public Text pointsText;

    IEnumerator GenerateSlopes() {
        Vector3 slopeVector = firstSlope.transform.position;
        slopeVector.y-=198.685f;
        slopeVector.z+=503.2474f;
        Instantiate(firstSlope, slopeVector, firstSlope.transform.rotation);
        yield return new WaitForSeconds(timeBetweenSlopes);
        while(true) {
            slopeVector.y-=198.685f;
            slopeVector.z+=503.2474f;
            GameObject randomObject = slopes[Random.Range(0, slopes.Length)];
            Instantiate(randomObject, slopeVector, randomObject.transform.rotation);
            deleteObjectsBehindPlayer();
            Time.timeScale+=0.1f;
            GameManager.points++;
            pointsText.text = GameManager.points.ToString();
            yield return new WaitForSeconds(timeBetweenSlopes);
        }

    }

    private void deleteObjectsBehindPlayer() {
        GameObject[] mapElements = GameObject.FindGameObjectsWithTag("MapElement");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        List<GameObject> sceneObjects = mapElements.ToList();
        sceneObjects.AddRange(enemies);

        foreach (GameObject iterationObject in sceneObjects)
        {
            if (iterationObject.transform.position.y > transform.position.y + heightDestroyObjects)
            {
                Destroy(iterationObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateSlopes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

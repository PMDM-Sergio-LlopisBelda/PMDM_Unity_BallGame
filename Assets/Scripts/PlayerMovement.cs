using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float forceValue = 1f;
    public float jumpValue = 1f;
    private Rigidbody rb;
    private AudioSource audioSource;
    private bool puedeRalentizar = true;
    public Camera cam;
    public Material chargedMaterial;
    public Material unChargedMaterial;
    private MeshRenderer meshRenderer;
    public GameObject pointsCanvas;
    public GameObject deathCanvas;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = cam.GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
{
    if ((Input.GetButtonDown("Jump") || Input.touchCount == 1) && puedeRalentizar)
    {
        float originalTimeScale = Time.timeScale;

        Time.timeScale = originalTimeScale / 2;
        cam.backgroundColor = Color.gray;

        StartCoroutine(RestaurarTiempo(originalTimeScale));
        StartCoroutine(EsperarParaRalentizar());
    }

    /*if (Input.touchCount == 1)
    {
        if (Input.touches[0].phase == TouchPhase.Began)
        {
            rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            audioSource.Play();
        }
    }*/
}

IEnumerator RestaurarTiempo(float originalTimeScale)
{
    meshRenderer.material = unChargedMaterial;
    yield return new WaitForSeconds(Time.timeScale*2);

    cam.backgroundColor = new Color(100f / 255f, 143f / 255f, 212f / 255f);
    Time.timeScale = originalTimeScale;
}

IEnumerator EsperarParaRalentizar()
{
    puedeRalentizar = false;

    yield return new WaitForSeconds(Time.timeScale*4);
    meshRenderer.material = chargedMaterial;

    puedeRalentizar = true;
}


    void FixedUpdate() {
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * forceValue);
        rb.AddForce(new Vector3(Input.acceleration.x, 0, 0) * forceValue * 2);
    }

    

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            audioSource.Play();
            gameObject.SetActive(false);
            pointsCanvas.SetActive(false);
            deathCanvas.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider) {
        //print("Area");
    }
}

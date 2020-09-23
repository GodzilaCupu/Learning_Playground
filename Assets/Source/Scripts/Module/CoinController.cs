using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance = null;

    //deklarasi kecepatan rotasi coin = 100
    public float rotationSpeed = 50f;

    public AudioSource pickedSound;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //menentukan jarak rotasi per frame, dapat di tentukan dari kecepatan rotasi * waktu
        float angle = rotationSpeed * Time.deltaTime;

        //rotasi pada sumbu y
        transform.Rotate(Vector3.up * angle, Space.World);

    }

    public void PlayThis()
    {
        pickedSound.Play();
    }
}

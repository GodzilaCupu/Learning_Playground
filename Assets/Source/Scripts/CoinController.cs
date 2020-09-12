using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{   
    //deklarasi kecepatan rotasi coin = 100
    public float rotationSpeed = 50f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //menentukan jarak rotasi per frame, dapat di tentukan dari kecepatan rotasi * waktu
        float angle = rotationSpeed * Time.deltaTime;

        //rotasi pada sumbu y
        transform.Rotate(Vector3.up * angle, Space.World);

    }
}

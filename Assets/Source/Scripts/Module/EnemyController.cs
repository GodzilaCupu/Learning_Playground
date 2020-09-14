using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float rangeY = 2f;
    public float speed = 3f;
    public float direction = 1f;


    Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movementY = direction * speed * Time.deltaTime;

        float newY = transform.position.y + movementY;

        if ( Mathf.Abs(newY = initialPos.y) > rangeY)
        {
            direction *= 1;

        }else
        {
            transform.Translate(new Vector3(0, movementY, 0));
        }
    }
}

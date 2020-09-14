using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UIController Ui;



    //deklarasi variable kecepatan untuk jalan dan lompat
    public float walkSpeed = 5f;
    public float jumpSpeed = 4f;

    //deklarasi isPressed yang bertipe boolean agar bisa mengetahui player lompat atau tidak
    bool isPressed = false;

    //deklarasi rigidbody player
    private Rigidbody rb;

    //deklarasi collider player
    private Collider coll;


    public AudioSource coin;

    void Start()
    {
        //mengambil komponen rigidbody
        rb = GetComponent<Rigidbody>();

        //mengambil komponen Collider
        coll = GetComponent<Collider>();

        Ui.Refresh();

    }

    // Update is called once per frame
    void Update()
    {
        WalkControl();
        JumpControl();
    }


    private void JumpControl()
    {
        //inialisasi jump axis
        float jAxis = Input.GetAxis("Jump");

        //insialisasi apakah di tanah
        bool isGorunded = CheekGrounded();

        //melakukan cek kondisi apakah nilai dari jAxis >0 
        if (jAxis > 0f)
        {
            Debug.Log("IsPressed = true ");

            if (!isPressed && isGorunded) 
            {
                isPressed = true;
                //menentukan vector untuk lompat
                Vector3 jump = new Vector3(0f, jumpSpeed, 0f);
                //membuat player bisa lompat 
                rb.velocity = rb.velocity + jump;

            }
        }
        else
        {
            isPressed = false;
        }

    }

    bool CheekGrounded()
    {
        //deklarasi posisi objek 
        float sizeX = coll.bounds.size.x;
        float sizeY = coll.bounds.size.y;
        float sizeZ = coll.bounds.size.z;

        // mendefinisikan masing masing posisi pada sudut objek
        // menambahkan nilai 0.01 pada sumbu y agar ada jarak pada lantai dengan masing masing sudut
        Vector3 corner1 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner2 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner3 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
        Vector3 corner4 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);


        // deteksi apakah 4 sudut ada pada lantai
        bool grounded1 = Physics.Raycast(corner1, new Vector3(0, -1, 0), 0.01f);
        bool grounded2 = Physics.Raycast(corner2, new Vector3(0, -1, 0), 0.01f);
        bool grounded3 = Physics.Raycast(corner3, new Vector3(0, -1, 0), 0.01f);
        bool grounded4 = Physics.Raycast(corner4, new Vector3(0, -1, 0), 0.01f);

        // mengembalikan nilai menjadi nilai baru
        return (grounded1 || grounded2 || grounded3 || grounded4);
    }


    [SerializeField]
    private void WalkControl()
    {
        //mengatur kecepatan pada sumbu x dan z menjadi 0
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        //Jarak ( karena kecepatan = jarak / waktu --> jarak = kecepatan * waktu )
        float distance = walkSpeed * Time.deltaTime;

        //inisialisasi input pada sumbu x ( horizontal )
        float hAxis = Input.GetAxis("Horizontal");

        //inisialisasi input pada sumbu z ( vertical )
        float vAxis = Input.GetAxis("Vertical");

        //kalkulasi untuk movement playernya 
        Vector3 movement = new Vector3(hAxis * distance, 0f, vAxis * distance);

        //mencari tau posisi player asal
        Vector3 curentPosition = transform.position;

        //mencari tau posisi player yang baru 
        Vector3 newPosition = curentPosition + movement;

        //menggerakan player menggunakan rigidbody
        rb.MovePosition(newPosition);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            Debug.Log("Yey Coin");

            coin.Play();
            Ui.Refresh();

            GameManager.instace.IncreceScoring(1);

            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            //Game Over
            print("gameOver");
            Debug.Log("gameOver");
            SceneManager.LoadScene("GameOver");
            
        }


        else if(collider.gameObject.tag == "Goal")
        {
            GameManager.instace.IncreseLevel();
            GameManager.instace.Reset();
            //Game Over
            print("Next Level");
            Debug.Log("Next Level");
        }
    }

}

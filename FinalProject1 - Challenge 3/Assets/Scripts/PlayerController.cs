using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    

    private float nextFire;
    private Rigidbody rb;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    

    void Update()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
           // GameObject clone = 
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp1"))
        {
            other.gameObject.SetActive(false);
            fireRate = fireRate - 1;
            StartCoroutine("waitTime");
        }

        if(other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            speed = speed / 2;
            StartCoroutine("waitTime1");
        }
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3);
        fireRate = fireRate + 1;
    }

    IEnumerator waitTime1()
    {
        yield return new WaitForSeconds(3);
        speed = speed * 2;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}

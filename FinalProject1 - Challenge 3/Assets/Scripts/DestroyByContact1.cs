using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact1 : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController1 gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController1>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }


        if (other.CompareTag ("Player"))
        {
            return;
        }
        gameController.AddScore (scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

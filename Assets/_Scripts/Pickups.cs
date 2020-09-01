using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] private int _score;

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Coin"))
        {
            _score++;
            Destroy(other.gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 0.01f;
    private bool _canRotate = false;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0f,2f);
    }

    // Update is called once per frame
    void Update()
    {
         if (timer > 0) { timer -= 1 * Time.deltaTime; } else { _canRotate = true; }

        // Rotation
        if (_canRotate)
        {
            transform.eulerAngles = new Vector3(0f,transform.eulerAngles.y + _rotationSpeed, 0f);
        }
       

        // Float

    }
}

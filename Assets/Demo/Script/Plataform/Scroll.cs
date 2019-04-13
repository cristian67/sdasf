using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody rb3d;

    void Awake()
    {
        rb3d = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb3d.velocity = new Vector3(0, 0, GameManager.Instance.scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

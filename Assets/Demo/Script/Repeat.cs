using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour
{

    private BoxCollider _collider;
    private float groundZlLenght;

    void Awake()
    {
        _collider = GetComponent<BoxCollider>();

    }

    // Start is called before the first frame update
    void Start()
    {
        groundZlLenght = _collider.size.z;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(groundHorizontalLenght);

        if (transform.position.z < -(groundZlLenght))
        {
            RepositionBackground();
        }
    }


    void RepositionBackground()
    {
        transform.Translate(new Vector3(0, 0, groundZlLenght * 2));
    }
}

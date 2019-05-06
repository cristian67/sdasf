using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshScroll : MonoBehaviour
{
    [SerializeField]
    private float horizont = -9;
    private Transform _transform;

    public int pointHorizontMultiply = 5;

    void Awake()
    {
        _transform = GetComponent<Transform>();

    }

   
    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(groundHorizontalLenght);

        if (transform.position.z < horizont)
        {
            RepositionBackground();
        }
    }


    void RepositionBackground()
    {
        transform.Translate(new Vector3(_transform.position.x, _transform.position.y, horizont * -pointHorizontMultiply));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private List<float> cuadranteI = new List<float> { -1.6f, 0, 1.6f, 3.2f };
    private float number;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        number = (float) _transform.position.x;

        Debug.Log(number);


        cuadranteI.RemoveAll(cuadranteI => cuadranteI==number);

        foreach (float item in cuadranteI)
        {
            Debug.Log(item);
        }

        number = cuadranteI[Random.Range(0, cuadranteI.Count)];

        Debug.Log(number);
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.player.Teleport(new Vector3(number, -0.2f, 0));
        }

    }
}

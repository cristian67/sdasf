using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private List<float> cuadranteI_IV   = new List<float> { -1.6f, 0, 1.6f, 3.2f };
    private List<float> cuadranteI_IV_Y = new List<float> { 0, 5 };
    private List<float> cuadranteII_III = new List<float> { 1.8f, 3.4f};

    private List<float> cuadranteII_III_X = new List<float> { -1.8f, 3.6f };


    private float numberX;
    private float numberY;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        numberX = (float)_transform.position.x;
        numberY = (float)_transform.position.y;

        //Debug.Log(number);

    }


    private void ExtractionPointQ1Q4()
    {
        cuadranteI_IV.RemoveAll(cuadranteI => cuadranteI == numberX);
        numberX = cuadranteI_IV[Random.Range(0, cuadranteI_IV.Count)];

        //foreach (float item in cuadranteI_IV)
        //{
        //    Debug.Log(item);
        //}


        //Debug.Log(number);
    }

    private void ExtractionPointQ1Q4Y()
    {
        cuadranteI_IV_Y.RemoveAll(cuadranteI => cuadranteI == numberY);
        numberY = cuadranteI_IV_Y[Random.Range(0, cuadranteI_IV_Y.Count)];
    }

    private void ExtractionPointQ2Q3()
    {
        cuadranteII_III.RemoveAll(cuadranteI => cuadranteI == numberY);
        numberY = cuadranteII_III[Random.Range(0, cuadranteII_III.Count)];
    }

    private void ExtractionPointQ2Q3X()
    {
        cuadranteII_III_X.RemoveAll(cuadranteI => cuadranteI == numberX);
        numberX = cuadranteII_III_X[Random.Range(0, cuadranteII_III_X.Count)];
    }

    void OnTriggerEnter(Collider other)
    {
        bool q1 = GameManager.Instance.player.q1;
        bool q2 = GameManager.Instance.player.q2;
        bool q3 = GameManager.Instance.player.q3;
        bool q4 = GameManager.Instance.player.q4;

        int random = Random.Range(0, 2);

        Debug.Log(random);

        if (other.gameObject.tag == "Player")
        { 
            switch (random)
            {
                case 1:
                    ExtractionPointQ1Q4();
                    ExtractionPointQ1Q4Y();
                    GameManager.Instance.player.Teleport(new Vector3(numberX, numberY, 0));
                    break;
                case 2:
                    ExtractionPointQ2Q3();
                    ExtractionPointQ2Q3X();
                    GameManager.Instance.player.Teleport(new Vector3(numberX, numberY, 0));
                    break;
                default:
                    ExtractionPointQ2Q3();
                    ExtractionPointQ2Q3X();
                    GameManager.Instance.player.Teleport(new Vector3(numberX, numberY, 0));
                    break;
            }    
        }
    }
}

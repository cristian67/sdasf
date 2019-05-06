using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBlue : MonoBehaviour
{

    //public GameObject portalI;
    public GameObject PortalII;

   

    private float[] cuadranteI_IV = new float[] { -1.6f , 0 , 1.6f , 3.2f };
    private float[] cuadranteII_III  = new float[] { 1.8f, 3.4f };
   
    private float[] cuadrante = new float[] { };


    private GameObject[] portals; //array de objeto

    private Vector3 objectPoolPosition = new Vector3(0, 0,-14);
    private float spawnZPosition = 50f;

    //Varibles update
    private float timeSinceLastSpawned;
    public float spawnRate = 5f;


    private void Start()
    {
        generarColumns();
    }

   
    private void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (timeSinceLastSpawned >= spawnRate)
        {
            generarColumns();
        }
    }

    void generarColumns()
    {

        bool q1 = GameManager.Instance.player.q1;
        bool q2 = GameManager.Instance.player.q2;
        bool q3 = GameManager.Instance.player.q3;
        bool q4 = GameManager.Instance.player.q4;

        PortalInstantiate(q1, q2, q3, q4);

        //if (PortalII)
        //{
        //    Vector3 VectorPositionI = new Vector3(cuadranteI[Random.Range(0, cuadranteI.Length)], -0.2f, PortalII.transform.position.z);
        //    portalI = Instantiate(portalI, VectorPositionI, Quaternion.identity);
        //}
    }

    private void PortalInstantiate(bool q1, bool q2, bool q3, bool q4)
    {
        if (q1)
        {
            timeSinceLastSpawned = 0;

            Vector3 VectorPositionII = new Vector3(cuadranteI_IV[Random.Range(0, cuadranteI_IV.Length)], 0.5f, spawnZPosition);
            PortalII = Instantiate(PortalII, VectorPositionII, Quaternion.identity);
        }

        if (q2)
        {
            timeSinceLastSpawned = 0;

            Vector3 VectorPositionII = new Vector3(3.4f, cuadranteII_III[Random.Range(0, cuadranteII_III.Length)], spawnZPosition);
            PortalII = Instantiate(PortalII, VectorPositionII, Quaternion.identity);
        }

        if (q3)
        {
            timeSinceLastSpawned = 0;

            Vector3 VectorPositionII = new Vector3(-1.9f, cuadranteII_III[Random.Range(0, cuadranteII_III.Length)], spawnZPosition);
            PortalII = Instantiate(PortalII, VectorPositionII, Quaternion.identity);
        }

        if (q4)
        {
            timeSinceLastSpawned = 0;

            Vector3 VectorPositionII = new Vector3(cuadranteI_IV[Random.Range(0, cuadranteI_IV.Length)], 5f, spawnZPosition);
            PortalII = Instantiate(PortalII, VectorPositionII, Quaternion.identity);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBlue : MonoBehaviour
{

    public GameObject portalI;
    public GameObject PortalII;


    private float[] cuadranteI   = new float[] { -1.6f , 0 , 1.6f , 3.2f };
    private float[] cuadranteII  = new float[] { };
    private float[] cuadranteIII = new float[] { };
    private float[] cuadranteIV  = new float[] { };


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

        timeSinceLastSpawned = 0;

        Vector3 VectorPositionII = new Vector3(cuadranteI[Random.Range(0, cuadranteI.Length)], -0.2f, spawnZPosition);
        PortalII = Instantiate(PortalII, VectorPositionII, Quaternion.identity);

        if (PortalII)
        {
            Vector3 VectorPositionI = new Vector3(cuadranteI[Random.Range(0, cuadranteI.Length)], -0.2f, PortalII.transform.position.z);
            portalI = Instantiate(portalI, VectorPositionI, Quaternion.identity);
        }
    }

    
}

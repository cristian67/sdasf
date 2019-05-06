using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private List<float> cuadranteI_IV = new List<float> { -1.6f, 0, 1.6f, 3.2f };
    [SerializeField]
    private List<float> cuadranteI_IV_Y = new List<float> { 0, 4.5f };
    [SerializeField]
    private List<float> cuadranteII_III = new List<float> { 1.5f, 2.6f };
    [SerializeField]
    private List<float> cuadranteII_III_X = new List<float> { -1.8f, 3.6f };

   
    public float numberX;
    public float numberY;

    private Transform _transform;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _transform   = GetComponent<Transform>(); 

        //Debug.Log(number);

    }

    private void Update()
    {
        Debug.DrawLine(transform.position, new Vector3(numberX, numberY, 0), Color.yellow, 2.5f);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.player.Teleport(new Vector3(numberX, numberY, 0));
            _audioSource.Play();
            Destroy(gameObject,1f);
        }
    }
}

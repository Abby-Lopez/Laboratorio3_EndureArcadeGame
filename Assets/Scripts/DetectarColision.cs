using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColision : MonoBehaviour
{
    public Material materialResaltado;
    public Material materialOriginal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Este código se activa cuando entra una colisión
        Debug.Log("Un objeto ha entrado al trigger");

        if(other.CompareTag("Player"))
        {
            Debug.Log("Es un objeto con el tag Player");

            try
            {
                var player = other.GetComponent<Player>();
                player.Alerta();

                var rigidbd = other.GetComponent<Rigidbody>();
                //rigidbd.AddTorque(new Vector3(Random.Range(0f, 1000f), Random.Range(0f, 1000f), Random.Range(0f, 1000f)));
                rigidbd.AddForce(new Vector3(Random.Range(-1000f, 1000f), Random.Range(1f, 1000f), Random.Range(-1000f, 1000f)));
            }
            catch(System.Exception ex)
            {
                Debug.LogError("Se te olvidó poner un componente Player en el objeto que tiene la etiqueta player: "+ ex.Message);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Este código se ejecuta por frame (como un update) mientras exita una colisión
        Debug.Log("Un objeto está dentro del trigger");

        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialResaltado;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Este código se activa cuando sale del volumen de un trigger
        Debug.Log("Un objeto ha salido del trigger");

        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialOriginal;
        }
    }
}

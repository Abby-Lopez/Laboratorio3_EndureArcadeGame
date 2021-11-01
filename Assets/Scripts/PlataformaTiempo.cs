using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTiempo : MonoBehaviour
{

    public GameObject plataforma;
    public bool visibilidad = true;
    public bool whileInfinito = true;


    void Start()
    {
       
        Debug.Log("Hola");
        CambiarVisibilidad();

    }

    public void CambiarVisibilidad()
    {
        while (visibilidad)
        {
            if (visibilidad == true)
            {
                StartCoroutine(Hide());
            }
            else
            {
                StartCoroutine(Show());
            }
        }
    }

    IEnumerator Show()
    {
        yield return new WaitForSeconds(3);
        plataforma.SetActive(true);
        visibilidad = true;
        Debug.Log("visible");

    }

    IEnumerator Hide()
    {

          yield return new WaitForSeconds(3);
          plataforma.SetActive(false);
          visibilidad = false; 
          Debug.Log("Invisible");
     
    }

}

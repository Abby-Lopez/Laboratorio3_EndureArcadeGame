using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeHelper : MonoBehaviour
{
    public string EscenaPortada;
    public float timer = 5f;

    public Text PrimerLugarPuntaje;
    public Text PrimerLugarNombre;

    public Text SegundoLugarPuntaje;
    public Text SegundoLugarNombre;

    public Text TerceroLugarPuntaje;
    public Text TerceroLugarNombre;
    void Start()
    {
        PrimerLugarPuntaje.text = PlayerPrefs.GetInt("Pos01", 0).ToString();
        PrimerLugarNombre.text = PlayerPrefs.GetString("Pos01Nombres", "UCR").ToString();

        SegundoLugarPuntaje.text = PlayerPrefs.GetInt("Pos02", 0).ToString();
        SegundoLugarNombre.text = PlayerPrefs.GetString("Pos02Nombres", "UCR").ToString();

        TerceroLugarPuntaje.text = PlayerPrefs.GetInt("Pos03", 0).ToString();
        TerceroLugarNombre.text = PlayerPrefs.GetString("Pos03Nombres", "UCR").ToString();

        StartCoroutine( EsperarCambioEscena() );
    }

    private IEnumerator EsperarCambioEscena()
    {
        yield return new WaitForSeconds(timer);

        VolverPortada();
    }

    public void VolverPortada()
    {
        try
        {
            GameManager.instancia.CambiarEscena(EscenaPortada);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvidó poner el GameManager en la escena");
        }
    }
}

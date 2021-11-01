using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector3 _posInicial;
    private Rigidbody rigidBody;
    private float velX;
    private float velY;
    private float jump;
    private bool enPiso;
    private float tiempoDeJuego;
    private int puntaje;

    public float velocidad = 1.5f;
    public float fuerzaVertical = 2f;
    public float tiempoTranscurrido = 0f;
    public float tiempoLimite = 30;
    public Text txt_TiempoTranscurrido;
    public Text txt_PuntajeActual;
    public Text txt_LimiteActual;

    // Start is called before the first frame update
    void Start()
    {
       GameManager.instancia.RestaurarPuntaje();

       rigidBody = this.GetComponent<Rigidbody>();
        
        puntaje = 0;
        
        _posInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void IncrementarPuntaje(int valor)
    {
        puntaje += valor;
        Debug.Log("Puntaje Actual: " + puntaje.ToString());
    }

    public void ModificarTiempo(float valor)
    {
        Debug.Log("Tiempo Actual " + tiempoDeJuego.ToString());
        tiempoDeJuego -= valor;
        Debug.Log("Tiempo con reducción " + tiempoDeJuego.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        // Actualizar interfaces gráficas
        txt_TiempoTranscurrido.text = this.tiempoTranscurrido.ToString();
        txt_PuntajeActual.text = this.puntaje.ToString();
        txt_LimiteActual.text = (tiempoLimite - tiempoDeJuego).ToString();

        // Contador de tiempo
        tiempoTranscurrido += Time.deltaTime;
        tiempoDeJuego += Time.deltaTime;

        if (tiempoDeJuego > tiempoLimite)
        {
            FinDeJuego();
            GameManager.instancia.CambiarEscena("Perdida");
        }

        velX = Input.GetAxis("Horizontal"); // -1 ... -.5 ... 0 ... .5... 1
        velY = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        enPiso = Physics.Raycast(this.transform.position, Vector3.down, 1.02f);
        

        if (velX != 0 || velY != 0)
        {
            rigidBody.velocity = (new Vector3(velX, 0, velY)) * velocidad;
        }

        if(enPiso && jump >= 0.3f)
        {
            rigidBody.AddForce( Vector3.up * fuerzaVertical );
        }
       
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("ENTER HA SIDO PRESIONADO");

            transform.position = new Vector3(_posInicial.x, _posInicial.y, _posInicial.z);

            rigidBody.velocity = Vector3.zero;
        }
    }

    public void Alerta()
    {
        Debug.Log("Conexión con un trigger establecida");
    }

    public void FinDeJuego()
    {
        Debug.Log("Juego Finalizado");
        GameManager.instancia.SumarPuntaje(Convert.ToInt32(puntaje * tiempoTranscurrido * 100));
        GameManager.instancia.CambiarEscena("Perdida");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;

public class CameraControl : MonoBehaviour
{
    public Camera camaraAerea;
    public Camera camaraPlayer;
    //Definir variable de desplazamiento
    public float velocidad = 1.0f;
    //Definimos el target hacia el cual apunta la camara
    public Transform destino;
    // Definimos el tiempo en el cual se efectua el desplazamiento
    public float Timer = 10.0f;

   

    // Start is called before the first frame update
    void Start()
    {
        // activamos camara aerea al inicio y desactivamos la camara del jugador;
        camaraAerea.enabled = true;
        camaraPlayer.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // efectuamos un seguimiento del target (player) apuntando la camara aerea
        if(destino != null)
        {
            // Seguimos al destino segun su posicion (player)
            transform.LookAt(destino);
            // Definimos la distancia des destino
            Vector3 distancia = (destino.position - transform.position).normalized;
            // Desplazamiento hacia el player(destino o target)
            transform.Translate(distancia * velocidad * Time.deltaTime, Space.World);
        }
        //  Actualizamos timer
        Timer -= Time.deltaTime;
        // Establecemos la configuracion del timer para el desplazamiento
        if(Timer <=0)
        {
            // Desactivamos camara aera y habilitamos camara de player
            camaraAerea.enabled = false;
            camaraPlayer.enabled = true;
            // Desactivamos este scrip, asi no hay manipulacion de camaras por el script
            this.enabled = false;
        }
    }
}

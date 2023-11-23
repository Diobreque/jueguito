using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneContral : MonoBehaviour
{
    public GameObject Canva_Tiempo;
    // Tiempo para llegar a la meta
    public float timerEscena = 20.0f;
    public Camera CamaraPlayer;
    public AudioSource Audio_Gameover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    // Establecemos la configuracion del timer para el desplazamiento
    if(CamaraPlayer.enabled){
            Debug.Log("Camara player habilitada");
            timerEscena -= Time.deltaTime;
            // Activamos el canvas de tiempo
            Canva_Tiempo.SetActive(false);
            // detener sonido background

            // ejecutar sonido
                // Play on awake lo ejecuta desde el inicio
        }
        if(timerEscena <=0)
        {
            Debug.Log("Camara player habilitada");

        }else{
            Debug.Log("Camara player deshabilidada");
        }

    }
}

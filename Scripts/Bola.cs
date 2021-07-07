using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Bola : MonoBehaviour
{
    public float velocidad = 30.0f;
    AudioSource fuenteDeAudio;
    public AudioClip audioGol, audioRaqueta, audioRebote;
    public int golesIzquierda = 0;
    public int golesDerecha = 0;
    public Text contadorIzquierda;
    public Text contadorDerecha;
    public Text Win;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
        fuenteDeAudio = GetComponent<AudioSource>();
        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();
        Win.text="";
    }

    void OnCollisionEnter2D(Collision2D micolision)
    {
        if (micolision.gameObject.name == "Raqueta Izquierda")
        {
            int x = 1;
            int y = direccionY(transform.position,micolision.transform.position);
            Vector2 direccion = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }
        else if (micolision.gameObject.name == "Raqueta Derecha")
        {
            int x = -1;
            int y = direccionY(transform.position,
            micolision.transform.position);
            Vector2 direccion = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }
        if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo")
        {
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }
        if(micolision.gameObject.name == "Derecha" )
        {
            reiniciarBola("Derecha");
        }
        if (micolision.gameObject.name == "Izquierda")
        {
            reiniciarBola("Izquierda");
        }
    }

    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta)
    {
        if (posicionBola.y > posicionRaqueta.y)
        {
            return 1;
        }
        else if (posicionBola.y < posicionRaqueta.y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public void reiniciarBola(string direccion)
    {
        transform.position = Vector2.zero;
        velocidad = velocidad + 4.0f;
        if (direccion == "Derecha")
        {
            golesDerecha++;
            if (golesDerecha >= 5)
            {
                Ganador(direccion);
            }
            contadorDerecha.text = golesDerecha.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.right *velocidad;
        }
        else if (direccion == "Izquierda")
        {
            golesIzquierda++;
            if(golesIzquierda >= 5)
            {
                Ganador(direccion);
            }
            contadorIzquierda.text = golesIzquierda.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.left *velocidad;
        }
    }

    public void Ganador(string direccion)
    {
        Win.text = "El Ganador Es El Jugador " + direccion;
        transform.position = Vector2.zero;
        golesDerecha = 0;
        golesIzquierda = 0;
        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();
        SceneManager.LoadScene("Inicio");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(100000);
    }
    void Update()
    {
        
    }
}

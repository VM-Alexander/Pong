using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    public float velocidad = 30.0f;
    public string eje;
    public string Horizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(eje);
        float v2 = Input.GetAxisRaw(Horizontal);
        GetComponent<Rigidbody2D>().velocity = new Vector2(v2 * velocidad, v * velocidad);

    }
}

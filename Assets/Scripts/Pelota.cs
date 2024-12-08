using System.Collections;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private float fuerza = 1.0f;

    [SerializeField]
    private float anguloMinimo = 20.0f;

    [SerializeField]
    private float anguloMaximo = 45.0f;

    [SerializeField]
    private float posicionSalidaMinimo = 4.0f;

    [SerializeField]
    private float posicionSalidaMaximo = -4.0f;

    [SerializeField]
    private float retardoLanzamiento = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector2(1, 1) * fuerza, ForceMode2D.Impulse);

        int direccionX = Random.Range(0, 2) == 0 ? -1 : 1;
        //LanzarPelota(direccionX);
        StartCoroutine(LanzarPelota(direccionX));
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string etiqueta = collision.gameObject.tag;
        //Debug.Log("OnCollisionEnter2D " + etiqueta);

        switch (etiqueta)
        {
            case "PalaDerecha":
                break;

            case "PalaIzquierda":
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string etiqueta = collision.tag;
        //Debug.Log("OnTriggerEnter2D " + etiqueta);

        switch (etiqueta)
        {
            case "PorteriaDerecha":
                gameManager.PuntuarJugadorIzquierda();
                StartCoroutine(LanzarPelota(1));

                break;

            case "PorteriaIzquierda":
                gameManager.PuntuarJugadorDerecha();
                StartCoroutine(LanzarPelota(-1));

                break;

            default:
                break;
        }
    }

    private IEnumerator LanzarPelota(int direccionX)
    {
        yield return new WaitForSeconds(retardoLanzamiento);

        // cálculo de la posición vertical de lanzamiento
        float posicionY = Random.Range(posicionSalidaMinimo, posicionSalidaMaximo);
        transform.position = new Vector3(0, posicionY, 0);

        // cálculo del vector de lanzamiento
        float angulo = Random.Range(anguloMinimo, anguloMaximo) * Mathf.Deg2Rad;
        float x = Mathf.Cos(angulo) * direccionX;

        int direccionY = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Mathf.Sin(angulo) * direccionY;

        Vector2 impulso = new Vector2(x, y);

        // resetear la velocidad lineal de la pelota, para que con cada ejecución no sume más fuerza
        rb.linearVelocity = Vector2.zero;

        rb.AddForce(impulso * fuerza, ForceMode2D.Impulse);
    }
}
using UnityEngine;

public class Pala : MonoBehaviour
{
    [SerializeField]
    public float velocidad = 12.50f;

    private readonly float limiteSuperior = 8.0f;
    private readonly float limiteInferior = -8.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameObject.tag == "PalaDerecha")
        {
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < limiteSuperior)
            {
                transform.Translate(Time.deltaTime * velocidad * Vector3.up, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > limiteInferior)
            {
                transform.Translate(Time.deltaTime * velocidad * Vector3.down, 0);
            }
        }

        if (gameObject.tag == "PalaIzquierda")
        {
            if (Input.GetKey(KeyCode.W) && transform.position.y < limiteSuperior)
            {
                transform.Translate(Time.deltaTime * velocidad * Vector3.up, 0);
            }

            if (Input.GetKey(KeyCode.S) && transform.position.y > limiteInferior)
            {
                transform.Translate(Time.deltaTime * velocidad * Vector3.down, 0);
            }
        }

    }
}
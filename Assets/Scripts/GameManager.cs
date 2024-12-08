using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int puntuacionJugadorDerecha;
    private int puntuacionJugadorIzquierda;

    [SerializeField]
    private GameObject pelota;

    [SerializeField]
    private TextMeshProUGUI textoPuntuacionJugadorDerecha;

    [SerializeField]
    private TextMeshProUGUI textoPuntuacionJugadorIzquierda;

    private bool enEjecucion = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Cursor.visible= false;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("1 : " + puntuacionJugadorDerecha + "   - 2 : " + puntuacionJugadorIzquierda);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!enEjecucion && Input.GetKeyDown(KeyCode.Space))
        {
            enEjecucion = true;

            pelota.SetActive(true);
        }
    }

    private void OnGUI()
    {
        textoPuntuacionJugadorDerecha.SetText(puntuacionJugadorDerecha.ToString());

        textoPuntuacionJugadorIzquierda.SetText(puntuacionJugadorIzquierda.ToString());
    }

    public void PuntuarJugadorDerecha()
    {
        puntuacionJugadorDerecha++;
    }

    public void PuntuarJugadorIzquierda()
    {
        puntuacionJugadorIzquierda++;
    }
}
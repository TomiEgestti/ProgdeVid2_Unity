using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogoon : MonoBehaviour
{
    [SerializeField, TextArea(4,6)] private string[] lineas;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text texto;

    private bool isplayerinrange;
    private bool empezo;
    private int Lineindex;
    private float tiempo = 0.05f;

    void Update()
    {
        if (isplayerinrange)
        {
            if (!empezo && Input.GetButtonDown("Fire1"))
            {
                Startdialogue();
            }
            else if(texto.text == lineas[Lineindex] && Input.GetButtonDown("Fire1"))
            {
                siguientedialogo();
            }
        }
    }

    private void Startdialogue()
    {
        empezo = true;
        panel.SetActive(true);
        Lineindex = 0;
        StartCoroutine(Showline());

    }

    private void siguientedialogo()
    {
        Lineindex++;
        if (Lineindex < lineas.Length) 
        {
            StartCoroutine(Showline());
        }
        else
        {
            empezo = false;
            panel.SetActive(false);
        }
    }

    private IEnumerator Showline()
    {
        texto.text = string.Empty;

        foreach(char ch in lineas[Lineindex])
        {
            texto.text += ch;
            yield return new WaitForSeconds(tiempo);
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isplayerinrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isplayerinrange = false;
        }
    }
}

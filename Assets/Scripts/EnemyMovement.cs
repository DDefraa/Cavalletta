using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float velocitaNemico = 3f;

    private Vector2 direction = Vector2.down;
    //Vector2 direzioneMovimento;

    public float intervalloCambiamentoDirezione; // intervallo di tempo in secondi tra un cambio di direzione e l'altro
    float tempoUltimoCambiamentoDirezione;

  

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        
    }
    void Start()
    {
        tempoUltimoCambiamentoDirezione = Time.time;
        CambiaDirezioneCasuale();
    }

    void Update()
    {
        // controlla se è passato abbastanza tempo dall'ultimo cambio di direzione e cambia direzione se necessario
        if (Time.time - tempoUltimoCambiamentoDirezione > intervalloCambiamentoDirezione)
        {
            CambiaDirezioneCasuale();
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        rigidbody.MovePosition(rigidbody.position + direction * velocitaNemico * Time.fixedDeltaTime);
    }

    void CambiaDirezioneCasuale()
    {
        

        // genera un vettore casuale con componenti x e y comprese tra -1 e 1
        Vector2 direzioneCasuale = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
       
        if (Mathf.Abs(direzioneCasuale.x) > Mathf.Abs(direzioneCasuale.y))
        {
            direzioneCasuale.y = 0f;
        }
        else
        {
            direzioneCasuale.x = 0f;
        }
        direction = direzioneCasuale;
        tempoUltimoCambiamentoDirezione = Time.time;
    }
}

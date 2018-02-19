using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour {

	public float velocidade;
    bool colidiu;
    public static bool iniciado;
    public static bool paraSeguir;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (!iniciado && (Input.GetKey(KeyCode.Return) || Input.touchCount == 1))
        {
            iniciado = true;
        }

        if (iniciado && !colidiu) {
            paraSeguir = true;
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }

    }

	void OnCollisionEnter2D(Collision2D c) {
        iniciado = false;
        colidiu = true;

        if (c.gameObject.tag == "Bloco") {
			print ("Colidiu bloco");
            Principal.pontos++;
			if (Principal.pontos == 3) {
				print ("Vitoria");
				irParaInicio ();
			}

            float x = hitFactorX(transform.position,
                c.transform.position,
                c.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, -1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * velocidade ;

            Destroy (c.gameObject);
		}
		if (c.gameObject.tag == "Plataforma") {
			print ("Colidiu Plataforma");

                float x = hitFactorX(transform.position,
                    c.transform.position,
                    c.collider.bounds.size.x);

                Vector2 dir = new Vector2(x, 1).normalized;

                GetComponent<Rigidbody2D>().velocity = dir * velocidade;
            
		}

		if (c.gameObject.tag == "ParedeDireita") {
			print ("Parede");

			float y = hitFactor(transform.position,
				c.transform.position,
				c.collider.bounds.size.y);

			Vector2 dir = new Vector2(-1, y).normalized;

			GetComponent<Rigidbody2D>().velocity = dir * velocidade;
		}


		if (c.gameObject.tag == "ParedeEsquerda") {
			print ("Parede");

			float y = hitFactor(transform.position,
				c.transform.position,
				c.collider.bounds.size.y);

			Vector2 dir = new Vector2(1, y).normalized;

			GetComponent<Rigidbody2D>().velocity = dir * velocidade;
		}

		if (c.gameObject.tag == "Teto") {
			print ("Teto");

            float x = hitFactorX(transform.position,
                c.transform.position,
                c.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, -1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * velocidade;
        }


		if (c.gameObject.tag == "FaixaGameOver") {
			print ("Game Over");
			irParaInicio ();
		}
		
        
		
	}

	void irParaInicio () {
		SceneManager.LoadScene ("Inicio");
		iniciado = false;
        paraSeguir = false;

    }

    float hitFactor(Vector2 ballPos, Vector2 plataformaPos,
                float racketHeight) {
		return (ballPos.y - plataformaPos.y) / racketHeight;
}

    float hitFactorX(Vector2 ballPos, Vector2 plataformaPos,
                float racketHeight)
    {
        return (ballPos.x - plataformaPos.x) / racketHeight;
    }


}

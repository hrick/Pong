using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour {

	public float velocidade;
    public GameObject bola;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {

            Vector2 posicaoMouse = Input.mousePosition;
            Vector2 posicaoMouseBola = Input.mousePosition;

            posicaoMouse = Camera.main.ScreenToWorldPoint(posicaoMouse);
            posicaoMouseBola = Camera.main.ScreenToWorldPoint(posicaoMouseBola);


            posicaoMouse = new Vector2(posicaoMouse.x, gameObject.transform.position.y);
            posicaoMouseBola = new Vector2(posicaoMouseBola.x, bola.gameObject.transform.position.y);


            transform.position = Vector2.Lerp (transform.position, posicaoMouse, velocidade * Time.deltaTime);

            if (!Bola.iniciado && !Bola.paraSeguir)
            {
                bola.transform.position = Vector2.Lerp(bola.transform.position, posicaoMouseBola, velocidade * Time.deltaTime);

                //   bola.transform.position = Vector2.MoveTowards(b:ola.transform.position, gameObject.transform.position, velocidade * Time.deltaTime);
            }

        }
    }
}

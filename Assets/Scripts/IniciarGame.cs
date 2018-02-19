using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Inicia o game
		if (Input.GetKey(KeyCode.Return) || Input.touchCount == 1) {
			Principal.pontos = 0;
			SceneManager.LoadScene ("Game");
		}	
	}
}

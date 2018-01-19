using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatasAkhirSampah : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	//Method ini dijalankan ketika ada sebuah object yang masuk ke area Trigger. 
	void OnTriggerEnter2D(Collider2D collision)
	{	

		//Kemudian menghapus gameobject tersebut
		Destroy(collision.gameObject);
		SceneManager.LoadScene("GameOver"); // Baris Ini akan digunakan pada submodul GameOver
	}
}
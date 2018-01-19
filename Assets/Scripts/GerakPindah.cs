using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPindah : MonoBehaviour {

	// Menyimpan nilai pecahan yang digunakan untuk menentukan kecepatan dengan nilai awal 3
	float speed = 3f;

	// Menyimpan nilai array tunggal yang nantinya digunakan untuk menyimpan Gambar yang berupa sprite.
	public Sprite[] sprites;
	
	// Use this for initialization
	void Start () {
		// Memberi nilai Acak dengan batasan maksimal sejumlah array Sprite yang dimasukkan.
		int index = Random.Range (0, sprites.Length);

		// Mengganti gambar object sampah dari gambar sprite yang akan dimasukkan.
		gameObject.GetComponent<SpriteRenderer>().sprite = sprites [index];
	}
	
	// Update is called once per frame
	void Update () {
		//Menghitung pergerakkan ke kiri berikutnya pada suatu object berdasarkan sumbu x. 
		float move = (speed * Time.deltaTime * -1f) + transform.position.x; 

		// Mengimplementasikan pergerakkan secara horizontal pada Gameobject.
		transform.position = new Vector3(move, transform.position.y);
	}

	// private berfungsi agar kelas ini saja yang dapat mengakses
	// screen point digunakan untuk menyimpan posisi koordinat 3d dari vector3
	private Vector3 screenPoint;  

	// variable offset untuk menyimpan selisih posisi object dngn posisi mouse
	private Vector3 offset; 

	// variable unutk mnyimpan posisi vertical awal yang nantinya digunakan untuk mengembalikan keposisi semula
	private float firstY;


	// method yg djalankan saaat mouse.touch pada sebuah GameObject yg memiliki collider yg berfungsi untuk menyimpan nilai yg
	// digunakan saat drag GameObject
	void OnMouseDown()
	{
		firstY = transform.position.y;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}


	// method yang dijalankan saat gameobject di geser	
	// berfungsi untuk memindahkan posisi gameobject berdasarkan posisi mouse
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}


	// method yang dijlankan saat mouse di lepaskan
	private void OnMouseUp()
	{
		transform.position = new Vector3(transform.position.x,firstY, transform.position.z);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculkanSampah : MonoBehaviour {
	// menentukan waktu jeda
	public float jeda = 0.8f;

	// menyimpan waktu
	float timer;

	// menyimpan object sampah yang akn
	public GameObject[] obyekSampah;


	// Use this for initialization
	void Start()
	{
		
	}
	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer > jeda)
		{	
			// menentukan index object sampah secara acak yang akan dimunculkan
			int random = Random.Range(0, obyekSampah.Length);

			// untuk memunculkan object Sampah dari index yang telah ditentukan sebelumnya 
			// dengan posisi dan rotasi Gameoject yang terdapat Script ini.
			Instantiate(obyekSampah[random], transform.position, transform.rotation);

			// Setelah selesai menjalankan code diatas, kemudian timer dikembalikan ke 0 untuk menghitung nilai jeda dari awal.
			timer = 0;
		}
	}
}

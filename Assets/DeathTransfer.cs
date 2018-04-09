using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTransfer : MonoBehaviour {

	void OnTriggerEnter2D () {
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}

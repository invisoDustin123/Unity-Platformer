using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {


	void OnMouseOver ()
	{
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
		}
	}
}

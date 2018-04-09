using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clicked : MonoBehaviour {


	void OnMouseOver () 
	{
		if (Input.GetMouseButtonDown (0))
		{
			SceneManager.LoadScene("plizzityplatformer", LoadSceneMode.Single);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VuforiaUI : MonoBehaviour {
	public string LoadScene;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void onButtonClicked(){
		SceneManager.LoadScene(LoadScene);
	}
}

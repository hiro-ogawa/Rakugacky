using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckTouch : MonoBehaviour {
	public string LoadScene;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0)
		{
			Debug.Log("tap");
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began)
			{
				// タッチ開始
				// SceneManager.LoadScene("VuforiaOgawaScene");
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				// タッチ移動
				// SceneManager.LoadScene("VuforiaOgawaScene");
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				// タッチ終了
				SceneManager.LoadScene(LoadScene);
			}
		}
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("mouse");
			SceneManager.LoadScene(LoadScene);
    }
	}
}

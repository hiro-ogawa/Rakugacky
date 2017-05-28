using UnityEngine;
using System.Collections;
using Vuforia;

public class CameraFocusController : MonoBehaviour {

    private bool mVuforiaStarted = false;
	private Vector3 touchStartPos;
	private Vector3 touchEndPos;

    void Start () 
    {
        VuforiaARController vuforia = VuforiaARController.Instance;

        if (vuforia != null)
            vuforia.RegisterVuforiaStartedCallback(StartAfterVuforia);
		Flick ();
    }

	void Update (){
		Flick ();
	}
    private void StartAfterVuforia()
    {
        mVuforiaStarted = true;
        SetAutofocus();
    }

    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // App resumed
            if (mVuforiaStarted)
            {
                // App resumed and vuforia already started
                // but lets start it again...
                SetAutofocus(); // This is done because some android devices lose the auto focus after resume
                // this was a bug in vuforia 4 and 5. I haven't checked 6, but the code is harmless anyway
            }
        }
    }

    private void SetAutofocus()
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
        {
            Debug.Log("Autofocus set");
        }
        else
        {
            // never actually seen a device that doesn't support this, but just in case
            Debug.Log("this device doesn't support auto focus");
        }
    }

	void Flick(){
		if (Input.GetKeyDown(KeyCode.Mouse0)){
			touchStartPos = new Vector3(Input.mousePosition.x,
				Input.mousePosition.y,
				Input.mousePosition.z);
		}

		if (Input.GetKeyUp(KeyCode.Mouse0)){
			touchEndPos = new Vector3(Input.mousePosition.x,
				Input.mousePosition.y,
				Input.mousePosition.z);
			GetDirection();
		}
	}

	void GetDirection(){
		float directionX = touchEndPos.x - touchStartPos.x;
		float directionY = touchEndPos.y - touchStartPos.y;
		string Direction = "";

		if (Mathf.Abs(directionY) < Mathf.Abs(directionX)){
			if (30 < directionX){
				//右向きにフリック
				Direction = "right";

			}else if (-30 > directionX){
				//左向きにフリック
				Direction = "left";
			}
		}else if (Mathf.Abs(directionX)<Mathf.Abs(directionY)){
			if (30 < directionY){
				//上向きにフリック
				Direction = "up";
			}else if (-30 > directionY){
				//下向きのフリック
				Direction = "down";
			}
		}else{
			//タッチを検出
			Direction = "touch";
		}
		Debug.Log("Direction:"+ Direction );

		switch (Direction){
		case "up":
			//上フリックされた時の処理
			break;

		case "down":
			//下フリックされた時の処理
			break;

		case "right":
			//右フリックされた時の処理
			break;

		case "left":
			//左フリックされた時の処理
			break;

		case "touch":
			//タッチされた時の処理
			break;
		}

	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;

using Bluetooth;
using Bluetooth.Controller;
using Bluetooth.Model;
using Utils;

public class ButtonController : MonoBehaviour {
	public Button	button;
	Timer deltaTime;

	private int buttonActiveFlag = 0;
	//public Image image;
	void Start () 
	{
		//button = transform.Find("Button").GetComponent<Button>();
		//image = transform.Find("Image").GetComponent<Image>();
		EventTriggerListener.Get(button.gameObject).onClick =OnButtonClick;
		//EventTriggerListener.Get(image.gameObject).onClick =OnButtonClick;

		//EventTriggerListener.Get(button.gameObject).onDown =OnButtonDown;
		//EventTriggerListener.Get(button.gameObject).onSelect =OnButtonSlect;
		EventTriggerListener.Get(button.gameObject).onEnter =OnButtonEnter;
		EventTriggerListener.Get(button.gameObject).onExit =OnButtonExit;

		deltaTime = new Timer(0.1f);
		deltaTime.tick += DeltaTimeOperation;
		deltaTime.Stop ();
	}


	// Update is called once per frame
	void Update () {

		deltaTime.Update(Time.deltaTime);
	}


	private void OnButtonClick(GameObject go){
		if(go.CompareTag ("motion")){
			BtnTransfer (button.gameObject.name);
		} else if (go.CompareTag ("rejectory")) {
			MotionRejectoryType type;
			switch (go.name) {
			case "Rejectory1":
				type = MotionRejectoryType.Rejectory1;
				break;
			case "Rejectory2":
				type = MotionRejectoryType.Rejectory2;
				break;
			case "Rejectory3":
				type = MotionRejectoryType.Rejectory3;
				break;
			case "Rejectory4":
				type = MotionRejectoryType.Rejectory4;
				break;
			default:
				return;
				break;
			}
			StartCoroutine(doSomeThing (type));
		}
	}

	private void OnButtonExit(GameObject go){
		//在这里监听按钮的点击事件


		Debug.Log ("Button Exit");
		//在这里监听按钮的点击事件
		if(go == button.gameObject){
			Debug.Log ("DoSomeThings");
			buttonActiveFlag = 0;
		}
	}
	private void OnButtonEnter(GameObject go){
		//在这里监听按钮的点击事件
		Debug.Log ("Button Enter");

		//在这里监听按钮的点击事件
			//BtnTransferCoroutine ();
		StartBtnTransfer();
	}

	private void DeltaTimeOperation()
	{
		Debug.Log ("DeltaTimeOperation");//
		//BtnTransfer (btnName);


		//点击事件或者长按事件，只要碰到了，都必须至少触发一次行动
		BtnTransfer (button.gameObject.name);

		if (buttonActiveFlag==1)
		{
			Debug.Log ("DeltaTimeOperation  send Start");
			deltaTime.Start();

		}
		else{
			deltaTime.Stop();
			//BtnTransfer (button.gameObject.name);
		}
	}

	//do button operation by Coroutine
	private void  StartBtnTransfer()
	{
		buttonActiveFlag=1;
		deltaTime.Start();
	}

	private void BtnTransfer(string btnName)
	{
		BleController bc = BleController.Instance;
		Dictionary<string, int> dict = new Dictionary<string, int> ();
		//print (btnName);

		//up
		switch (btnName) {
		case "ButtonUp":
			dict [BLE.KEY_MOVE_SPEED_L] = 98;
			dict [BLE.KEY_MOVE_SPEED_R] = 98;
			dict [BLE.KEY_MOVE_TIME] = 200;
			bc.Transfer(BleModelType.BLE_MOVE, dict);

			break;

		case "ButtonDown":
			dict [BLE.KEY_MOVE_SPEED_L] = -98;
			dict [BLE.KEY_MOVE_SPEED_R] = -98;
			dict [BLE.KEY_MOVE_TIME] = 200;
			bc.Transfer(BleModelType.BLE_MOVE, dict);

			break;

		case "ButtonLeft":
			dict [BLE.KEY_MOVE_SPEED_L] = 98;
			dict [BLE.KEY_MOVE_SPEED_R] = -98;
			dict [BLE.KEY_MOVE_TIME] = 200;
			bc.Transfer(BleModelType.BLE_MOVE, dict);

			break;
		case "ButtonRight":
			dict [BLE.KEY_MOVE_SPEED_L] = -98;
			dict [BLE.KEY_MOVE_SPEED_R] = 98;
			dict [BLE.KEY_MOVE_TIME] = 200;
			bc.Transfer(BleModelType.BLE_MOVE, dict);

			break;

		default:
			break;

		}
	}

	private IEnumerator doSomeThing(MotionRejectoryType type) {
		BleController bc = BleController.Instance;
		foreach (Dictionary<string, int> dict in bc.Trajectory(type)) {
			bc.Transfer (BleModelType.BLE_MOVE, dict);
			int time = dict [BLE.KEY_MOVE_TIME];
			float ft = (float)time / 1000;
			yield return new WaitForSeconds(ft);
		}
	}
}

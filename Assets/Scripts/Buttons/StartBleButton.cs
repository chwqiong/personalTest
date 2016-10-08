using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Bluetooth;

public class StartBleButton : Button {
	void Start () {
		BleHandler.Instance.BleScan ();
	}

	public override void OnPointerClick (UnityEngine.EventSystems.PointerEventData eventData)
	{
		BleHandler.Instance.BleScan ();
		base.OnPointerClick (eventData);
	}
}

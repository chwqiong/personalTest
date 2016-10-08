using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

using Bluetooth;
using Bluetooth.Controller;
using Bluetooth.Model;

public class UpButton : Button {


    public override void OnPointerClick(PointerEventData eventData)
    {
        BleController bc = BleController.Instance;
		Dictionary<string, int> dict = new Dictionary<string, int> ();
		dict [BLE.KEY_MOVE_SPEED_L] = 90;
		dict [BLE.KEY_MOVE_SPEED_R] = 90;
		dict [BLE.KEY_MOVE_TIME] = 0x04ff;
		bc.Transfer(BleModelType.BLE_MOVE, dict);
        base.OnPointerClick(eventData);
    }
}

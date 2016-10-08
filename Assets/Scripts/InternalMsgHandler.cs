using UnityEngine;
using System.Collections;

public class InternalMsgHandler : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject maskPanel;

    private bool bleActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
  		{
            Application.Quit();
        }
    }

    void GetBleStatus(string status)
    {
        if (status == "true")
        {
            setActive(true);
        }
        else if (status == "false")
        {
            setActive(false);
        }
    }

    private void setActive(bool active)
    {
        if (active == bleActive) return;
        bleActive = active;
        mainPanel.SetActive(active);
        maskPanel.SetActive(!active);
    }
}

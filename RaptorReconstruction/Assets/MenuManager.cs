using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {


    public GameObject RightRadialPanel;
    public GameObject LeftRadialPanel;
    public GameObject FactsMenu;
    public GameObject LayersMenu;
    public GameObject PauseMenu;

    public void RIghtRadialMenuToggle()
    {
        if (RightRadialPanel.activeSelf || LeftRadialPanel.activeSelf)
        {
            RightRadialPanel.SetActive(false);
            LeftRadialPanel.SetActive(false);
        }
        else
        {
            RightRadialPanel.SetActive(true);
        }
    }

    public void LeftRadialMenuToggle()
    {
        if (RightRadialPanel.activeSelf || LeftRadialPanel.activeSelf)
        {
            RightRadialPanel.SetActive(false);
            LeftRadialPanel.SetActive(false);
        }
        else
        {
            LeftRadialPanel.SetActive(true);
        }
    }


}

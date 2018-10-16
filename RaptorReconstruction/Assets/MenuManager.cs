using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {


    public GameObject RightRadialPanel;
    public GameObject LeftRadialPanel;
    public GameObject FactsMenu;
    public GameObject LayersMenu;
    public GameObject PauseMenu;
    public GameObject LeftToolTips;
    public GameObject RIghtToolTips;
    public GameObject LeftJakesRadial, RightJakesRadial;

    public void RIghtRadialMenuToggle()
    {
        if (RightRadialPanel.activeSelf || LeftRadialPanel.activeSelf)
        {
            RightRadialPanel.SetActive(false);
            LeftRadialPanel.SetActive(false);
            RightJakesRadial.SetActive(false);
            LeftJakesRadial.SetActive(false);

            RIghtToolTips.SetActive(true);
            LeftToolTips.SetActive(true);
        }
        else
        {
            RightRadialPanel.SetActive(true);

            RightJakesRadial.SetActive(true);
            LeftJakesRadial.SetActive(true);

            RIghtToolTips.SetActive(false);  //tooltips off when radialmenu is active
            LeftToolTips.SetActive(false);

        }
    }

    public void LeftRadialMenuToggle()
    {
        if (RightRadialPanel.activeSelf || LeftRadialPanel.activeSelf)
        {
            RightRadialPanel.SetActive(false);
            LeftRadialPanel.SetActive(false);
            RightJakesRadial.SetActive(false);
            LeftJakesRadial.SetActive(false);

            RIghtToolTips.SetActive(true);
            LeftToolTips.SetActive(true);
        }
        else
        {
            LeftRadialPanel.SetActive(true);

            RightJakesRadial.SetActive(true);
            LeftJakesRadial.SetActive(true);

            RIghtToolTips.SetActive(false);
            LeftToolTips.SetActive(false);
        }
    }


}

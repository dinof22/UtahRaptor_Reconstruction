using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MenuManager : MonoBehaviour {


    public GameObject RightRadialPanel;
    public GameObject LeftRadialPanel;
    public GameObject FactsMenu;
    public GameObject LayersMenu;
    public GameObject PauseMenu;
    public GameObject LeftToolTips;
    public GameObject RIghtToolTips;
    public GameObject LeftJakesRadial, RightJakesRadial;

    public Transform headsetPosition;
    public GameObject UIMenu;

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

    public void resetMenuPosition()
    {
        Transform playArea = VRTK_DeviceFinder.PlayAreaTransform();
        Transform headset = VRTK_DeviceFinder.HeadsetTransform();
        if (playArea != null && headset != null)
        {
            transform.position = new Vector3(headset.position.x, playArea.position.y, headset.position.z);
            UIMenu.transform.localPosition = headset.forward * -0.5f;
            UIMenu.transform.localPosition = new Vector3(UIMenu.transform.localPosition.x, 0f, UIMenu.transform.localPosition.z);
            Vector3 targetPosition = headset.position;
            targetPosition.y = playArea.transform.position.y;
            UIMenu.transform.LookAt(targetPosition);
            UIMenu.transform.localEulerAngles = new Vector3(0f, UIMenu.transform.localEulerAngles.y, 0f);
        }
    }

}

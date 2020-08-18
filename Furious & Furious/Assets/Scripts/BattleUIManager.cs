using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{

    public Text driverName;

    public Image totalHP;
    public Image frontWheelHPImage;
    public Image backWheelHPImage;

    public Sprite Life20Tiles00, Life20Tiles01, Life20Tiles02, Life20Tiles03, Life20Tiles04, Life20Tiles05;
    public Sprite Life20Tiles06, Life20Tiles07, Life20Tiles08, Life20Tiles09, Life20Tiles10;
    public Sprite Life20Tiles11, Life20Tiles12, Life20Tiles13, Life20Tiles14, Life20Tiles15;
    public Sprite Life20Tiles16, Life20Tiles17, Life20Tiles18, Life20Tiles19, Life20Tiles20;

    public Sprite Life9Tiles00, Life9Tiles01, Life9Tiles02, Life9Tiles03, Life9Tiles04, Life9Tiles05;
    public Sprite Life9Tiles06, Life9Tiles07, Life9Tiles08, Life9Tiles09;

    public Sprite Life4Tiles00, Life4Tiles01, Life4Tiles02, Life4Tiles03, Life4Tiles04;

    public void SetTotalHP(CarUnit carUnit)
    {

        if (carUnit.carHP == 20)
        {
            if (carUnit.carCurrentHP < 0)
            {
                carUnit.carCurrentHP = 0;
            }
            else if (carUnit.carCurrentHP > 20)
            {
                carUnit.carCurrentHP = 20;
            }
            
            switch (carUnit.carCurrentHP)
                {
                    case 20:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles00;
                        break;
                    case 19:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles01;
                        break;
                    case 18:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles02;
                        break;
                    case 17:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles03;
                        break;
                    case 16:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles04;
                        break;
                    case 15:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles05;
                        break;
                    case 14:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles06;
                        break;
                    case 13:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles07;
                        break;
                    case 12:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles08;
                        break;
                    case 11:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles09;
                        break;
                    case 10:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles10;
                        break;
                    case 9:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles11;
                        break;
                    case 8:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles12;
                        break;
                    case 7:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles13;
                        break;
                    case 6:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles14;
                        break;
                    case 5:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles15;
                        break;
                    case 4:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles16;
                        break;
                    case 3:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles17;
                        break;
                    case 2:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles18;
                        break;
                    case 1:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles19;
                        break;
                    case 0:
                        totalHP.GetComponent<Image>().sprite = Life20Tiles20;
                        break;

            }
            

        }
        else if (carUnit.carHP == 9)
        {

            if (carUnit.carCurrentHP < 0)
            {
                carUnit.carCurrentHP = 0;
            }
            else if (carUnit.carCurrentHP > 9)
            {
                carUnit.carCurrentHP = 9;
            }
                switch (carUnit.carCurrentHP)
                {
                    case 9:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles00;
                        break;
                    case 8:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles01;
                        break;
                    case 7:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles02;
                        break;
                    case 6:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles03;
                        break;
                    case 5:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles04;
                        break;
                    case 4:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles05;
                        break;
                    case 3:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles06;
                        break;
                    case 2:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles07;
                        break;
                    case 1:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles08;
                        break;
                    case 0:
                        totalHP.GetComponent<Image>().sprite = Life9Tiles09;
                        break;
                }
        }
        else
        {
            return;
        }
    }

    public void SetFrontWheelHP (CarUnit carUnit)
    {
        if (carUnit.frontWheelCurrentHP < 0)
        {
            carUnit.frontWheelHP = 0;
        } else if (carUnit.frontWheelCurrentHP > 4)
        {
            carUnit.frontWheelHP = 4;
        }
            switch (carUnit.frontWheelCurrentHP)
            {
                case 4:
                    frontWheelHPImage.GetComponent<Image>().sprite = Life4Tiles00;
                    break;
                case 3:
                    frontWheelHPImage.GetComponent<Image>().sprite = Life4Tiles01;
                    break;
                case 2:
                    frontWheelHPImage.GetComponent<Image>().sprite = Life4Tiles02;
                    break;
                case 1:
                    frontWheelHPImage.GetComponent<Image>().sprite = Life4Tiles03;
                    break;
                case 0:
                    frontWheelHPImage.GetComponent<Image>().sprite = Life4Tiles04;
                    break;

            }
                   
    }

    public void SetBackWheelHP (CarUnit carUnit)
    {
        if (carUnit.backWheelCurrentHP < 0)
        {
            carUnit.backWheelHP = 0;
        }
        else if (carUnit.frontWheelCurrentHP > 4)
        {
            carUnit.backWheelHP = 4;
        }
            switch (carUnit.backWheelCurrentHP)
            {
                case 4:
                    backWheelHPImage.GetComponent<Image>().sprite = Life4Tiles00;
                    break;
                case 3:
                    backWheelHPImage.GetComponent<Image>().sprite = Life4Tiles01;
                    break;
                case 2:
                    backWheelHPImage.GetComponent<Image>().sprite = Life4Tiles02;
                    break;
                case 1:
                    backWheelHPImage.GetComponent<Image>().sprite = Life4Tiles03;
                    break;
                case 0:
                    backWheelHPImage.GetComponent<Image>().sprite = Life4Tiles04;
                    break;

            }
    }


}

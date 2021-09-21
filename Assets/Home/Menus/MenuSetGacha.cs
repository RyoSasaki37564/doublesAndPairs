using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSetGacha : MonoBehaviour
{
    public void MenuToGacha()
    {
        MenuManager.menu = MenuManager.HomeMenu.Gacha;
    }
}

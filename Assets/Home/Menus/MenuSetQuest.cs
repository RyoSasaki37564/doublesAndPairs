using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSetQuest : MonoBehaviour
{
    public void MenuToQuest()
    {
        MenuManager.menu = MenuManager.HomeMenu.Quest;
    }
}

using UnityEngine;

public class MenuScript : MonoBehaviour
{
    //Create an array of Menus
    public Menu[] menus;

    public void Start()
    {
       
        //Close all menus that are open
        foreach (var menu in menus)
        {
            menu.Close();
        }
        //Open start menu 
        menus[0].Open();
    }

    public void OpenMenu(Menu _menu)
    {
        //Close all menu that are open
        CloseMenu();
        //Open the specific menu that we want
        _menu.Open();
    }

    //Close all menus
    public void CloseMenu()
    {
        foreach(var menu in menus)
        {
            menu.Close();
        }
    }
}

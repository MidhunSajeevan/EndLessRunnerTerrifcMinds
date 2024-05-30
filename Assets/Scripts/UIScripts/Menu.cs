using UnityEngine;

public class Menu : MonoBehaviour
{
    public string MenuName;
    public bool IsOpen;

    public void Open()
    {
        //Activate Menu game object
        this.gameObject.SetActive(true);
        IsOpen = true;
    }

    public void Close()
    {
        //Deactivate Menu game object
        this.gameObject.SetActive(false);
        IsOpen = false;
    }
}

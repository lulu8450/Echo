using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public GameObject menu;

    public void ToggleMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }
}
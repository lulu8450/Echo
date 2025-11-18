using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{

    public GameObject settingPanel;

    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnSettingClick()
    {
        settingPanel.SetActive(true);
    }

    public void OnCloseSettingClick()
    {
               settingPanel.SetActive(false);
    }

    public void OnLinkClick()
    {
        Application.OpenURL("https://www.avh.asso.fr/nos-solutions/accueillir-informer-conseiller/sante-des-yeux/cest-quoi-etre-malvoyant");
    }

    public void OnExitClick()
    {

#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
        Debug.Log("Quit Application");
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class shelfLast : MonoBehaviour , IInteractable
{
    public GameObject player;
    public AudioClip dialogue1;
    public AudioClip dialogue2;

    public void OnInteract()
    {
        Debug.Log("interact with Shelf");
        StartCoroutine(finnishDialogue());
        
    }
    IEnumerator finnishDialogue()
    {
        player.GetComponent<AudioSource>().PlayOneShot(dialogue1);
        yield return new WaitForSeconds(dialogue1.length);
        player.GetComponent<AudioSource>().PlayOneShot(dialogue2);
        yield return new WaitForSeconds(dialogue2.length);
        SceneManager.LoadScene("MenuPrincipal");
    }
}

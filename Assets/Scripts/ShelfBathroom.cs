using System.Collections;
using UnityEngine;

public class shelfBathroom : MonoBehaviour , IInteractable
{
    public GameObject player;
    public GameObject leaveDoor;
    public AudioClip medocs1;
    public AudioClip medocs2;
    public AudioClip medocsGood;

    public void OnInteract()
    {
        Debug.Log("interact with Shelf");
        StartCoroutine(medocTime());
        
    }
    IEnumerator medocTime()
    {
        player.GetComponent<AudioSource>().PlayOneShot(medocs1);
        yield return new WaitForSeconds(medocs1.length);
        player.GetComponent<AudioSource>().PlayOneShot(medocs2);
        yield return new WaitForSeconds(medocs2.length);
        player.GetComponent<AudioSource>().PlayOneShot(medocsGood);
        yield return new WaitForSeconds(medocsGood.length);
        leaveDoor.GetComponent<changeRoom>().medocRappel = false;
    }
}

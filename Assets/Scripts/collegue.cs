using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collegue : MonoBehaviour
{
    public List<AudioClip> clipList = new List<AudioClip>();
    public GameObject player;
    public GameObject ui;
    
    void Start()
    {
        StartCoroutine(startDialogue());
    }
    IEnumerator startDialogue()
    {
        gameObject.GetComponent<lunetteDeSoleil>().SetVisibility(true);
        player.GetComponent<CapsuleCollider2D>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        ui.SetActive(false);
        int index = 0;
        while (index < clipList.Count)
        {
            player.GetComponent<AudioSource>().PlayOneShot(clipList[index]);
            yield return new WaitForSeconds(clipList[index].length);
        }
        gameObject.GetComponent<lunetteDeSoleil>().SetVisibility(false);
        player.GetComponent<CapsuleCollider2D>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        ui.SetActive(true);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeRoom : MonoBehaviour
{
    public Transform spawnpoint;
    public Camera cam;
    public int camPos;
    public bool changeCamRoom;
    public bool medocRappel;
    public bool isExit;
    public AudioClip audioClip;
    public AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isExit && !medocRappel)
        {
            collision.transform.position = spawnpoint.position;
            if(changeCamRoom)
            {
                cam.transform.position = new Vector3(0,camPos,0);
            }
        }
        if(collision.CompareTag("Player") && isExit)
        {
            Debug.Log("tu quitte la zone");
            StartCoroutine(goToWork());
            SceneManager.LoadScene("Office");
        }
        if (collision.CompareTag("Player") && medocRappel)
        {
            Debug.Log("tu dois prendre tes medicaments");
            audioSource.PlayOneShot(audioClip);
        }
    }
    IEnumerator goToWork()
    {
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(audioClip.length);
    }
}

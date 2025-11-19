using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour , IInteractable
{
    Animator animator;
    AudioSource audioSource;
    public GameObject ui;
    public GameObject player;
    public AudioSource playerAudioSource;
    public AudioClip reveil1;
    public AudioClip reveil2;
    public AudioClip reveil3;
    public PlayerController playerController;


    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerController.GetComponent<CapsuleCollider2D>().enabled = false;
        playerController.enabled = false;
        ui.SetActive(false);
        StartCoroutine(clockAlarm());   
    }
    IEnumerator clockAlarm()
    {
        yield return new WaitForSeconds(5.0f);
        gameObject.GetComponent<lunetteDeSoleil>().SetVisibility(true);
        animator.Play("Shake");
        audioSource.Play();
        playerAudioSource.PlayOneShot(reveil1);
        yield return new WaitForSeconds(reveil1.length);
        player.transform.position = new Vector3(-6, 14, 0);
        playerAudioSource.PlayOneShot(reveil2);
        yield return new WaitForSeconds(reveil2.length);
        playerAudioSource.PlayOneShot(reveil3);
        yield return new WaitForSeconds(reveil3.length);
        playerController.GetComponent<CapsuleCollider2D>().enabled = true;
        playerController.enabled = true;
        ui.SetActive(true);
    }

    public void OnInteract()
    {
        Debug.Log("interact with clock");
        gameObject.GetComponent<lunetteDeSoleil>().SetVisibility(false);
        animator.Play("Idle");
        audioSource.Stop();
    }
}

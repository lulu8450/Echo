using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour , IInteractable
{
    Animator animator;
    AudioSource audioSource;
    public GameObject ui;
    public Transform player;
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
        yield return new WaitForSeconds(2.0f);
        player.position = new Vector3(-6, 14, 0);
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

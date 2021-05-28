using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDeath : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;

    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    public Collider boxCollider;

    public Camera cam1;
    public GameObject cam2;

    public GameObject HUD;
    public GameObject HUDscore;

    public int goalValue = 100;

    public GameObject player;
    public int playerScore;
    private int increase = 1;

    public int timeTillAccel;
    public int intervalBetweenAccel;

    private void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();

        ToggleRagdollOff();
        boxCollider.enabled = true;

        cam1.enabled = true;
        cam2.SetActive(false);

        HUDscore.SetActive(true);

        InvokeRepeating("AddScore", timeTillAccel, intervalBetweenAccel);
    }

    private void AddScore()
    {
        playerScore += increase;
    }


    private void Die()
    {
        GameObject movement = GameObject.FindWithTag("Player");
        movement.GetComponent<Movement>().enabled = false;
        GameObject horizMovement = GameObject.FindWithTag("Player");
        horizMovement.GetComponent<PlayerMovement>().enabled = false;
        ToggleRagdollOn();
        CancelInvoke();

        HUDscore.SetActive(false);
        HUD.SetActive(true);
        cam2.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            playerScore = playerScore + goalValue;
            Destroy(other.gameObject);
        }
    }

    private void ToggleRagdollOff()
    {
        animator.enabled = true;

        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = true;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = false;
        }
    }


    private void ToggleRagdollOn()
    {
        animator.enabled = false;

        foreach(Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = false;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }
    }
}

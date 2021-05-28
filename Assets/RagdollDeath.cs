using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDeath : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;

    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    public Collider gameObject;

    public Camera cam1;
    public GameObject cam2;

    private void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();

        ToggleRagdollOff();
        gameObject.enabled = true;

        cam1.enabled = true;
        cam2.SetActive(false);
    }
    private void Die()
    {
        GameObject movement = GameObject.FindWithTag("Player");
        movement.GetComponent<Movement>().enabled = false;
        GameObject horizMovement = GameObject.FindWithTag("Player");
        horizMovement.GetComponent<PlayerMovement>().enabled = false;
        ToggleRagdollOn();

        cam2.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Die();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attractor : MonoBehaviour
{
    //[SerializeField] GameObject sphere;
    const float pi = Mathf.PI;
    const float G = 0.1f;
    public static List<Rigidbody> Attractors;
    public Rigidbody rb;
    public bool canAttract;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        canAttract = true;
    }

    private void FixedUpdate()
    {
        rb.AddTorque(10, 10, 10);

        foreach (Rigidbody attractor in Attractors)
        {
            if (attractor != this && attractor.gameObject.transform.parent!=this)
            {
                Attract(attractor);
            }
        }
    }

    private void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<Rigidbody>();
        }
        Attractors.Add(this.GetComponent<Rigidbody>());


    }

    private void OnDisable()
    {
        Attractors.Remove(this.GetComponent<Rigidbody>());
    }

    void Attract(Rigidbody rbToAttract)
    {

        if (canAttract)
        {
            Vector3 direction = rb.position - rbToAttract.position;
            float distance = direction.magnitude;

            if (distance == 0) { return; }

            float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
            Vector3 force = direction.normalized * forceMagnitude;

            rbToAttract.AddForce(force);
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Neutrone"))
        {
            canAttract = false;
            this.transform.parent = collision.transform;
        }
    }
}


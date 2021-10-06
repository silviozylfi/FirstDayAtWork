using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutroneRotation : MonoBehaviour
{
    Vector3 rotationAmount = new Vector3(3, 3, 3);
    private void FixedUpdate()
    {
        this.transform.Rotate(rotationAmount * Time.deltaTime);
    }
}

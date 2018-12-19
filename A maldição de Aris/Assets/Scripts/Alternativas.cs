using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alternativas : MonoBehaviour
{

    private Transform erika_archer;
    private Material mat;
    private float brilho = 0.0f;

    // Use this for initialization
    void Start()
    {
        erika_archer = GameObject.FindWithTag("Player").transform;
        mat = GetComponent<Renderer>().materials[0];
        Debug.Log("Olha a Erica " + erika_archer.name);
        Debug.Log("Olha o material " + mat.name);
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, (erika_archer.position - transform.position).normalized);
        RaycastHit raycastHit;
        if (Physics.Raycast(r, out raycastHit, 10.0f))
        {
            if (raycastHit.collider.gameObject.tag == "Player")
            {
                Debug.DrawLine(r.origin, raycastHit.point);
                brilho = 1.0f;
            }
        }
        else
        {
            brilho = 0.0f;
        }
        Color col = new Color(brilho, brilho, brilho, 1.0f);
        mat.SetColor("_EmissionColor", col);
    }
}

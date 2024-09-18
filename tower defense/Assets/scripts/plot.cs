using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot : MonoBehaviour
{
    [Header("references")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    void Start()
    {
        startColor = sr.color;
    }


    private void OnMousesEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMousesExit()
    {
        sr.color = startColor;
    }

    private void OnMousesDown()
    {
        Debug.Log("build tower here: " + name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

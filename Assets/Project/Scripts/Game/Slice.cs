using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    public GameObject bladeTrailerPrefab;
    bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    GameObject currentBladeTrailer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        } 

        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }

    }

    void UpdateCut()
    {
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void StartCutting()
    {
        isCutting = true;
        currentBladeTrailer = Instantiate(bladeTrailerPrefab, transform);
        circleCollider.enabled = true;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrailer.transform.SetParent(null);
        Destroy(currentBladeTrailer, 2f);
        circleCollider.enabled = false;
    }
}

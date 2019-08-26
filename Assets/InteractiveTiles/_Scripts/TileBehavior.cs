using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{

    public TextMeshProUGUI tex1;
    public static TextMeshProUGUI text;
    public TextMeshProUGUI tex2;
    public static TextMeshProUGUI complete;

    public Material[] material;
    private int matNo = 1;

    private GameObject LastObject;
    private Material LastMaterial;
    private string lastMatName;

    public static int TotalTiles = 4;
    public static int TotalComplete;

    public LayerMask layerMask;

    private void Awake()
    {
        text = tex1;
        complete = tex2;
    }

    private void Update()
    {
        if (TotalComplete >= TotalTiles)
        {
            complete.enabled = true;
        }
        else
        {
            complete.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (LastObject != null)
            {
                LastObject.GetComponent<Renderer>().material = LastMaterial;
                LastObject = null;
                matNo = 1;
            }
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.gameObject != LastObject)
            {
                LastObject = hit.collider.gameObject;
                LastMaterial = hit.collider.GetComponent<Renderer>().material;
                lastMatName = hit.collider.GetComponent<Renderer>().material.name;
            }
            hit.collider.GetComponent<Renderer>().material = material[matNo];
            if (lastMatName == "TileYellow (Instance)")
            {
                matNo = 2;
                hit.collider.GetComponent<Renderer>().material = material[matNo];
                LastMaterial = hit.collider.GetComponent<Renderer>().material;
            }
            else if (lastMatName == "TileRed (Instance)")
            {
                matNo = 0;
                hit.collider.GetComponent<Renderer>().material = material[matNo];
                LastMaterial = hit.collider.GetComponent<Renderer>().material;
            }
        }
    }
}

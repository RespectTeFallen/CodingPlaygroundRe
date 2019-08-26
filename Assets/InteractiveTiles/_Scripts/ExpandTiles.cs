using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandTiles : MonoBehaviour
{

    public Camera cam;

    public GameObject BaseTile;

    private int size = 5;
    private int expandCount = 2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Expand();
        }
    }

    // Update is called once per frame
    void Expand()
    {
        for (int i = 0; i < size; i++)
        {
            Vector3 pointPos = new Vector3(5 * expandCount, 0, 5 * i);
            if (i > size / 2)
            {
                int x = 5 * (i - (Mathf.RoundToInt(size / 2) + 1));
                pointPos = new Vector3(x, 0, 5 * expandCount);
            }
            Instantiate(BaseTile, pointPos, Quaternion.identity);
        }
        Vector3 camPos = new Vector3(2.5f * expandCount, 4.5f * (expandCount + 1), 2.5f * expandCount);
        cam.transform.position = camPos;
        size += 2;
        expandCount += 1;
        TileBehavior.TotalTiles = (Mathf.RoundToInt(size / 2) * Mathf.RoundToInt(size / 2));
    }
}

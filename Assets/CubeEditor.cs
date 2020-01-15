using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float gridSize = 10f;
    TextMesh textMesh;
    void Start()
    {

        textMesh = GetComponentInChildren<TextMesh>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 snap;
        snap.x = Mathf.RoundToInt(transform.position.x /gridSize) * gridSize;
        snap.z = Mathf.RoundToInt(transform.position.z /gridSize) * gridSize;
        textMesh.text = snap.x + "," + snap.z;
        transform.position = new Vector3(snap.x, 0f, snap.z);
        
    }
}

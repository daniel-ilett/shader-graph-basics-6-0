using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class WorldScanner : MonoBehaviour
{
    public float scanSpeed;
    public Terrain terrain;

    private Material terrainMaterial;
    private float scanDistance;

    private void Start()
    {
        terrainMaterial = terrain.materialTemplate;
        scanDistance = 1000.0f;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            
            if(Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out RaycastHit hitInfo))
            {
                terrainMaterial.SetVector("_ScanOrigin", hitInfo.point);
                scanDistance = 0.0f;
            }
        }

        scanDistance += Time.deltaTime * scanSpeed;
        terrainMaterial.SetFloat("_ScanDistance", scanDistance);
    }
}

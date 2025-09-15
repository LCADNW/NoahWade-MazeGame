using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material mat;
    [SerializeField] List<Transform> cols = new List<Transform>();
    [SerializeField] bool colsEmpty { get => (cols.Count == 0) ? true : false; }
    float pos = 0f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mat = meshRenderer.material;
    }

    private void FixedUpdate()
    {
        if (!colsEmpty)
        {
            Vector3 currMatPos = mat.GetVector("_Pos");
            mat.SetVector("_Pos", currMatPos + new Vector3(0f, pos, 0f));
            if (pos !> 50f) 
                pos += 0.0028f;
        }

        if (colsEmpty) return;
        if (cols[cols.Count - 1] == null) return;
        mat.SetVector("_Pos", cols[cols.Count - 1].position);

    }

    private void OnTriggerEnter(Collider other)
    {
        cols.Add(other.transform);
        pos = 0f;
    }

    private void OnTriggerExit(Collider other)
    {
        cols.Remove(other.transform);
    }
}

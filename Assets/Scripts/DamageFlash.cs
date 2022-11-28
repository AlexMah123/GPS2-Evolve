using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public MeshRenderer[] meshRenderers;
    public List<Color> meshColor = new();

    public float flashDuration = 0.2f;

    void Start()
    {
        InitMeshRenderers();
    }

    void InitMeshRenderers()
    {
        meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer mesh in meshRenderers)
        {
            meshColor.Add(mesh.material.color);
        }

    }

    public IEnumerator Flash()
    {
        for(int i=0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = new Color(0.98f, 0.5f, 0.44f);
        }

        yield return new WaitForSeconds(flashDuration);

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = meshColor[i];
        }
    }
}

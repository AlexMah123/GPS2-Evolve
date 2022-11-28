using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlashEnemy : MonoBehaviour
{
    public SkinnedMeshRenderer[] meshRenderers;
    public List<Color> meshColor = new();

    public float flashDuration = 0.2f;

    void Start()
    {
        InitMeshRenderers();
    }

    void InitMeshRenderers()
    {
        meshRenderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (SkinnedMeshRenderer mesh in meshRenderers)
        {
            meshColor.Add(mesh.material.color);
        }

    }

    public IEnumerator Flash()
    {
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = Color.red;
        }

        yield return new WaitForSeconds(flashDuration);

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = meshColor[i];
        }
    }
}

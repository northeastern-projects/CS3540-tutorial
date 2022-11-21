using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    public float chance = 0.2f;

    private Renderer holoRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        holoRenderer = GetComponent<Renderer>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            float test = Random.Range(0.0f, 1.0f);

            if (test < chance)
            {
                StartCoroutine(DoGlitch());
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    IEnumerator DoGlitch()
    {
        holoRenderer.material.SetFloat("_Amount", 1f);
        holoRenderer.material.SetFloat("_Cutoff", 0.03f);
        holoRenderer.material.SetFloat("_Amplitude", Random.Range(50, 100));
        holoRenderer.material.SetFloat("_Speed", Random.Range(1, 10));
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        holoRenderer.material.SetFloat("_Amount", 0f);
        holoRenderer.material.SetFloat("_Cutoff", 0f);
    }
}

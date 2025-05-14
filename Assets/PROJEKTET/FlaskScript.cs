using UnityEngine;

public class FlaskScript : MonoBehaviour
{
    public Material NewSaltMaterial;
    public Material TransparentMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Salt1") || other.CompareTag("Salt2") || other.CompareTag("Salt3") || other.CompareTag("Salt4"))
        {
            Debug.Log("Salt detected!");
            
            // Find the "Salt" child object
            Transform saltTransform = other.transform.Find("SaltetISkålen");
            if (saltTransform != null)
            {
                Renderer saltRenderer = saltTransform.GetComponent<Renderer>();
                if (saltRenderer != null)
                {
                    if (saltRenderer.sharedMaterial != TransparentMaterial)
                    {
                        saltRenderer.material = NewSaltMaterial;
                        Debug.Log("Salt material changed!");
                    }
                }
            }
        }
    }
}
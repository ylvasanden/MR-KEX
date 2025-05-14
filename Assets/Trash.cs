using UnityEngine;

public class Trash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Material TransparentSaltMaterial;
    public Material SaltMaterial;
    public Material MetanolMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrashCan"))
        {
            Transform saltTransform = this.transform.Find("SaltetISkålen");
            if (saltTransform != null)
            {
                Renderer saltRenderer = saltTransform.GetComponent<Renderer>();
                if (saltRenderer != null)
                {
                    if (saltRenderer.sharedMaterial == SaltMaterial)
                    {
                        saltRenderer.sharedMaterial = TransparentSaltMaterial;
                        Transform avfallTransform = other.transform.Find("AvfallSalt");
                        if (avfallTransform != null)
                        {
                            Renderer avfallRenderer = avfallTransform.GetComponent<Renderer>();
                            if (avfallRenderer != null)
                            {
                                avfallRenderer.sharedMaterial = SaltMaterial;

                            }
                        }
                    }
                }
            }
        }
    }
}

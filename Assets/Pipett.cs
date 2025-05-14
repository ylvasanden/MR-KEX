using UnityEngine;

public class Pipett : MonoBehaviour
{
    private bool hasMethanol = false;

    public Material pipetteMethanol;   // Material when methanol is present
    public Material defaultMaterial;   // Material when pipette is empty

    public Material SaltMaterial;      // Original salt material
    public Material MethanolMaterial;  // Salt+Methanol material

    private Renderer pipetteRenderer;

    public Material TransparentSaltMaterial;

    private void Start()
    {
        pipetteRenderer = GetComponent<Renderer>();
        if (pipetteRenderer != null)
        {
            Material[] materials = pipetteRenderer.materials;
            materials[1] = defaultMaterial; // Only change the first material
            pipetteRenderer.materials = materials;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Picking up methanol
        if (other.CompareTag("Methanol") && !hasMethanol)
        {
            hasMethanol = true;

            if (pipetteRenderer != null)
            {
                Material[] materials = pipetteRenderer.materials;
                materials[1] = pipetteMethanol; // Only change the first material
                pipetteRenderer.materials = materials;
            }

            Debug.Log("Pipette picked up methanol.");
        }

        // Depositing methanol into salt bowls
        if ((other.CompareTag("Salt1") || other.CompareTag("Salt2") ||
             other.CompareTag("Salt3") || other.CompareTag("Salt4")) && hasMethanol)
        {
            Transform saltTransform = other.transform.Find("SaltetISkålen");
            if (saltTransform != null)
            {
                Renderer saltRenderer = saltTransform.GetComponent<Renderer>();
                if (saltRenderer != null && saltRenderer.sharedMaterial == SaltMaterial)
                {
                    // Change salt material
                    saltRenderer.sharedMaterial = MethanolMaterial;

                    // Reset pipette
                    hasMethanol = false;
                    if (pipetteRenderer != null)
                    {
                        Material[] materials = pipetteRenderer.materials;
                        materials[1] = defaultMaterial;
                        pipetteRenderer.materials = materials;
                    }

                    Debug.Log("Transferred methanol to salt. Pipette reset.");
                }
            }
        }


        if (other.CompareTag("TrashCan"))
        {
            Transform avfallTransform = other.transform.Find("AvfallSalt");
            if (avfallTransform != null)
            {
                Renderer avfallRenderer = avfallTransform.GetComponent<Renderer>();
                if (avfallRenderer != null)
                {
                    avfallRenderer.sharedMaterial = TransparentSaltMaterial;
                }
            }
        }
    }
}

using UnityEngine;

public class Spoon : MonoBehaviour
{
    public GameObject spoonSalt1;
    public GameObject spoonSalt2;
    public GameObject spoonSalt3;
    public GameObject spoonSalt4;

    private bool hasSpawnedSalt1 = false;
    private bool hasSpawnedSalt2 = false;
    private bool hasSpawnedSalt3 = false;
    private bool hasSpawnedSalt4 = false;

    private GameObject currentSaltOnSpoon = null;
    public Transform saltSpawnPoint;

    public Material SaltMaterial;
    public Material MetanolMaterial;

    private void OnTriggerEnter(Collider other)
    {

        // Handle picking up salt
        if (other.CompareTag("BägarSalt1"))
        {
            HandleSaltPickup(ref hasSpawnedSalt1, spoonSalt1);
        }
        else if (other.CompareTag("BägarSalt2"))
        {
            HandleSaltPickup(ref hasSpawnedSalt2, spoonSalt2);
        }
        else if (other.CompareTag("BägarSalt3"))
        {
            HandleSaltPickup(ref hasSpawnedSalt3, spoonSalt3);
        }
        else if (other.CompareTag("BägarSalt4"))
        {
            HandleSaltPickup(ref hasSpawnedSalt4, spoonSalt4);
        }

        // Handle depositing salt into a bowl
        if (other.CompareTag("Salt1") || other.CompareTag("Salt2") || other.CompareTag("Salt3") || other.CompareTag("Salt4"))
        {
            if (currentSaltOnSpoon != null)
            {
                Transform saltTransform = other.transform.Find("SaltetISkålen");
                if (saltTransform != null)
                {
                    Renderer saltRenderer = saltTransform.GetComponent<Renderer>();
                    if (saltRenderer != null)
                    {
                        if (saltRenderer.sharedMaterial != MetanolMaterial)
                        {
                            RemoveCurrentSalt();
                            saltRenderer.sharedMaterial = SaltMaterial;
                            Debug.Log("Salt material changed!");
                        }
                    }
                }
            }
        }
    }

    private void HandleSaltPickup(ref bool hasSpawnedSalt, GameObject spoonSaltPrefab)
    {
        if (!hasSpawnedSalt)
        {
            RemoveCurrentSalt(); // Remove the existing salt on the spoon
            currentSaltOnSpoon = Instantiate(spoonSaltPrefab, saltSpawnPoint.position, saltSpawnPoint.rotation);
            currentSaltOnSpoon.transform.SetParent(this.transform);
            hasSpawnedSalt = true;
        }
    }

    private void RemoveCurrentSalt()
    {
        if (currentSaltOnSpoon != null)
        {
            Debug.Log("Removing current salt from the spoon.");
            Destroy(currentSaltOnSpoon);
            currentSaltOnSpoon = null;

            // Reset all state flags
            hasSpawnedSalt1 = false;
            hasSpawnedSalt2 = false;
            hasSpawnedSalt3 = false;
            hasSpawnedSalt4 = false;
        }
    }
}

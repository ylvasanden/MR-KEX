using UnityEngine;

public class LighterSpoon : MonoBehaviour
{
    public GameObject spoonSalt1;
    public GameObject spoonSalt2;
    public GameObject spoonSalt3;
    public GameObject spoonSalt4;

    private void Start()
    {
        Debug.Log("Lighter script initialized on " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject saltInstance = null;
        if (other.CompareTag("B�garSalt1"))
        {
            saltInstance = Instantiate(spoonSalt1, other.transform.position, Quaternion.identity);
            saltInstance.transform.SetParent(this.transform);
        }
        if (other.CompareTag("B�garSalt2"))
        {
            saltInstance = Instantiate(spoonSalt2, other.transform.position, Quaternion.identity);
            saltInstance.transform.SetParent(this.transform);
        }
        if (other.CompareTag("B�garSalt3"))
        {
            saltInstance = Instantiate(spoonSalt3, other.transform.position, Quaternion.identity);
            saltInstance.transform.SetParent(this.transform);
        }
        if (other.CompareTag("B�garSalt4"))
        {
            saltInstance = Instantiate(spoonSalt4, other.transform.position, Quaternion.identity);
            saltInstance.transform.SetParent(this.transform);
        }
    }



}

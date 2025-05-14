using UnityEngine;

public class Lighter : MonoBehaviour
{
    public GameObject RedFire;
    public GameObject OrangeFire;
    public GameObject YellowFire;
    public GameObject GreenFire;

    public GameObject lighterFire;

    public Material newSaltMaterial;
    public Material oldSaltMaterial;

    private Collider salt1Collider, salt2Collider, salt3Collider, salt4Collider;

    private float timerLighter, timer1, timer2, timer3, timer4;
    private GameObject activeFire1, activeFire2, activeFire3, activeFire4;

    public AudioSource fireAudioSource1, fireAudioSource2, fireAudioSource3, fireAudioSource4;

    private void Start()
    {
        Debug.Log("Lighter script initialized on " + gameObject.name);
        if (lighterFire != null)
        {
            lighterFire.SetActive(false);
        }
        if (RedFire != null)
        {
            RedFire.SetActive(false);
        }
        if (OrangeFire != null)
        {
            OrangeFire.SetActive(false);
        }
        if (YellowFire != null)
        {
            YellowFire.SetActive(false);
        }
        if (GreenFire != null)
        {
            GreenFire.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Lighter collided with: " + other.gameObject.name);

        if (!lighterFire.activeSelf && (other.CompareTag("Salt1") || other.CompareTag("Salt2") || other.CompareTag("Salt3") || other.CompareTag("Salt4")))
        {
            lighterFire.SetActive(true);
            timerLighter = 0f;
            Debug.Log("Lighter flame lit.");
        }

        if (IsSaltMaterialChanged(other))
        {
            //GameObject fireInstance = null;

            if (other.CompareTag("Salt1") && !RedFire.activeSelf)
            {
                Transform redFireTransform = other.transform.Find("RedFire");

                if (redFireTransform != null)
                {
                    redFireTransform.gameObject.SetActive(true); // Activate it
                    activeFire1 = redFireTransform.gameObject;   // Track it if needed
                    timer1 = 0f;
                    salt1Collider = other;

                    fireAudioSource1.Play();
                }
            }
            else if (other.CompareTag("Salt2") && !OrangeFire.activeSelf)
            {
                Transform orangeFireTransform = other.transform.Find("OrangeFire");

                if (orangeFireTransform != null)
                {
                    orangeFireTransform.gameObject.SetActive(true); // Activate it
                    activeFire2 = orangeFireTransform.gameObject;   // Track it if needed
                    timer2 = 0f;
                    salt2Collider = other;
                    fireAudioSource2.Play();
                }
            }
            else if (other.CompareTag("Salt3") && !YellowFire.activeSelf)
            {
                Transform yellowFireTransform = other.transform.Find("YellowFire");

                if (yellowFireTransform != null)
                {
                    yellowFireTransform.gameObject.SetActive(true); // Activate it
                    activeFire3 = yellowFireTransform.gameObject;   // Track it if needed
                    timer3 = 0f;
                    salt3Collider = other;
                    fireAudioSource3.Play();
                }
            }
            else if (other.CompareTag("Salt4") && !GreenFire.activeSelf)
            {
                Transform greenFireTransform = other.transform.Find("GreenFire");

                if (greenFireTransform != null)
                {
                    greenFireTransform.gameObject.SetActive(true); // Activate it
                    activeFire4 = greenFireTransform.gameObject;   // Track it if needed
                    timer4 = 0f;
                    salt4Collider = other;
                    fireAudioSource4.Play();
                }
            }
        }
    }

    private void Update()
    {
        if (lighterFire.activeSelf)
        {
            timerLighter += Time.deltaTime;
            if (timerLighter > 3f)
            {
                lighterFire.SetActive(false);
                Debug.Log("Lighter flame destroyed after 3 seconds.");
            }
        }
        if (RedFire.activeSelf)
        {
            timer1 += Time.deltaTime;
            if (timer1 > 10f)
            {
                RedFire.SetActive(false);
                fireAudioSource1.Stop();
                Debug.Log("RedFire removed after 10 seconds.");
                ChangeToOldSalt(salt1Collider);
            }
        }

        if (OrangeFire.activeSelf)
        {
            timer2 += Time.deltaTime;
            if (timer2 > 10f)
            {
                OrangeFire.SetActive(false);
                fireAudioSource2.Stop();
                Debug.Log(" Fire2 removed after 10 seconds.");
                ChangeToOldSalt(salt2Collider);
            }
        }

        if (YellowFire.activeSelf)
        {
            timer3 += Time.deltaTime;
            if (timer3 > 10f)
            {
                YellowFire.SetActive(false);
                fireAudioSource3.Stop();
                Debug.Log("Fire3 removed after 10 seconds.");
                ChangeToOldSalt(salt3Collider);
            }
        }

        if (GreenFire.activeSelf)
        {
            timer4 += Time.deltaTime;
            if (timer4 > 10f)
            {
                GreenFire.SetActive(false);
                fireAudioSource4.Stop();
                Debug.Log("Fire4 removed after 10 seconds.");
                ChangeToOldSalt(salt4Collider);
            }
        }
    }

    private bool IsSaltMaterialChanged(Collider saltObject)
    {
        Transform saltTransform = saltObject.transform.Find("SaltetISkålen");
        if (saltTransform != null)
        {
            Renderer saltRenderer = saltTransform.GetComponent<Renderer>();
            if (saltRenderer != null)
            {
                return saltRenderer.sharedMaterial == newSaltMaterial;
            }
        }
        return false;
    }

    private void ChangeToOldSalt(Collider saltObject)
    {
        Transform saltTransform = saltObject.transform.Find("SaltetISkålen");
        if (saltTransform != null)
        {
            Renderer saltRenderer = saltTransform.GetComponent<Renderer>();
            if (saltRenderer != null)
            {
                saltRenderer.material = oldSaltMaterial;
                Debug.Log(" Salt material changed back to old.");
            }
            else
            {
                Debug.LogWarning("Salt child object has no Renderer.");
            }
        }
        else
        {
            Debug.LogWarning(" Could not find 'SaltetISkalen' in " + saltObject.name);
        }
    }
}

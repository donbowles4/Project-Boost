using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float fltLevelLoadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    AudioSource audioSource;
    bool blnIsTransitioning = false;
    bool blnCollisionDisabled = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        RespondToDebugKeys(); 
    }
    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNext();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            blnCollisionDisabled = !blnCollisionDisabled; //toggle collision
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (blnIsTransitioning  || blnCollisionDisabled){return;}

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this thang friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                Invoke("LoadNext", fltLevelLoadDelay);
                break;
            default:
                StartCrashSequence();
                Invoke("ReloadLevel", fltLevelLoadDelay);
                break;
        }
    }
    void StartSuccessSequence()
    {
        blnIsTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
    }
    void StartCrashSequence()
    {
        blnIsTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
    }
    void LoadNext()
    {
        int intNextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(intNextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            intNextSceneIndex = 0;
        }
        SceneManager.LoadScene(intNextSceneIndex);
    }
    void ReloadLevel()
    {
        int intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(intCurrentSceneIndex);
    }
    
}

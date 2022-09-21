using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float fltLevelLoadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
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
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
    }
    void StartCrashSequence()
    {
        audioSource.PlayOneShot(crash);
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

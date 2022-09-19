using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float fltLevelLoadDelay = 1f;
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this thang friendly");
                break;
            case "Finish":
                StartCrashSequence();
                Invoke("LoadNext", fltLevelLoadDelay);
                break;
            default:
                StartCrashSequence();
                Invoke("ReloadLevel", fltLevelLoadDelay);
                break;
        }
    }

    void StartCrashSequence()
    {
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

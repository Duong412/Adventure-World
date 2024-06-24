using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnSceneChange : MonoBehaviour
{
    // The name of the scene to check
    [SerializeField] private string targetSceneName = "Scren4";

    // Add this object's initialization code if needed
    void Start()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // This method is called when the scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the current scene is the target scene
        if (scene.name == targetSceneName)
        {
            // Destroy this game object
            Destroy(gameObject);
        }
    }

    // Make sure to unsubscribe from the event when this object is destroyed
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

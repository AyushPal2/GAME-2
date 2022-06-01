using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip Crash , Win;
    [SerializeField] ParticleSystem Blast , Success ;
    AudioSource audio;

    bool isTransitioning = false;
    bool collisionDisabled = false;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Nextlevel();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    } 
    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || collisionDisabled){return;}
        switch(other.gameObject.tag)
        {
            case "Respawn":
            Debug.Log("This is friendly");
            break;
            
            case "Obstacle":
            StartCrashSequence();
            break;

            case "Finish":
            EndSequence();
            break;
        }
   
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audio.Stop();
        audio.PlayOneShot(Crash);
        Blast.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("Reloadlevel",delay);

    }
    void EndSequence()
    {
        isTransitioning = true;
        audio.Stop();
        audio.PlayOneShot(Win);
        Success.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("Nextlevel",delay);

    }
    void Reloadlevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void Nextlevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    
}

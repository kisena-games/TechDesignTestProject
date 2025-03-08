using UnityEngine;
using UnityEngine.SceneManagement;

public class Gear : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Vergeet niet TextMeshPro toe te voegen
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;
    public TextMeshProUGUI interactionText; // UI-tekst
    public string sceneA = "OutdoorsScene"; // Eerste scene
    public string sceneB = "Verandering"; // Tweede scene

    private bool canInteract = false;
    private GameObject currentObject;

    void Update()
    {
        CheckForInteractable();

        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            SwitchScene();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            currentObject = hit.collider.gameObject;
            canInteract = true;
            interactionText.text = "Press E to interact";
        }
        else
        {
            canInteract = false;
            interactionText.text = "";
        }
    }

    void SwitchScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == sceneA)
        {
            SceneManager.LoadScene(sceneB);
        }
        else
        {
            SceneManager.LoadScene(sceneA);
        }
    }
}

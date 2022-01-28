using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class BPressKeyToScene : MonoBehaviour
{

    PlayerInput playerInput;
    public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions["PassGem"].performed += Go;
    }

    void Go(InputAction.CallbackContext context)
    {
        playerInput.actions["PassGem"].performed -= Go;
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}

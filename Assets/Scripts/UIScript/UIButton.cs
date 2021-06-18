using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIButton : MonoBehaviour
{


    public void StartMenu()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
       
    }

    public void QuitMenu()
    {
        Application.Quit();

    }

    public void Return()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    //Loads demo scene from main menu
    public void startDemo()
    {
        SceneManager.LoadScene("Demo");
    }
}

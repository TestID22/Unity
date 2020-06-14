using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Работа с сценами в Юнити, 
public class MainMenu : MonoBehaviour
{
    //Запускаем сцену за сценой по очереди, очерёдность в BuilderSettings
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("quiting");
        Application.Quit();
    }
}

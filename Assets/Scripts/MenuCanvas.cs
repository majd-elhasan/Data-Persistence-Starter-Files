using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    public Text playerName ;
    public void StartGame()
    {
        DataHolder.Instance.playerName = playerName.text;
        SceneManager.LoadScene(1);
    }
    
           
}

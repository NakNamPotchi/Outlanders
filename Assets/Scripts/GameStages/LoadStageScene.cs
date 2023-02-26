using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStageScene : MonoBehaviour
{
    public int level;
    
    public void OpenScene()
    {
        SceneManager.LoadScene("Stage" + level.ToString());
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    void Update(){
        if(Input.anyKeyDown){
            LaunchGame();
        }
    }
    public void LaunchGame(){
        SceneManager.LoadScene("Level");
    }
}

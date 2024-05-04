using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DemoUi : MonoBehaviour
{
   [SerializeField]
    private SceneTransitionMode TransitionMode; 

    public void OnGUI()
    {
        if (GUI.Button(new Rect(1000, 10, 200, 30), "Load Battle Scene"))
        {
            SceneTransitioner.Instance.LoadScene("BattleScene", TransitionMode);
        }
        if (GUI.Button(new Rect(1000, 50, 200, 30), "Load Menu Scene"))
        {
            SceneTransitioner.Instance.LoadScene("Menu", TransitionMode);
        }
    }
    public async void ChangBatteleScene()
    {    
        SceneTransitioner.Instance.LoadScene("BattleScene", TransitionMode);
        await Task.Yield();
        Debug.Log("test");
    }
}
public enum SceneTransitionMode
{
    None,
    Fade,
    Circle
}
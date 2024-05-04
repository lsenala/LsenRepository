using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[DisallowMultipleComponent]
[RequireComponent(typeof(Canvas))]
[System.Serializable]
public class Transition
{
    public SceneTransitionMode Mode;
    public AbstractSceneTransitionScriptableObject AnimationSO;
}
public class SceneTransitioner : MonoBehaviour
{
    private static SceneTransitioner _instance;
    public static SceneTransitioner Instance
    {
        get => _instance;
        private set => _instance = value;
    }
    private Canvas TransitionCanvas;
    [SerializeField]
    private List<Transition> Transitions = new();
    private AsyncOperation LoadLevelOperatin;
    private AbstractSceneTransitionScriptableObject ActiveTransition;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning($"Invalid configuation. Duplicate Instances faoud!First one;{Instance.name}");
             Destroy(gameObject);
            return;
        }
        SceneManager.activeSceneChanged += HandleSceneChange;
        Instance = this;
        DontDestroyOnLoad(gameObject);
        TransitionCanvas = GetComponent<Canvas>();
        TransitionCanvas.enabled = false;
    }
    public void LoadScene(string Scene,
        SceneTransitionMode TransitionMode=SceneTransitionMode.None,
        LoadSceneMode Mode=LoadSceneMode.Single)
    {
        LoadLevelOperatin = SceneManager.LoadSceneAsync(Scene, Mode);
        Transition transition = Transitions.Find((transition) => transition.Mode == TransitionMode);
        if (transition != null)
        {
            LoadLevelOperatin.allowSceneActivation = false;
            TransitionCanvas.enabled = true;
            ActiveTransition = transition.AnimationSO;
            StartCoroutine(Exit());
        }
        else
        {
            Debug.LogWarning($"No transition faoud for TransitionMode{TransitionMode}!" +
                $"Maybe you are missing a configuration?");
        }
    }
    private IEnumerator Exit()
    {
        yield return StartCoroutine(ActiveTransition.Exit(TransitionCanvas));
        LoadLevelOperatin.allowSceneActivation = true;
    }
    private IEnumerator Enter()
    {
        yield return StartCoroutine(ActiveTransition.Enter(TransitionCanvas));
        TransitionCanvas.enabled = false;
        LoadLevelOperatin = null;
        ActiveTransition = null;
    }
    private void HandleSceneChange(Scene OldScene, Scene NewScene)
    {
        if (ActiveTransition != null)
        {
            StartCoroutine(Enter());
        }
    }

}

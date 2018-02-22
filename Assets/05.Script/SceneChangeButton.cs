using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum SceneName
{
    LobbyScene,
    GameScene
}

[RequireComponent(typeof(Button))]
public class SceneChangeButton : MonoBehaviour
{
    [SerializeField]
    private SceneName sceneName;

    private void Awake()
    {
        Button button = transform.GetComponent<Button>();
        if (button != null)
            button.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneName);
        System.GC.Collect();
    }

}

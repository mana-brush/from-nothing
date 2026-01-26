using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTeleporter : MonoBehaviour
{

    [SerializeField] private LevelIndex levelIndex;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(levelIndex.ToString());
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(levelIndex.ToString());
    }
}

enum LevelIndex
{
    TitleScene,
    Tutorial,
    LevelTwo,
    LevelThree
}
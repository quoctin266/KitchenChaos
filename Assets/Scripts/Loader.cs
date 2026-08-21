using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene {
        GameScene,
        MainMenuScene,
        LoadingScene
    }

    private static Scene targetScene;

    // Set target scene and load the loading scene
    public static void Load(Scene scene) {
        targetScene = scene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoadTargetScene() {
        SceneManager.LoadScene(targetScene.ToString());
    }
}

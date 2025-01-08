using UnityEngine.SceneManagement;

namespace SceneLoader
{
    public class Loader
    {
        private static Scenes _targetScenes;

        public void Load(Scenes targetScenes)
        {
            _targetScenes = targetScenes;
            SceneManager.LoadScene(Scenes.LoadingScene.ToString());
        }

        public void LoaderCallback()
        {
            SceneManager.LoadScene(_targetScenes.ToString());
        }
    }
}
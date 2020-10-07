using Ali.Helper.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ali.Helper
{
    public class SceneLoader : GenericSingleton<SceneLoader>
    {
        private bool _passingScene;
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneCo(sceneName));
        }
        public IEnumerator LoadSceneCo(string sceneName)
        {
            if (_passingScene)
            {
                yield break;
            }
            _passingScene = true;
            yield return FaderManager.Instance?.CloseTheater();
            SceneManager.LoadScene(sceneName);
            _passingScene = false;
        }
    }
}
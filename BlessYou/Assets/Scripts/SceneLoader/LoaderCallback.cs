using UnityEngine;
using Zenject;

namespace SceneLoader
{
  public class LoaderCallback : MonoBehaviour
  {
    private bool isFirstUpdate = true;
  
    private Loader loader;
      
    [Inject]
    public void Init(Loader loader)
    {
      this.loader = loader;
    }

    private void Update()
    {
      if (!isFirstUpdate) return;
      isFirstUpdate = false;
      loader.LoaderCallback();
    }
  }
}

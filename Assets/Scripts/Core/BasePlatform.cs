public class BasePlatform : IPlatform
{
    public BasePlatform(ISceneManager sceneManager, IBackendManager backendManager) 
    {
        this.BackendManager = backendManager;
        this.SceneManager = sceneManager;
    }

    public ISceneManager SceneManager { get; protected set; }
    public IBackendManager BackendManager { get; protected set; }
}

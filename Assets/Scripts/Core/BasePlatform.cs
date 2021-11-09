public class BasePlatform : IPlatform
{
    public BasePlatform(IBackendManager backendManager) 
    {
        BackendManager = backendManager;
    }

    public IBackendManager BackendManager { get; protected set; }
}

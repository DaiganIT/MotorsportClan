public interface IBackendManager
{
    public AsyncResponse<LoginResponse> Login(LoginRequest loginRequest);
}

using System.Threading.Tasks;

public class FakeBackendManager : IBackendManager
{
    public AsyncResponse<LoginResponse> Login(LoginRequest loginRequest)
    {
        var response = new AsyncResponse<LoginResponse>();
        Task.Run(() => DoLoginAsync(response, loginRequest));
        return response;
    }

    private async Task DoLoginAsync(AsyncResponse<LoginResponse> response, LoginRequest request)
    {
        await Task.Delay(3000);
        response.Complete(new LoginResponse { userId = "daigan", username = "daigan" });
    }
}
public class AuthService
{
    public bool IsAuthenticated { get; private set; }
    public string? Username { get; private set; }

    public bool IsInitialized { get; private set; } = false;

    public event Action? OnChange;

    public async Task<bool> LoginAsync(string username, string password)
    {
  
        if (username == "admin" && password == "1234")
        {
            IsAuthenticated = true;
            Username = username;
            NotifyStateChanged();
            return true;
        }

        IsAuthenticated = false;
        Username = null;
        NotifyStateChanged();
        return false;
    }

    public void Logout()
    {
        IsAuthenticated = false;
        Username = null;
        NotifyStateChanged();
    }

    public UserInfo GetUser()
    {
        return new UserInfo
        {
            IsAuthenticated = IsAuthenticated,
            Username = Username
        };
    }

    public async Task InitializeAsync()
    {
        
        await Task.Delay(1); 

       
        IsInitialized = true;

        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();

    public class UserInfo
    {
        public bool IsAuthenticated { get; set; }
        public string? Username { get; set; }
    }
}

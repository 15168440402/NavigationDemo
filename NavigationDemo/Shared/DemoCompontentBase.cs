using Microsoft.AspNetCore.Components;

namespace NavigationDemo.Shared;

public abstract class DemoCompontentBase : ComponentBase
{
    private GlobalConfig? _globalConfig;

    [Inject]
    public GlobalConfig GlobalConfig
    {
        get
        {
            return _globalConfig ?? throw new Exception("please Inject GlobalConfig!");
        }
        set
        {
            _globalConfig = value;
        }
    }

    public bool Loading
    {
        get => GlobalConfig.Loading;
        set => GlobalConfig.Loading = value;
    }

    public void OpenConfirmDialog(Func<bool, Task> confirmFunc, string messgae)
    {
        var callback = EventCallback.Factory.Create(this, confirmFunc);
        GlobalConfig.OpenConfirmDialog("Operation confirmation", messgae, callback);
    }

    public void OpenErrorDialog(string message)
    {
        GlobalConfig.OpenConfirmDialog("Error", message, default);
    }

    public void OpenWarningDialog(string message)
    {
        GlobalConfig.OpenConfirmDialog("Warning", message, default);
    }

    public void OpenInformationMessage(string message)
    {
        GlobalConfig.OpenMessage(message, MessageTypes.Information);
    }

    public void OpenSuccessMessage(string message)
    {
        GlobalConfig.OpenMessage(message, MessageTypes.Success);
    }

    public void OpenWarningMessage(string message)
    {
        GlobalConfig.OpenMessage(message, MessageTypes.Warning);
    }

    public void OpenErrorMessage(string message)
    {
        GlobalConfig.OpenMessage(message, MessageTypes.Error);
    }
}



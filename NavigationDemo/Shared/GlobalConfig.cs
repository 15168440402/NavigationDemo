using Microsoft.AspNetCore.Components;

namespace NavigationDemo.Shared;

    public class GlobalConfig
    {
        #region Field

        private bool _Loading;

        #endregion

        #region Property
   
        public bool Loading
        {
            get => _Loading;
            set
            {
                if (_Loading != value)
                {
                    _Loading = value;
                    OnLoadingChanged?.Invoke(_Loading);
                }
            }
        }

        public void OpenConfirmDialog(string title, string message, EventCallback<bool> confirmFunc)
        {
            OnConfirmChanged?.Invoke(title, message, confirmFunc);
        }

        public void OpenMessage(string message, MessageTypes messageType, int timeOut = 2)
        {
            OnMessageChanged?.Invoke(message, messageType, timeOut);
        }

        #endregion

        #region event

        public delegate void GlobalConfigChanged();
        public delegate void LoadingChanged(bool Loading);
        public delegate void MessageChanged(string message, MessageTypes messageType, int timeOut);
        public delegate void ConfirmChanged(string title, string message, EventCallback<bool> confirmFunc);

        public event LoadingChanged? OnLoadingChanged;
        public event ConfirmChanged? OnConfirmChanged;
        public event MessageChanged? OnMessageChanged;

        #endregion
    }

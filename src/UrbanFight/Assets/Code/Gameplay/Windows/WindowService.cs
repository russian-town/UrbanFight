using System;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;

namespace Code.Gameplay.Windows
{
    public class WindowService : IWindowService
    {
        private readonly IWindowFactory _windowFactory;
        private readonly List<BaseWindow> _openedWindows = new();

        public WindowService(IWindowFactory windowFactory) =>
            _windowFactory = windowFactory;

        public void Open(WindowId windowId) =>
            _openedWindows.Add(_windowFactory.CreateWindow(windowId));

        public void Close(WindowId windowId)
        {
            BaseWindow window = _openedWindows.Find(x => x.Id == windowId);
            _openedWindows.Remove(window);
            Object.Destroy(window.gameObject);
        }

        public T GetOpenedWindow<T>(WindowId id) where T : BaseWindow
        {
            BaseWindow baseWindow = _openedWindows.First(x => x.Id == id);
            return (T)baseWindow;
        }
    }
}

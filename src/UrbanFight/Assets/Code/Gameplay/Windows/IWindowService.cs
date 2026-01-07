using UnityEngine;

namespace Code.Gameplay.Windows
{
  public interface IWindowService
  {
    void Open(WindowId windowId);
    void Close(WindowId windowId);
    T GetOpenedWindow<T>(WindowId id) where T : BaseWindow;
  }
}
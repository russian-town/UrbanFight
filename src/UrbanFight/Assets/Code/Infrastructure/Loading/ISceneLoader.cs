using System;
using UnityEngine;

namespace Code.Infrastructure.Loading
{
  public interface ISceneLoader
  {
    void LoadScene(string name, Action onLoaded = null);
    void MoveObjectToScene(GameObject gameObject);
  }
}
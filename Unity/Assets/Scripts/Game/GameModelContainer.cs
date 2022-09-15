using Lp2EpocaEspecial.Common;
using UnityEngine;
/// <summary>
/// Contains an Instance of the gamemodel
/// </summary>

[CreateAssetMenu(menuName = "GameModelContainer")]
public class GameModelContainer : ScriptableObject
{
    public GameModel GameModel { get; private set; }
    private void OnEnable()
    {
        GameModel = new GameModel();
    }
}

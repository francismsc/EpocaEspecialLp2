using Lp2EpocaEspecial.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "GameModelContainer")]
public class GameModelContainer : ScriptableObject
{
    public GameModel GameModel { get; private set; }
    private void OnEnable()
    {
        GameModel = new GameModel();
    }
}

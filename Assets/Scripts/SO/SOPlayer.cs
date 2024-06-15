using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Data/Game/Player")]
public class SOPlayer : ScriptableObject
{
    public ModelPlayer[] modelPlayers;
}

[Serializable]

public struct ModelPlayer
{
    public Player prefab;
    public float speed;
    public float jumpForce;
}
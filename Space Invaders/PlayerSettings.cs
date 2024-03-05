using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class PlayerSettings
{
    public float Speed { get; init; }
    public Keyboard.Key MovingLeftButton { get; init; }
    public Keyboard.Key MovingRightButton { get; init; }
    public Keyboard.Key MovingUpButton { get; init; }
    public Keyboard.Key MovingDownButton { get; init; }
    public Keyboard.Key ShootingButton { get; init; }
    public float ShootingCooldown { get; init; }
}
using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class PlayerMovement
{
    private readonly float _speed;
    private readonly Keyboard.Key _leftButton;
    private readonly Keyboard.Key _downButton;
    private readonly Keyboard.Key _upButton;
    private readonly Keyboard.Key _rightButton;

    public PlayerMovement(PlayerSettings playerSettings)
    {
        _speed = playerSettings.Speed;
        _leftButton = playerSettings.MovingLeftButton;
        _downButton = playerSettings.MovingDownButton;
        _upButton = playerSettings.MovingUpButton;
        _rightButton = playerSettings.MovingRightButton;
    }
    
    public Vector2f GetNewPosition(Vector2f position)
    {
        Vector2f movement = new Vector2f();

        if (Keyboard.IsKeyPressed(_leftButton)) movement.X -= 1;
        if (Keyboard.IsKeyPressed(_rightButton)) movement.X += 1;
        if (Keyboard.IsKeyPressed(_upButton)) movement.Y -= 1;
        if (Keyboard.IsKeyPressed(_downButton)) movement.Y += 1;
        
        position += movement.Normalize() * _speed;

        return position;
    }
}
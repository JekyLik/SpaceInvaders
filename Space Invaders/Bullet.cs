using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class Bullet
{
    private readonly float _bulletSpeed;
    private readonly CircleShape _bulletShape;
    public Vector2f Position => _bulletShape.Position;

    public Bullet(Vector2f position, float bulletSpeed, float bulletRadius)
    {
        _bulletSpeed = bulletSpeed;
        _bulletShape = new CircleShape(bulletRadius);
        _bulletShape.FillColor = Color.Red;
        _bulletShape.Position = position;
    }
    
    public void Update()
    {
        var currentPosition = _bulletShape.Position;
        var newPosition = new Vector2f(currentPosition.X, currentPosition.Y - _bulletSpeed);
        _bulletShape.Position = newPosition;
    }
    
    public void Draw(RenderWindow window)
    {
        window.Draw(_bulletShape);
    }
    
    public FloatRect GetGlobalBounds()
    {
        return _bulletShape.GetGlobalBounds();
    }
}
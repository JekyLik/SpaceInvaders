using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class Player
{
    public bool IsPlayerDead { get; private set; }
    private readonly Sprite _sprite;
    private readonly ShootingManager _shootingManager;
    private readonly Keyboard.Key _shootingButton;
    private readonly PlayerMovement _playerMovement;

    public Player(ShootingManager shootingManager, Keyboard.Key shootingButton, Texture texture, Vector2f playerSpawnPosition, PlayerMovement playerMovement)
    {
        _sprite = new Sprite(texture);
        _sprite.Position = playerSpawnPosition;
        _shootingManager = shootingManager;
        _shootingButton = shootingButton;
        _playerMovement = playerMovement;
    }

    public void Draw(RenderWindow window)
    {
        window.Draw(_sprite);
        _shootingManager.Draw(window);
    }
    
    private Vector2f GetBulletSpawnPosition()
    {
        var halfSpriteSizeX = new Vector2f(_sprite.TextureRect.Width / 2f, 0f);
        var bulletSpawnPosition = _sprite.Position + halfSpriteSizeX;
        return bulletSpawnPosition;
    }

    private void Move()
    {
        var newPosition = _playerMovement.GetNewPosition(_sprite.Position);
        _sprite.Position = newPosition;
    }

    public void Update()
    {
        Move();

        if (Keyboard.IsKeyPressed(_shootingButton))
        {
            var bulletSpawnPosition = GetBulletSpawnPosition();
            _shootingManager.TryShoot(bulletSpawnPosition);
        }
        _shootingManager.Update();
    }
    
    public List<Bullet> GetBullets()
    {
        return _shootingManager.Bullets;
    }
    
    public void DestroyBullet(Bullet bullet)
    {
        _shootingManager.Bullets.Remove(bullet);
    }
    
    public FloatRect GetGlobalBounds()
    {
        return _sprite.GetGlobalBounds();
    }
    
    public void Destroy()
    {
        IsPlayerDead = true;
    }
    
}
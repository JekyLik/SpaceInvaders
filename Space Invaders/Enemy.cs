using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class Enemy
{
    private const float DEATH_ANIMATION_TIME= 0.2f;
    
    public Vector2f Position => _sprite.Position;
    private readonly float _enemySpeed;
    private readonly Sprite _sprite;
    private readonly AnimationManager _animationManager;
    
    public Enemy(float enemySpeed, Texture texture, Vector2f spawnPosition, AnimationManager animationManager)
    {
        _enemySpeed = enemySpeed;
        _sprite = new Sprite(texture);
        _sprite.Position = spawnPosition;
        _animationManager = animationManager;
    }
    
    private void Move()
    {
        _sprite.Position += new Vector2f(0, _enemySpeed);
    }
    
    public void Update()
    {
        Move();
    }
    
    public void Draw(RenderWindow window)
    {
        window.Draw(_sprite);
    }
    
    public FloatRect GetGlobalBounds()
    {
        return _sprite.GetGlobalBounds();
    }
    
    public void PlayDeathAnimation()
    {
        var halfSpriteSize = (Vector2f) _sprite.Texture.Size / 2;
        var animationPosition = _sprite.Position - halfSpriteSize;
        var explosionAnimation = new SpriteAnimation(animationPosition, TextureManager.ExplosionAtlas, DEATH_ANIMATION_TIME);
        _animationManager.AddAnimation(explosionAnimation);
    }
}
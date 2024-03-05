using SFML.Graphics;
using SFML.System;

namespace Space_Invaders;

public class SpriteAnimation
{
    public bool IsAnimationFinished { get; private set; }
    private readonly float _animationTime;
    private readonly float _frameDeltaTime;
    private readonly SpriteAtlas _spriteAtlas;
    private readonly Vector2f _spawnPosition;
    private Sprite _sprite;
    private float _currentAnimationTime;
    private int _currentSpriteIndex;
    
    public SpriteAnimation(Vector2f position, SpriteAtlas spriteAtlas, float animationTime)
    {
        _spriteAtlas = spriteAtlas;
        _animationTime = animationTime;
        _spawnPosition = position;
        _frameDeltaTime = _spriteAtlas.Count / animationTime;
    }
    
    public void Update()
    {
        if (_currentAnimationTime < _animationTime)
        {
            _currentAnimationTime += _frameDeltaTime;
            return;
        }

        _sprite = _spriteAtlas.GetSprite(_currentSpriteIndex);
        _sprite.Position = _spawnPosition;

        if (_currentSpriteIndex > _spriteAtlas.Count - 1)
        {
            IsAnimationFinished = true;
            return;
        }

        _currentSpriteIndex++;
        _currentAnimationTime = 0;
    }
    
    public void Draw(RenderWindow window)
    {
        if (_sprite == null)
        {
            return;
        }

        window.Draw(_sprite);
    }
    
}
using SFML.Graphics;

namespace Space_Invaders;

public class AnimationManager
{
    private readonly List<SpriteAnimation> _animations = new();
    
    public void Update()
    {
        for (var i = 0; i < _animations.Count; i++)
        {
            var animation = _animations[i];
            animation.Update();

            if (animation.IsAnimationFinished)
            {
                _animations.RemoveAt(i);
            }
        }
    }
    
    public void Draw(RenderWindow window)
    {
        foreach (var animation in _animations)
        {
            animation.Draw(window);
        }
    }
    
    public void AddAnimation(SpriteAnimation spriteAnimation)
    {
        _animations.Add(spriteAnimation);
    }
}
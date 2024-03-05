using SFML.Graphics;
using SFML.System;

namespace Space_Invaders;

public class ScoreManager
{
    private readonly TextLabel _textLabel;
    private readonly int _scorePerEnemy;
    private int _score;
    
    public ScoreManager(ScoreManagerSettings scoreManagerSettings)
    {
        _scorePerEnemy = scoreManagerSettings.ScorePerEnemy;
        var scoreLabelPosition = new Vector2f(scoreManagerSettings.PositionX, scoreManagerSettings.PositionY);
        _textLabel = new TextLabel($"Score: {_score}", scoreManagerSettings.FontName, scoreManagerSettings.FontSize, scoreManagerSettings.FontColor, scoreLabelPosition);
    }
    
    public void Draw(RenderWindow window)
    {
        _textLabel.Draw(window);
    }
    
    public void IncreaseScore()
    {
        _score += _scorePerEnemy;
        _textLabel.UpdateText($"Score: {_score}");
    }
}
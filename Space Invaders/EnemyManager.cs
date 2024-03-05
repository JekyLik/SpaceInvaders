using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class EnemyManager
{
    public List<Enemy> Enemies { get; } = new();
    private readonly float _spawnCooldown;
    private readonly float _enemySpeed;
    private readonly Clock _clock = new();
    private readonly Vector2f _screenSize;
    private readonly Random _random = new();
    private readonly AnimationManager _animationManager;
    
    public EnemyManager(float spawnCooldown, float enemySpeed, Vector2f screenSize, AnimationManager animationManager)
    {
        _spawnCooldown = spawnCooldown;
        _enemySpeed = enemySpeed;
        _screenSize = screenSize;
        _animationManager = animationManager;
    }
    
    private void SpawnEnemy()
    {
        var lastEnemySpawn =  _clock.ElapsedTime.AsSeconds();
        if (lastEnemySpawn < _spawnCooldown) return;
        var randomPositionX = _random.Next(0, (int)_screenSize.X);
        var enemyTexture = TextureManager.EnemyTexture;
        var spawnPosition = new Vector2f(randomPositionX, -enemyTexture.Size.Y);
        var enemy = new Enemy(_enemySpeed, enemyTexture, spawnPosition, _animationManager);
        Enemies.Add(enemy);
        _clock.Restart();
    }
    
    private bool IsEnemyOutOfScreen(Enemy enemy)
    {
        return _screenSize.Y < enemy.Position.Y;
    }
    
    public void Update()
    {
        SpawnEnemy();
        UpdateEnemies();
    }
    
    private void UpdateEnemies()
    {
        for (var i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].Update();
            if (IsEnemyOutOfScreen(Enemies[i]))
            {
                Enemies.RemoveAt(i);
            }
        }
    }
    
    public void Draw(RenderWindow window)
    {
        foreach (var enemy in Enemies)
        {
            enemy.Draw(window);
        }
    }
    
    public void DestroyEnemy(Enemy enemy)
    {
        enemy.PlayDeathAnimation();
        Enemies.Remove(enemy);
    }
    
}
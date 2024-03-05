namespace Space_Invaders;

public class CollisionHandler
{
    private Player _player;
    private EnemyManager _enemyManager;
    private readonly ScoreManager _scoreManager;

    
    public CollisionHandler(Player player, EnemyManager enemyManager, ScoreManager scoreManager)
    {
        _player = player;
        _enemyManager = enemyManager;
        _scoreManager = scoreManager;
    }
    
    private bool HasCollisionEnemyWithBullet(Enemy enemy, out Bullet bullet)
    {
        var bullets = _player.GetBullets();

        for (int i = 0; i < bullets.Count; i++)
        {
            bullet = bullets[i];
            if (enemy.GetGlobalBounds().Intersects(bullet.GetGlobalBounds()))
            {
                return true;
            }
        }

        bullet = null;
        return false;
    }
    
    private void HandleEnemiesCollision()
    {
        var enemies = _enemyManager.Enemies;

        for (var i = 0; i < enemies.Count; i++)
        {
            if (HasCollisionEnemyWithBullet(enemies[i], out Bullet bullet))
            {
                _player.DestroyBullet(bullet);
                _enemyManager.DestroyEnemy(enemies[i]);
                _scoreManager.IncreaseScore();
                continue;
            }
            
            if (HasCollisionEnemyWithPlayer(enemies[i]))
            {
                _player.Destroy();
            }
        }
    }
    
    public void Update()
    {
        HandleEnemiesCollision();
    }
    
    private bool HasCollisionEnemyWithPlayer(Enemy enemy)
    {
        return _player.GetGlobalBounds().Intersects(enemy.GetGlobalBounds());
    }
    
}
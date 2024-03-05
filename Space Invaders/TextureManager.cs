using Newtonsoft.Json;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Space_Invaders;

public class TextureManager
{
    private const string ASSETS_PATH = "../../../Assets";
    private const string BACKGROUND_TEXTURE_PATH = "/Backgrounds/starfieldBG.png";
    private const string PLAYER_TEXTURE_PATH = "/Ships/spaceShips_006.png";
    private const string ENEMY_TEXTURE_PATH = "/Enemies/enemyBlue1.png";
    private const string EXPLOSIONS_SPRITE_ATLAS_PATH = "/Explosions/explosionsAtlas.png";
    private const int EXPLOSIONS_SPRITE_ATLAS_COLUMNS = 4;
    private const int EXPLOSIONS_SPRITE_ATLAS_ROWS = 4;
    
    public static readonly Texture BackgroundTexture;
    public static readonly Texture PlayerTexture;
    public static readonly Texture EnemyTexture;
    public static readonly SpriteAtlas ExplosionAtlas;
    
    private static readonly SpriteAtlasSettings ExplosionAtlasSettings =
        new(ASSETS_PATH + "/Explosions/explosionsAtlas.png", 4, 4);

    static TextureManager()
    {
        BackgroundTexture = new Texture(ASSETS_PATH + BACKGROUND_TEXTURE_PATH);
        PlayerTexture = new Texture(ASSETS_PATH + PLAYER_TEXTURE_PATH);
        EnemyTexture = new Texture(ASSETS_PATH + ENEMY_TEXTURE_PATH);
        ExplosionAtlas = new SpriteAtlas(ExplosionAtlasSettings);
    }
}
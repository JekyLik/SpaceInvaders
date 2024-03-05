using SFML.Graphics;

namespace Space_Invaders;

public class SpriteAtlas
{
    public int Count { get; }
    private readonly Texture _atlasTexture;
    private readonly int _columns;
    private readonly int _singleSpriteWidth;
    private readonly int _singleSpriteHeight;

    public SpriteAtlas(SpriteAtlasSettings spriteAtlasSettings)
    {
        _atlasTexture = new Texture(spriteAtlasSettings.TexturePath);
        _columns = spriteAtlasSettings.Columns;
        var rows = spriteAtlasSettings.Rows;

        _singleSpriteWidth = (int)(_atlasTexture.Size.X / rows);
        _singleSpriteHeight = (int)(_atlasTexture.Size.Y / _columns);
        Count = _columns * rows;
    }
    
    public Sprite GetSprite(int currentIndex)
    {
        var rowIndex = currentIndex / _columns;
        var columnIndex = currentIndex % _columns;
        var intRect = new IntRect(columnIndex * _singleSpriteWidth, rowIndex * _singleSpriteHeight, _singleSpriteWidth, _singleSpriteHeight);
        return new Sprite(_atlasTexture, intRect);
    }
}
namespace Space_Invaders;

public class SpriteAtlasSettings
{
    public string TexturePath { get; }
    public int Columns { get; }
    public int Rows { get; }

    public SpriteAtlasSettings(string texturePath, int columns, int rows)
    {
        TexturePath = texturePath;
        Columns = columns;
        Rows = rows;
    }
}
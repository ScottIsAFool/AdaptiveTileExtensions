namespace AdaptiveTileExtensions
{
    public static class AdaptiveTile
    {
        public static Tile CreateTile(string version = "3")
        {
            return new Tile(version);
        }
    }
}

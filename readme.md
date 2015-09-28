#NOTE: This is now defunct, please use the official package, details [http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/08/20/introducing-notificationsextensions-for-windows-10.aspx](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/08/20/introducing-notificationsextensions-for-windows-10.aspx)

# Adaptive Tile Extensions

Adaptive Tile Extensions is a project to more easily allow a developer to create the xml required for adaptive extensions in Windows 10.

## What are Adaptive Tiles?
Information on what they are can be found in the Build 2015 talk about Tiles, Notifications and the Action Centre [https://channel9.msdn.com/Events/Build/2015/2-762](https://channel9.msdn.com/Events/Build/2015/2-762 "Tiles talk")

## Your code
    var tile = AdaptiveTile.CreateTile();
    var binding = TileBinding.Create(TemplateType.TileWide);
    binding.Branding = Branding.None;

    var header = new Text("You have mail") {Style = TextStyle.Body};
    var content = new Text("Someone likes you!") {Style = TextStyle.Caption};
    var logo = new TileImage(ImagePlacement.Inline)
    {
        Source = "http://fc02.deviantart.net/fs71/i/2013/359/a/4/deadpool_logo_1_fill_by_mr_droy-d5q6y5u.png"
    };

    var logoSubGroup = new SubGroup {Width = 40};
    logoSubGroup.AddImage(logo);

    var subgroup = new SubGroup();
    subgroup.AddText(header);
    subgroup.AddText(content);

    binding.Add(logoSubGroup);
    binding.Add(subgroup);

    tile.Tiles.Add(binding);
    var notification = tile.GetNotification();

## The Generated XML
    <tile version="3"><visual><binding template="TileWide" branding="None"><group><subgroup hint-weight="40"><image placement="Inline" src="http://fc02.deviantart.net/fs71/i/2013/359/a/4/deadpool_logo_1_fill_by_mr_droy-d5q6y5u.png"/></subgroup><subgroup><text hint-style="Body">You have mail</text><text hint-style="Caption">Someone likes you!</text></subgroup></group></binding></visual></tile>

## The Resulting Tile
![Wide Tile](https://raw.githubusercontent.com/ScottIsAFool/AdaptiveTileExtensions/master/TileSample.PNG)

This helper is a quick and easy way for you to create all the information for a tile, for whatever size you want to support, without having to deal with generating the XML yourself.


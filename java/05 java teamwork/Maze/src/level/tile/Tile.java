package level.tile;

import gfx.Render;
import gfx.Sprite;

public class Tile {

    public static Tile voidTile = new VoidTile(Sprite.voidTile);
    public static Tile block = new BlockTile(Sprite.block);
    public static Tile finish = new FinishTile(Sprite.finish);

    public int x, y;
    public Sprite sprite;

    public Tile(Sprite sprite) {
        this.sprite = sprite;
    }

    public boolean solid() {
        return false;
    }

    public void render(int x, int y, Render render) {

    }
}

package gfx;

import level.tile.Tile;

public class Render {

    public final int WIDTH;
    public final int HEIGHT;
    public int pixels[];

    public Render(int width, int height) {
        WIDTH = width;
        HEIGHT = height;
        pixels = new int[WIDTH * HEIGHT];
    }

    public void renderTile(int xp, int yp, Tile tile) {
        for (int y = 0; y < 32; y++) {
            int ya = yp + y;
            for (int x = 0; x < 32; x++) {
                int xa = xp + x;
                if (xa < -32 || xa >= WIDTH || ya < 0 || ya >= HEIGHT) {
                    break;
                }
                pixels[xa + ya * WIDTH] = tile.sprite.pixels[x + y * 32];
            }
        }
    }

    public void renderPlayer(int xp, int yp, Sprite sprite) {
        for (int y = 0; y < 32; y++) {
            int ya = yp + y;
            for (int x = 0; x < 32; x++) {
                int xa = xp + x;
                int color = sprite.pixels[x + y * 32];
                if (color != 0xFFFF00FF) {
                    pixels[xa + ya * WIDTH] = color;
                }
            }
        }
    }
    
    public void renderMaze() {
    	
    }
}

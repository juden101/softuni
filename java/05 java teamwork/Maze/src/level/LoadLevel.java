package level;

import gfx.Render;

import java.awt.image.BufferedImage;
import java.io.IOException;

import javax.imageio.ImageIO;

import level.tile.Tile;

public class LoadLevel {

    private int tiles[];
    int width, height;

    public LoadLevel(String path) {
        loadLevel(path);
    }

    protected void loadLevel(String path) {
        try {
            BufferedImage image = ImageIO.read(LoadLevel.class.getResource(path));
            int w = width = image.getWidth();
            int h = height = image.getHeight();
            tiles = new int[w * h];
            image.getRGB(0, 0, w, h, tiles, 0, w);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void render(Render render) {
        for (int y = 0; y < render.HEIGHT + 32 >> 5; y++) {
            for (int x = 0; x < render.WIDTH + 32 >> 5; x++) {
                getTile(x, y).render(x, y, render);
            }
        }
    }

    public Tile getTile(int x, int y) {
        if (x < 0 || x >= width || y < 0 || y >= height) {
            return Tile.voidTile;
        } else if (tiles[x + y * width] == 0xff7F7F7F) {
            return Tile.block;
        } else if (tiles[x + y * width] == 0xffED1C24) {
            return Tile.finish;
        } else {
            return Tile.voidTile;
        }
    }
}

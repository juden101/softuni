package gfx;

import java.awt.image.BufferedImage;
import java.io.IOException;

import javax.imageio.ImageIO;

public class SpriteSheet {

    public static SpriteSheet sheet = new SpriteSheet(128, "/map/SpriteSheet.png");

    public final int SIZE;
    private final String PATH;

    private BufferedImage image;
    public int pixels[];

    public SpriteSheet(int size, String path) {
        SIZE = size;
        PATH = path;
        loadImage();
    }

    private void loadImage() {
        try {
            image = ImageIO.read(SpriteSheet.class.getResource(PATH));
            int w = image.getWidth();
            int h = image.getHeight();

            pixels = new int[w * h];

            image.getRGB(0, 0, w, h, pixels, 0, w);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

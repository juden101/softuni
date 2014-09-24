package gfx;

public class Sprite {

    public static Sprite block = new Sprite(0, 0, 32, SpriteSheet.sheet);
    public static Sprite player = new Sprite(1, 0, 32, SpriteSheet.sheet);
    public static Sprite finish = new Sprite(2, 0, 32, SpriteSheet.sheet);
    public static Sprite voidTile = new Sprite(3, 0, 32, SpriteSheet.sheet);

    public final int X, Y, SIZE;
    private SpriteSheet sheet;
    public int pixels[];

    public Sprite(int x, int y, int size, SpriteSheet sheet) {
        SIZE = size;
        X = x * SIZE;
        Y = y * SIZE;
        this.sheet = sheet;

        pixels = new int[SIZE * SIZE];

        loadSprite();
    }

    private void loadSprite() {
        for (int y = 0; y < SIZE; y++) {
            for (int x = 0; x < SIZE; x++) {
                pixels[x + y * SIZE] = sheet.pixels[(x + X) + (y + Y) * sheet.SIZE];
            }
        }
    }

}

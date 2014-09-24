package player;

import level.LoadLevel;
import level.tile.Tile;
import input.Input;
import gfx.Render;
import gfx.Sprite;

public class Player {

    public int x, y;
    private LoadLevel loadLevel;
    private Sprite sprite;
    private Input input;
    private boolean walking;
    private boolean moved = false;
    public static int won = 0;
    private int speed = 2;

    public Player(LoadLevel loadLevel, int x, int y, Input input) {
        this.loadLevel = loadLevel;
        this.x = x;
        this.y = y;
        this.input = input;
        sprite = Sprite.player;
        walking = true;
    }

    public void setXY(int x, int y) {
        this.x = x;
        this.y = y;
        walking = true;
    }
    
    public boolean hasMoved() {
    	return moved;
    }

    public void update() {
        int xa = 0, ya = 0;
        if (walking) {
			if (input.slower && speed >= 2) {
				speed--;
			}
			if (input.faster && speed <= 6) {
				speed++;
			}
        	
            if (input.up) {
                ya -= speed;
            }
            if (input.down) {
                ya += speed;
            }
            if (input.left) {
                xa -= speed;
            }
            if (input.right) {
                xa += speed;
            }
        }

        if (xa != 0 || ya != 0) {
            move(xa, ya);
        }
    }

    public void update2() {
        if (input.R) {
            setXY((1 * 32), (14 * 32));
            Player.won = 0;
        }
    }

    public void render(Render render) {
        render.renderPlayer(x, y, sprite);
    }

    public void move(int xa, int ya) {
        if (xa != 0 && ya != 0) {
            move(xa, 0);
            move(0, ya);
            return;
        }
        
        if(!moved) {
        	moved = true;
        }

        if (!collision(xa, ya)) {
            x += xa;
            y += ya;
       }
    }

    public boolean collision(int xa, int ya) {
        boolean solid = false;
        for (int c = 0; c < 4; c++) {
            //int xt = ((x + xa) + ((c % 2) * 31)) >> 5;
        	//int yt = ((y + ya) + ((c / 2) * 31)) >> 5;
            
        	int xt = ((x + xa) + (((c % 2) * 16) + 8)) >> 5;
            int yt = ((y + ya) + (((c / 2) * 16) + 8)) >> 5;
        	
            if (loadLevel.getTile(xt, yt).solid()) {
                solid = true;
            }
            if (solid) {
                walking = true;
            }
            if (loadLevel.getTile(xt, yt) == Tile.finish) {
                won = 2;
            }
        }

        return solid;
    }

}

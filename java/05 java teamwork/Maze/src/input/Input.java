package input;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class Input implements KeyListener {

    private boolean keys[] = new boolean[128];
    public boolean up, down, left, right, C, R, N, Q, O, escape, enter, faster, slower;

    public void update() {
        up = keys[KeyEvent.VK_UP] || keys[KeyEvent.VK_W];
        down = keys[KeyEvent.VK_DOWN] || keys[KeyEvent.VK_S];
        left = keys[KeyEvent.VK_LEFT] || keys[KeyEvent.VK_A];
        right = keys[KeyEvent.VK_RIGHT] || keys[KeyEvent.VK_D];
        C = keys[KeyEvent.VK_C];
        R = keys[KeyEvent.VK_R];
        N = keys[KeyEvent.VK_N];
        Q = keys[KeyEvent.VK_Q];
        faster = keys[KeyEvent.VK_P];
        slower = keys[KeyEvent.VK_M];
        O = keys[KeyEvent.VK_O];
        escape = keys[KeyEvent.VK_ESCAPE];
        enter = keys[KeyEvent.VK_ENTER];
    }

    public void keyPressed(KeyEvent event) {
        keys[event.getKeyCode()] = true;
    }

    public void keyReleased(KeyEvent event) {
        keys[event.getKeyCode()] = false;
    }

    public void keyTyped(KeyEvent event) {

    }

}

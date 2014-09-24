package menu;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.image.BufferedImage;

import javax.xml.ws.handler.MessageContext.Scope;


public class Menu {
	public static int score;
	
    public static void renderMenu(Graphics g, boolean playerHasMoved, int boxWidth) {
		Graphics2D g2d = (Graphics2D) g;
		
		g2d.setColor(Color.gray);
		int currentBoxWidth = !playerHasMoved ? 240 : 290;
		g2d.drawRect(320, 90, 440, currentBoxWidth);
		g2d.fillRect(320, 90, 440, currentBoxWidth);

		g2d.setColor(Color.white);
		g.setFont(new Font("SansSerif", Font.BOLD, 48));
		g.setColor(new Color(255, 255, 255));
		g.drawString("HoneyDew Maze", boxWidth / 2 - 160, 145);
		
		g.setFont(new Font("SansSerif", Font.BOLD, 32));
		if(!playerHasMoved) {
			g.drawString("[N]ew game", boxWidth / 2 - 50, 200);
			g.drawString("[C]redits", boxWidth / 2 - 30, 250);
			g.drawString("[Q]uit", boxWidth / 2 - 10, 300);
		}
		else {
			g.drawString("[R]esume", boxWidth / 2 - 35, 200);
			g.drawString("[N]ew game", boxWidth / 2 - 50, 250);
			g.drawString("[C]redits", boxWidth / 2 - 30, 300);
			g.drawString("[Q]uit", boxWidth / 2 - 10, 350);
		}
    }
	
    public static void renderIngameLost(Graphics g, int boxWidth) {
		Graphics2D g2d = (Graphics2D) g;

		g2d.setColor(Color.gray);
		g2d.drawRect(320, 90, 440, 190);
		g2d.fillRect(320, 90, 440, 190);

		g.setColor(Color.white);
		g.setFont(new Font("SansSerif", Font.BOLD, 48));
		g.setColor(new Color(255, 255, 255));
		g.drawString("You lost!", boxWidth / 2 - 80, 145);

		g.setFont(new Font("SansSerif", Font.BOLD, 32));
		
		g.drawString("[R]estart", boxWidth / 2 - 35, 200);
		g.drawString("[Q]uit", boxWidth / 2 - 10, 250);
    }
	
    public static void renderIngameWin(Graphics g, int boxWidth, int currentLevel) {
    	Graphics2D g2d = (Graphics2D) g;

		g2d.setColor(Color.gray);
		g2d.drawRect(320, 90, 440, 240);
		g2d.fillRect(320, 90, 440, 240);

		g.setColor(Color.white);
		g.setFont(new Font("SansSerif", Font.BOLD, 48));
		g.setColor(new Color(255, 255, 255));
		g.drawString("You won!", boxWidth / 2 - 80, 145);

		g.setFont(new Font("SansSerif", Font.BOLD, 32));
		if(currentLevel > 0 && currentLevel < 3) g.drawString("C[o]ntinue", boxWidth / 2 - 50, 200);
		g.drawString("[N]ew game", boxWidth / 2 - 55, 250);
		g.drawString("[Q]uit", boxWidth / 2 - 10, 300);
    }
	
    public static void renderCredits(Graphics g, int boxWidth, int boxHeight) {
		Graphics2D g2d = (Graphics2D) g;

		g2d.setColor(Color.gray);
		g2d.drawRect(0, 0, boxWidth, boxHeight);
		g2d.fillRect(0, 0, boxWidth, boxHeight);

		g.setFont(new Font("Arial", Font.BOLD, 48));
		g2d.setColor(Color.white);

		g2d.drawString("Credits", boxWidth / 2 - 80, 80);

		g2d.setFont(new Font("SansSerif", Font.BOLD, 30));
		g2d.drawString("Ana Kaneva", boxWidth / 2 - 85, 150);
		g2d.drawString("Biliana Atanasova", boxWidth / 2 - 120, 200);
		g2d.drawString("Georgi Dimitrov", boxWidth / 2 - 110, 250);
		g2d.drawString("Elena Rangelova", boxWidth / 2 - 115, 300);
		g2d.drawString("Ivan Zahariev", boxWidth / 2 - 95, 350);
		g2d.drawString("Neli Iordanova", boxWidth / 2 - 105, 400);
		g2d.drawString("Petar Harizanov", boxWidth / 2 - 115, 450);
    }
    
    public static void renderMap(Graphics g, BufferedImage image, int time, int level) {
    	g.drawImage(image, 0, 0, image.getWidth(), image.getHeight(), null);
		g.setFont(new Font("SansSerif", Font.BOLD, 12));
		g.setColor(new Color(255, 255, 255));
		g.drawString("Time: " + time, 10, 20);
		g.drawString("LEVEL " +level + " [Score: " + score + "]", 512*2 - 150, 20);
    }
}

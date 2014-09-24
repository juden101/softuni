package game;

import gfx.Render;
import input.Input;

import java.awt.Canvas;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferStrategy;
import java.awt.image.BufferedImage;
import java.awt.image.DataBufferInt;

import javax.swing.JFrame;

import player.Player;
import level.LoadLevel;
import menu.Menu;

public class Game extends Canvas implements Runnable {

	private static final long serialVersionUID = 1L;

	private final int WIDTH = 512 * 2;
	private final int HEIGHT = 512;
	private final int SCALE = 1;
	private final int TIME = 60;
	private final Dimension SIZE = new Dimension((WIDTH * SCALE), (HEIGHT * SCALE));
	public final String TITLE = "HoneyDew Maze";

	private JFrame frame;
	private Thread thread;
	private boolean looping;

	private BufferedImage image = new BufferedImage(WIDTH, HEIGHT, BufferedImage.TYPE_INT_RGB);
	private int[] pixels = ((DataBufferInt) image.getRaster().getDataBuffer()).getData();

	private String gameStatus = "menu";
	
	private Render render;
	private Input input;
	private LoadLevel loadLevel;
	private Player player;

	private int time = TIME;
	private int score = 0;
	long now = System.currentTimeMillis();
	private int currentLevel = 1;
	
	public Game() {
		setPreferredSize(SIZE);
		setMinimumSize(SIZE);
		setMaximumSize(SIZE);

		frame = new JFrame();
		render = new Render(WIDTH, HEIGHT);
		input = new Input();
		addKeyListener(input);
		loadLevel = new LoadLevel("/map/level" + currentLevel + ".png");
		player = new Player(loadLevel, (1 * 32), (14 * 32), input);
	}

	public void start() {
		looping = true;
		thread = new Thread(this, "GameLoop");
		thread.start();
	}

	public void stop() {
		looping = false;
		try {
			thread.join();
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}

	public void run() {
		requestFocus();
		while (looping) {
			try {
				Thread.sleep(10);
				
				update();
				render();
			} catch (InterruptedException e) {
				System.out.println(e.getMessage());
			}
		}
		
		stop();
	}

	@SuppressWarnings("static-access")
	private void update() {
		input.update();
		
		if(gameStatus.equals("menu")) {
			if (input.N) {
				time = TIME;
				gameStatus = "ingame";
				player.won = 0;
				currentLevel = 1;
				loadLevel = new LoadLevel("/map/level" + currentLevel + ".png");
				player = new Player(loadLevel, (1 * 32), (14 * 32), input);
			}
			if (input.R) gameStatus = "ingame";
			if (input.C) gameStatus = "credits";
			if (input.Q) System.exit(0);
		}
		else if(gameStatus.equals("ingame")) {
			if (input.escape) gameStatus = "menu";
			
			if (time > 0 && Player.won == 0) {
				if (System.currentTimeMillis() - now >= 1000) {
					time--;
					now += 1000;
				}
			}
			
			if (time == 0) Player.won = 1;
			if (Player.won == 0) {
				input.update();
				player.update();
			} else {
				input.update();
				player.update2();
				if (input.R || input.N) {
					score += time;
					time = TIME;
					gameStatus = "ingame";
					player.won = 0;
					currentLevel = 1;
					loadLevel = new LoadLevel("/map/level" + currentLevel + ".png");
					player = new Player(loadLevel, (1 * 32), (14 * 32), input);
				}
				if (currentLevel == 1) {
					score = 0;
				}
				if (input.O && Player.won == 2 && currentLevel < 3) {
					score += time;
					time = TIME;
					gameStatus = "ingame";
					player.won = 0;
					currentLevel++;
					loadLevel = new LoadLevel("/map/level" + currentLevel + ".png");
					player = new Player(loadLevel, (1 * 32), (14 * 32), input);
				}
				
				if (input.Q) System.exit(0);
				now = System.currentTimeMillis();
			}
		}
		else if(gameStatus.equals("credits")) {
			if (input.escape)  gameStatus ="menu";
		}
	}
	
	private void render() {
		BufferStrategy bs = getBufferStrategy();
		if (bs == null) {
			createBufferStrategy(3);
			return;
		}
		
		Graphics g = bs.getDrawGraphics();
		
		loadLevel.render(render);
		player.render(render);

		for (int i = 0; i < pixels.length; i++) {
			pixels[i] = render.pixels[i];
		}
		Menu.score = score;
		Menu.renderMap(g, image, time, currentLevel);
		
		if (gameStatus.equals("menu")) {
			Menu.renderMenu(g, player.hasMoved(), WIDTH);
		}
		else if(gameStatus.equals("ingame")) {
			if (Player.won == 1) {
				Menu.renderIngameLost(g, WIDTH);
			}
			if (Player.won == 2) {
				Menu.renderIngameWin(g, WIDTH, currentLevel);
			}
		}
		else if(gameStatus.equals("credits")) {
			Menu.renderCredits(g, WIDTH, HEIGHT);
		}
		
		g.dispose();
		bs.show();
	}

	public static void main(String[] args) {
		Game game = new Game();
		game.frame.setTitle(game.TITLE);
		game.frame.setResizable(false);
		game.frame.add(game);
		game.frame.pack();
		game.frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		game.frame.setLocationRelativeTo(null);
		game.frame.setVisible(true);
		game.start();
	}
}

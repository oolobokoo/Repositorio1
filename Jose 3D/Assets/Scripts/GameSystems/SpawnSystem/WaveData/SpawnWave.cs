using System.Collections;
using System.Collections.Generic;

public class SpawnWave {

    public float startTime;
    public float timer;
    public float timeDelta;

    public string[] enemies;

    public SpawnWave (float startTime, float timer, float timeDelta) {
        this.startTime = startTime;
        this.timer = timer;
        this.timeDelta = timeDelta;
    }

    public void AddEnemy (string enemy, int index) {
        enemies[index] = enemy;
    }

    public void Populate (string[] enemies) {
        this.enemies = new string[enemies.Length];
        for (int i = 0; i < enemies.Length; i++) {
            AddEnemy (enemies[i], i);
        }
    }
}

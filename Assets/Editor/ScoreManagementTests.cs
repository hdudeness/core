using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEditor.SceneManagement;

public class ScoreManagementTests
{

    [SetUp]
    public void ResetScene()
    {

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

    }

    [Test]
    public void AddPointsOnEnemyKill_Test()
    {
        // Arrange
        var gameData = new GameManagement();
        gameData.score = 0;

        //When enemy killed, update score by one
        //Score will be increased by 1
        gameData.scoreUpdate(1);
        Assert.True(gameData.score == 1);

        //When enemy killed, update score by 2
        //Score is expected to be 3
        gameData.scoreUpdate(2);
        Assert.True(gameData.score == 3);

    }

    [Test]
    public void EnemyHealthLoweredWhenBulletHitsEnemy_Test()
    {
        // Arrange
        var enemyTriangle = new EnemyTriangle();
        enemyTriangle.health = 4; //original health of enemy
        enemyTriangle.damgePerBullet = 2;   //damage per bullet

        //Act
        enemyTriangle.BulletHit();

        // Assert
        //the health of enemy is expected to be deducted by 1 when hit by a bullet
        Assert.True(enemyTriangle.health == 2);

        //Arrange
        var enemyOctagon = new EnemyOctagonPurple();
        enemyOctagon.health = 5;
        enemyOctagon.damgePerBullet = 1;

        //Act
        enemyOctagon.BulletHit();

        // Assert
        //the health of enemy is expected to be deducted by 1 when hit by a bullet
        Assert.True(enemyOctagon.health == 4);
    }

    [Test]
    public void ShieldCollisionKillsEnemy_Test()
    {
        // Arrange

        // Act

        // Assert
    }
}

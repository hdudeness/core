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
        // Temporarily commented out because of code refactoring
        
        // Arrange
        var enemyTriangle = new EnemyTriangle();
        var bullet = new Bullet();
        enemyTriangle.health = 4; //original health of enemy
        bullet.damage = 2; //damage dealt per bullet

        //Act
        enemyTriangle.Hit(bullet.damage); 

        // Assert
        //the health of enemy is expected to be deducted by 1 when hit by a bullet
        Assert.True(enemyTriangle.health == 2);

        //Arrange
        var enemyOctagon = new EnemyOctagonPurple();
        enemyOctagon.health = 5;

        //Act
        enemyOctagon.Hit(bullet.damage);

        // Assert
        //the health of enemy is expected to be deducted by 1 when hit by a bullet
        Assert.True(enemyOctagon.health == 3);
        
    }

    //Test the Hit function in EnemyOctangonPurple class
    [Test]
    public void EnemyOctagonPurpleHitTest()
    {
        var enemy = new EnemyOctagonPurple();
        int originalHealth = 5;
        enemy.health = originalHealth;
        int damage = 1;
        enemy.Hit(damage);

        //the health of the enemy is expected to be deducted by the damage
        Assert.That(enemy.health, Is.EqualTo(originalHealth - damage));

    }

    //Test for Hit function in EnemyHeartPink class
    [Test]
    public void EnemyHeartPinkHitTest()
    {
        var enemy = new EnemyHeartPink();
        int originalHealth = 5;
        enemy.health = originalHealth;
        int damage = 1;
        enemy.Hit(damage);

        //the health of the enemy is expected to be deducted by the damage
        Assert.That(enemy.health, Is.EqualTo(originalHealth - damage));
    }


    //Test for Hit function in EnemyCircleMaroon class
    [Test]
    public void EnemyCircleMaroonHitTest()
    {
        var enemy = new EnemyCircleMaroon();
        int originalHealth = 5;
        enemy.health = originalHealth;
        int damage = 1;
        enemy.Hit(damage);

        //the health of the enemy is expected to be deducted by the damage
        Assert.That(enemy.health, Is.EqualTo(originalHealth - damage));
    }

    //Test UpdateCoreHealth in HealthManagement class
    [Test]
    public void HealthManagementUpdateCoreHealthTest()
    {
        var healthManagement = new HealthManagement();
        int originalHealth = 100;
        healthManagement.coreHealth = originalHealth;
        int damage = 10;

        healthManagement.updateCoreHealth(damage);
        //Health of core is expected to be decreased by damage
        Assert.That(healthManagement.coreHealth, Is.EqualTo(originalHealth - damage));
    }
        

    [Test]
    public void ShieldCollisionKillsEnemy_Test()
    {
        // Arrange

        // Act

        // Assert
    }

    [Test]
    public void HitTriangleTest1()
    {
        // Arrange
        var enemyTriangle = new EnemyTriangle();
        var bullet = new Bullet();
        enemyTriangle.health = 5;
        bullet.damage = 1;

        

        // Act
        enemyTriangle.Hit(bullet.damage);

        // Assert
        Assert.True(enemyTriangle.health == 4);
    }

    [Test]
    public void HitTriangleTest2()
    {
        // Arrange
        var enemyTriangle = new EnemyTriangle();
        var bullet = new Bullet();
        enemyTriangle.health = 5;
        bullet.damage = 2;
        
        // Act
        enemyTriangle.Hit(bullet.damage);

        // Assert
        Assert.True(enemyTriangle.health == 3);
    }

    [Test]
    public void DestroyTriangleTest1()
    {
        // Arrange
        var enemyTriangle = new EnemyTriangle();
        var bullet = new Bullet();
        enemyTriangle.health = 1;
        bullet.damage = 1;

        // Act
        //enemyTriangle.Hit(bullet.damage);

        // Assert
        //UnityEngine.Assertions.Assert.IsNull(enemyTriangle);
    }


}

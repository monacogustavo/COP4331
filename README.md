# Augmented Hoops

## Vision Statement

The product's target market will consist of all Apple phones users who would like to play a new handheld AR basketball game. This product targets the increasing want for more AR games for the general public's mobile devices. Augmented Hoops - A basketball AR game. Being able to theoretically play basketball anywhere using augmented reality through your phone. Not only that, but an arcade mode will challenge your skills in a variety of fun ways. The other basketball AR games out there today are simply point and swipe games. Ours will introduce fun challenges such as moving hoops and other such arcade tactics.

## User Stories / Product Backlog

User Story / Requirement | Priority | Effort | Validation
--- | --- | --- | ---
As a gamer, I want to swipe the basketball up on the screen, so that I can shoot | 1 | 2 | When placing finger on basketball and moving, the basketball tracks finger movement
As a gamer, after I release the shot I want the basketball to move through the air towards the basket, so that I can make a shot | 1 | 8 | After releasing finger from basketball, the ball moves away from camera towards the target 
As a gamer, I want to score points when I make a basket, so that I can feel a sense of accomplishment | 2 | 1 | When the ball goes in the basket, the score increments
As a gamer, I want the hoop to move at times, so there is an extra degree of difficulty | 3 | 5 | The hoop will move either after some amount of time in the game, or through a separate game mode
As a gamer, I want the ball to collide with the ground, so that the game feels realistic | 1 | 1 | When the ball hits the ground, it doesn't fall through the floor
As a gamer, I want the ball to bounce off the floor, so that the game feels realistic | 2 | 3 | When the ball collides with the ground, the ball bounces
As a gamer, I want the basketball to disappear a short time after making or missing a shot, so that there are not basketballs all over the place | 2 | 2 | Basketballs disappear a few seconds after colliding with the ground
As a gamer, I want the ball to collide with the backboard, so that I don't have to hit "nothing but net" | 1 | 1 | When the ball hits the backboard, it doesn't travel through it
As a gamer, I want the ball to bounce off the backboard, so that I can make shots off the backboard | 1 | 2 | When the ball collides with the backboard, it bounces off of it
As a gamer, I want to download the game off the app store, so that I can easily install and play it | 4 | 8 | The game is available on the Apple app store and can be downloaded
As a gamer, I want the ability to track my high scores, so that I can compare against my friends | 4 | 5 | The game remembers the highest scores on the device
As a gamer, I want the game to be timed (30 seconds per game or so), so that I don't play forever | 2 | 2 | The game ends 30 seconds after the game begins, and they are sent back to main menu
Aquire 3D Hoop Model | 1 | 1 | A 3D model of a basketball backboard/hoop is in our project
Aquire Basketball Model | 1 | 1 | A 3D model of a ball is in our project
Make project load to blank screen | 1 | 1 | The app builds and loads to a blank screen

## Sprint Backlog

User Story / Requirement | Priority | Effort | Validation
--- | --- | --- | ---
Aquire Basketball Model | 1 | 1 | A 3D model of a ball is in our project
As a gamer, I want the ball to collide with the ground, so that the game feels realistic | 1 | 1 | When the ball hits the ground, it doesn't fall through the floor
Make project load to blank screen | 1 | 1 | The app builds and loads to a blank screen

## Burndown Chart

![alt-text](/Sprint_1/images/BurndownSprint1.png "Burndown Chart")

## Design Documents

#### App Usage Workflow

![alt-text](/Sprint_1/images/Augmented_Hoops_UML.png "App Usage Diagram")

## Code

Build instructions:
1. Visit Unity3d.com and create Unity account (if you do not already have one)
  * A Personal account is sufficient (and free)
2. Download Unity Installer (for windows) from this location: https://github.com/monacogustavo/COP4331/tree/master/Unity%20Installer
  * If on Mac, download installer from Unity3d.com by clicking "Get Unity" in top right corner
3. Install Unity
  * Mandatory install options
    * iOS Build Support
    * Vuforia Augmented Reality Support
4. Download "Augmented Hoops (1)" project folder from https://github.com/monacogustavo/COP4331
7. Open project in Unity after signing into your Unity Account
8. Click Play (![alt-text](/Sprint_1/images/PlayButton.png "Play Button")) button at top center of IDE

## Tests

User Story | Test | Status
--- | --- | ---
As a gamer, I want the ball to collide with the ground, so that the game feels realistic | /Assets/Test Cases/BallCollisionDetector.cs | PASSED


# Source Code

https://github.com/monacogustavo/COP4331/tree/master/Augmented%20Hoops%20(1)

## Run instructions

#### Computer

1. Visit Unity3d.com and create Unity account (if you do not already have one)

- A Personal account is sufficient (and free)

2. Download Unity Installer from this location: https://github.com/monacogustavo/COP4331/tree/master/Unity%20Installer

3. Install Unity

- Mandatory install options

  - iOS Build Support
  - Vuforia Augmented Reality Support

- Optional
  - Android Build Support

4. Download "Augmented Hoops (1)" project folder from https://github.com/monacogustavo/COP4331
5. Open project in Unity after signing into your Unity Account
6. Click File -> Open Scene...
7. Navigate to the /Assets/MainMenu.unity file and click Open
8. Click Play (![Play Button](/Sprint_1/images/PlayButton.png 'Play Button')) button at top center of IDE

- Touch enabled device required for full functionality. See build instructions below to deploy to phones.

#### Phone

_Must build and deploy to phone first via one of the methods in Build Instructions_

1. Print the target picture located at https://github.com/monacogustavo/COP4331/blob/master/ARTarget.jpg
2. Place printed AR Target somewhere in front of you
3. Open Augmented Hoops on phone
4. Press Play
5. Point camera at printed AR Target
6. Play!

- Press the 2D ball in the lower left hand corner to "grab" a ball
- Swipe up on the screen to shoot the ball at the target

## Build Instructions

#### iPhone

_Requires a Mac_

1. Follow the article located here (also read notes/modifications below) https://unity3d.com/learn/tutorials/topics/mobile-touch/building-your-unity-game-ios-device-testing

- Skip to the "Adding your Apple ID to XCode" step
- Instead of using the "Simple Mobile Placeholder" project, open our project instead (Augmented Hoops (1)).
- When building our project ensure that the MainMenu scene appears above AR in the list in Build Settings

#### Android

_Requires "Android Build Support" Unity install option_

1. Follow the article located here (also read notes/modifications below) https://unity3d.com/learn/tutorials/topics/mobile-touch/building-your-unity-game-android-device-testing

- Skip to the "Setting up the Android SDK Tools" step
- Instead of using the "Simple Mobile Placeholder" project, open our project instead (Augmented Hoops (1)).
- When building our project ensure that the MainMenu scene appears above AR in the list in Build Settings

# Museum Heist
A mixed reality (AR/VR) museum heist game where you are given a mission of robbing an ancient artifact. You must be attentive of the security systems and puzzles to solve.Are you ready for the challenge?

## Overview
Embark on an immersive journey through a high-tech museum in this AR/VR game, blending cutting-edge technology with thrilling gameplay. Players start in an augmented reality (AR) world, receiving their mission and learning about the museum's sophisticated security systems. The goal is to steal a valuable artifact, navigating through puzzles and evading security measures like cameras and lasers. This project showcases advanced Unity scripting to create an engaging mixed reality experience.

## Features
- **AR Introduction**: Experience the game's backstory and objectives in an augmented reality setting, setting the stage for the adventure.
- **VR Gameplay**: Dive into a virtual reality environment where you solve puzzles, including a Simon Says game and a weight-sensitive pedestal challenge, to progress towards the artifact.
- **Security Evasion**: Avoid detection by security cameras and lasers, using gadgets and stealth to bypass high-tech security.
- **Interactive Puzzles**: Engage with a variety of puzzles, from keypad proximity detectors to button triggers, each designed to challenge and entertain.
- **Dynamic Security Systems**: Navigate through rooms with moving lasers and camera detection systems that require timing and strategy.
- **Scene Management**: Seamlessly switch between AR and VR scenes, enhancing the immersive experience.

## Project Structure
- **Scripts**:
  - `WeightSensitivePedestal.cs`: Manages the mechanics of a puzzle involving a pedestal sensitive to the weight of objects placed on it.
  - `ButtonTrigger.cs`, `SimonSaysGame.cs`: Scripts for interactive puzzle elements that players must solve to advance.
  - `SecurityCamera.cs`, `Laser.cs`, `CameraDetection.cs`: Controls the behavior of security systems within the museum.
  - `KeypadProximityDetector.cs`, `DistractionObject.cs`: Additional interactive elements that add depth to puzzle-solving and stealth gameplay.
  - `StartButton.cs`, `SwitchScene.cs`: Manages the game flow, including the transition between AR and VR environments.

## Collaboration
Big thanks to Marcella Heisey for being the awesome designer and modeler for all the objects, textures, and lighting in the scene.
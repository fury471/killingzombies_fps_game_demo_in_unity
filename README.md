# The One Who Survives

A small first-person horror survival demo built in Unity. The player explores an abandoned hospital/asylum, fights zombies, collects mission objectives, and escapes through the final exit.

## Screenshots

![Knife combat against a zombie](screenshots/gameplay-knife-zombie.png)

![Rifle combat in the asylum room](screenshots/gameplay-rifle-room.png)

![Final exit hall](screenshots/gameplay-exit-hall.png)

## Project Structure

The Unity project is located in:

- `The One Who Survives/`

Unity version:

- `6000.3.10f1`

Important scenes:

- `Assets/Scenes/MainMenu.unity`
- `Assets/Scenes/Level01_Asylum.unity`

## Current Gameplay

- Main menu with play and quit
- First-person movement and mouse look
- Jump and crouch
- Rifle, pistol, and knife combat
- Reload and basic weapon animations
- Zombie spawning, chase, attack, death, and animation
- Objective collection system for medicines and files
- Exit-based win condition
- Lose, retry, and return-to-menu flow
- Door interaction in the hospital level

## Controls

- `W A S D` move
- `Mouse` look
- `Left Click` attack / shoot
- `R` reload
- `Space` jump
- `Left Ctrl` crouch
- `H` use medkit
- `F` interact
- `1 / 2 / 3` switch weapons
- `Esc` return to main menu from the level

## Open The Project

1. Open Unity Hub
2. Add the folder `The One Who Survives`
3. Open the project in Unity

## Cloning And Large Assets

This project may use Git LFS for large binary assets such as textures, models, and audio.

Important:

- A normal GitHub `Download ZIP` archive may not be enough to open the full Unity project if LFS-managed files are excluded from GitHub source archives.
- For a complete working project, prefer cloning with Git and Git LFS instead of downloading the repository ZIP.

Recommended workflow:

```powershell
git clone https://github.com/fury471/KillingZombies_FPS_Game_demo_in_Unity.git
cd KillingZombies_FPS_Game_demo_in_Unity
git lfs pull
```

Optional lightweight first clone:

```powershell
git lfs install --skip-smudge
git clone https://github.com/fury471/KillingZombies_FPS_Game_demo_in_Unity.git
cd KillingZombies_FPS_Game_demo_in_Unity
git lfs pull
```

If you only want to play the game, use the Windows build from the GitHub Release instead of the source repository.

## Build

Use Unity Build Profiles / Build Settings and include:

1. `Assets/Scenes/MainMenu.unity`
2. `Assets/Scenes/Level01_Asylum.unity`

Target platform:

- Windows x86_64

## Notes

- This repository intentionally excludes local workshop notes and planning markdown files.
- Unity-generated folders such as `Library`, `Temp`, `Logs`, and builds are ignored.

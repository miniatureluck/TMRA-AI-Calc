# TMRA AI movement prediction calculator

## Introduction

This is my first non-tutorial app that I've made when I tried to learn C# in my free time.
I've put the code here to show how much I improved since then.

Last time it was modified was in Sept 2021. I didn't have a clue about `version control` at that time, so there are no commits.
This is how my version control looked like:

![image](https://github.com/miniatureluck/TMRA-AI-Calc/assets/105822819/4662a55f-1f75-4f20-90c9-1930bf0176f1)

Looking at it now, the code is ___very bad___. This is because before I created the app, I had been coding only as a hobby, without any guidance or courses. I was not aware of naming conventions or good practice, not to mention solution architecture.

## Description

Users can calculate the enemy unit's attack target. They just need to provide the data from the current situation in the game.

The starting values of the units can be loaded up from a `json file`. It can be created by the app - hitting the 'update' button will make the app `parse the game's wikipedia` for the list of units along with all their stats on each level, then it will save it all in the json file.

The target is calculated by taking some priorities over others, such as which unit has more movement, then which has more initiative, then something else, and so on... I managed to create and use a `mathematical algorithm` for that.

## Links
The app's main functionality can be seen on youtube: https://youtu.be/kkgV8IeeQo4

The standalone app can be downloaded from here: https://drive.google.com/file/d/1EjxVuVdtXzeJgq2xYu4ptT5gmMPcSN8K/view?usp=sharing

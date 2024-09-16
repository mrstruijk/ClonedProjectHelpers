# BuildHelpers

- By: Maarten R. Struijk Wilbrink
- For: Leiden University SOSXR
- Fully open source: Feel free to add to, or modify, anything you see fit.


## Installation
1. Open the Unity project you want to install the gizmos into.
2. Open the Package Manager window.
3. Click on the `+` button and select `Add package from git URL...`.
4. Paste the URL of this repo into the text field and press `Add`.



## Reasoning

Similar to how [ParrelSync](https://github.com/VeriorPies/ParrelSync) works, but less advanced. 

Borne from the need to not have a [symlink](https://docs.unity.com/ugs/en-us/manual/devops/manual/symlink-support) by ParrelSync, because we were already using our own symlinks in the project. Double symlinks are not supported by Unity.

Needing to be able to have a clone of the project, for testing the Networking features of the game, without having the risk of editing something in the clone project. This would be a problem, because that would be a lot of work to merge back into the main project. So I needed a way to notify myself of the fact that I was in the clone project, and not the main project.

## Usage

Clone your main project. Rename something in the path to include the word `clone`. This will trigger the script to show a warning message in the console. This will remind you that you are in the clone project, and not the main project. E.g. 
Main Project : "Users/maarten/Documents/Unity/ProjectName"
Clone Project: "Users/maarten/Documents/Unity/ProjectName_clone"

## Major Downside
In the Unity Hub you'll have to look at the path to see if you're opening the clone project or not. This is not ideal, but it's the best I could come up with.
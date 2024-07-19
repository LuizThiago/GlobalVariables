<a id="readme-top"></a>
<br />
<div align="center">
  <h3 align="center">Global Variables</h3>

  <p align="center">
    A simple way to create variables with global access using Scriptable Objects
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
        <li><a href="#usage">Usage</a></li>
      </ul>
    </li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

The `GlobalVariable<T>` script allows you to create and manage global variables that can be used anywhere in your Unity project. The variables are stored as ScriptableObjects, and the script provides a mechanism to notify other parts of the code about changes in the variable's value through events. This pattern is useful for managing global states and events that affect the behavior of the game.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [![C#](https://custom-icon-badges.demolab.com/badge/C%23-%23239120.svg?logo=cshrp&logoColor=white)](#)
* [![Unity](https://img.shields.io/badge/Unity-%23000000.svg?logo=unity&logoColor=white)](#)

<p align="right"><a href="#readme-top">back to top</a></p>



<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple example steps.

### Installation

1. Download or fork this project
2. Move the content to your Unity project _(if preferred, only the Scripts folder is necessary)_
4. Enter your API in `config.js`
   ```c#
   const API_KEY = 'ENTER YOUR API';
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Create a new script that inherits from GlobalVariable<T>, where T is the type of the variable. Example:

1. _Create a global float variables script_
   `GlobalFloatVariable.cs`
   ```c#
   using UnityEngine;

   [CreateAssetMenu(menuName = "Global Variables/Float Type", fileName = "GlobalFloatVariable")]
   public class GlobalFloatVariable : GlobalVariable<float> { }
   ```
2. _Create an instance of the global variable by right-clicking on the desired folder in the Project tab window and choosing the option (in this example)_ `Create > Global Variables > Global Float Variable`
3. _Give your new global variable a name, for example,_ `PlayerHealth`
4. _Now, to access it, simply reference the Scriptable Object created in your scripts. Example:_
   `TestGlobalFloatVariable.cs`
   ```c#
   using System.Collections;
   using UnityEngine;
   
   public class TestGlobalFloatVariable : MonoBehaviour
   {
      [SerializeField] private GlobalFloatVariable _playerHealth; //The reference for the GlobalFloatVariable

      private IEnumerator Start()
      {
         //Subscribe to the player health's OnChange event to be notified when the value changes.
         _playerHealth.OnChange.AddListener(OnPlayerHealthChange);

         Debug.Log($"[TestGlobalFloatVariable] Player health value: {_playerHealth.Value}");
         string timestamp = System.DateTime.Now.ToString("HH:mm:ss.fff");
         Debug.Log($"[TestGlobalFloatVariable][{timestamp}] Change player health to 100 in 5 second.");

         //Wait and set the player health to 100.
         yield return new WaitForSeconds(5);
         _playerHealth.Value = 100;
      }

      private void OnPlayerHealthChange(float value)
      {
         string timestamp = System.DateTime.Now.ToString("HH:mm:ss.fff");
         Debug.Log($"[TestGlobalFloatVariable][{timestamp}] Player health changed to {value}");
      }
   }
   ```


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

LuizThiago - [@CodeLuiz](https://twitter.com/@CodeLuiz) - hello@luizthiago.com

Project Link: [https://github.com/LuizThiago/GlobalVariables](https://github.com/LuizThiago/GlobalVariables)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

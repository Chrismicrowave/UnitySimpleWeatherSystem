# Unity Simple Weather System
Unity tool assignment project - RMIT Game Design BA GDS3 - Chris Cao
CC0

-------------------------

## About this tool

This is a simple weather system tool using Unity's particle system and timeline. It allows user to quickly set up 4 different weathers from rain, hail, snow and wind. 

The weathers could be created and played in the scene directly, or using the timeline control in Unity to animate and arrange them with clips similar to video editing software.

Advance users could untick the override particle system and go into the particle system directly to tweak the settings. Rain/hail/snow direction could be override by wind weather or to be set individually. 


-------------------------

## Quick Setup
<details>
  
### Importing Tool

![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(1).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(2).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(3).jpg)

### Creating Weather

![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(4).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(5).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(6).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(7).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(8).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(9).jpg)

### Using Timeline

![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(10).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(11).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(12).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(13).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(14).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(15).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(16).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(17).jpg)
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/QuickStart%20(18).jpg)

</details>


-------------------------

## Manual

<details>

### Rain Hail Snow Weather Class
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/Manual%201.jpg)

### Wind System Class
![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/Manual%202.jpg)

</details>


-------------------------

## FAQ

<details>

- Why the droplet of the rain/ snow/ hail not hitting the ground of my secene?

  You can adjust the 'Droplet Life' parameter in the inspector window and make sure the droplets last till they hit the ground.



- Why is my rain/hail/snow's direction is not override by the wind after I click 'Use Wind System Direction' ?

  Make sure there is a wind weather game object in the scene by clicking 'Create Wind Game Object' in the 'SimpleWeatherSystem' game object. Move and rotate the wind game object to the desired location and direction, untick and tick again to reload the wind direction.



- How do I have the clip keep playing throughout the game?

  Click the 'Play Indefinitely In Game' on the weather class script component in Inspector window.



- How do I have a few different animation sequences?

  You have to create another timeline asset by right click in the project folder window, and go to 'Create > Timeline > Timeline'. And replace the 'Playable' in the 'Playable Director' component in the 'SimpleWeahterSystem' game object.


- How to create track and clip if for a new custom weather class?

  This may or may not work for custom class in this simple system, to create track and clip in the timeline, you will have to create three classes "track asset, playable behaviour, playable asset", you could copy and modify from exsiting scripts in the script folder, and here are the simple explaination of the code:

  ![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/AddNewWeatherToTimeline1.jpg)
  ![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/AddNewWeatherToTimeline2.jpg)
  ![](https://github.com/Chrismicrowave/UnitySimpleWeatherSystem/blob/main/Readme%20Images/AddNewWeatherToTimeline3.jpg)
  
  


</details>

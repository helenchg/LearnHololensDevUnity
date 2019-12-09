# Learn AR (Hololens) Development in Unity
I am documenting my learning in this repository. I started from zero again. Hopefully this could be a rough guide for someone else who wants to pick it up today. This is not meant to be a step by step guide. 

## Getting started with MixedRealityToolKit v2.
At first, I found the github repo for the MRTK https://github.com/microsoft/MixedRealityToolkit-Unity, but did not know how to use it. This tutorial is a good place to start http://unicodeexception.com/2019/02/start-mixedrealitytoolkit-v2/. We actually have to download the entire repo, open it in unity, and then export it again as a unitypackage. This way, every time I start a new project, I can just import the MRTK unity package. 

## 8. BasicContextAwareAgent (HoloToolkit 2017.4 + Navmesh + Voice Input + Gesture) - Unity2017.4
In this project, I am combining everything I have learned so far to build a basic context-aware agent that appears when called and navigate in the physical environment. Currently, the agent can understand "Hey Jinn" and "Come back" voice commands. The Husky asset and  NavMesh is generated using the modified Spatial Mapping code from https://github.com/drakep/MixedRealityToolkit-Unity/tree/CharlesCuteAnimalBranch. 
You can create a larger NavMesh by changing the agent humanoid property.

TODO:
- [X] Generate NavMesh for agent to navigate in the physical environment
- [X] Agent appears with voice command
- [X] Agent moves towards user with voice command
- [X] User can air-tap destinations for the agent to move.


Stretch goals:
- [ ] Agent animation matches action.
- [ ] User use voice command to get agent to walk towards specific destination.
- [ ] Agent looks at user (billboard script).
- [ ] Agent tags along (tagAlong script).


## 7. ModelExplorer (Holotoolkit) - Unity2017.4
[MR Input 210-Gaze Tutorial](https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-210) For some reason, Unity2019 projects are not building, so I started this project with Unity2017.4LTS. This is the tutorial from Microsoft https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-210. It took me forever to get through because many of the assets were missing and the videos dont match the actual instruction and required assets. Many of the scripts needed some kind of debugging. Learn about the billboard and tag-along scripts, which could be useful later on for my agent.


## 6. HTK_NavMesh_Agent (HoloToolkit 2017.4 + NavMesh) - Unity2017.4
I found this repository that essentially implement NavMesh at runtime using spatial mapping from the Hololens using the HoloToolkit.
I was able to run the Spatial Mapping Nav Mesh example without compilation error. I tried to reverse engineer this version to understand what he added on top of the hololens SDK. There are three main scripts in Spatial Mapping prefab that got modified: Spatial Mapping Manager, Spatial Mapping Observer, and Object Surface Observer. He also added a script to draw the NavMesh using the Spatial Mapping meshes at runtime. One issue I encountered was that the NavMesh is very restricted, it only showed a few open area for the agent to navigate. I need to figure out how to expand that to the entire spatial mapping environment. 
https://github.com/drakep/MixedRealityToolkit-Unity/tree/CharlesCuteAnimalBranch
After playing with this project and comparing results with the SpatialMappingAgent project below, I realized that I might not need a NavMesh for my project. I can just use spatial mapping mesh.


## 5. SpatialMappingAgent - Unity2017.4.34f1 (HoloToolkit 2017.4 release)
I spent the last few days playing around and familiarizing with spatial mapping and the HTK SDK from 2017. I will leave the MRTK2 SDK for later. I have made several attempts at generating NavMesh at runtime using the Spatial Mapping meshes, and this project is the first attempt. I tried to follow these Japanese tutorials by translating it to English https://qiita.com/morio36/items/d75228d2ccdb9c24574b and https://tarukosu.hatenablog.com/entry/2017/04/23/183546. 
- [Failure] The version they used seem to be older release. Some of the code snipets got removed in mine, so I could not technically follow what they did.
- [Success] I was able to still place an agent in the environment and use Air-tap gesture to define a new destination for it to move.
It uses the spatial mapping mesh, I dont think the NavMesh is working.
- Right now, the agent will move towards the place I air-tapped. Essentially, creating a temporary "waypoint" or destination.

 Check out the [project](https://github.com/helenchg/LearnHololensDevUnity/tree/master/SpatialMappingAgent) README.md to see results.


## 4. NavMesh101 - Unity2019.3.0f1
This project is about learning how to use Unity NavMesh Components. I literally just followed Brackeys video tutorials and downloaded his assets. I created a new 3D project using Unity2019.3.0f1 and dragged the entire NavMesh-Tutorial downloaded from github at: https://github.com/Brackeys/NavMesh-Tutorial
Thanks to this tutorial, I discovered that Unity has a ThirdPersonCharacter scripts that does the animation for navigation automatically, but this is only for a humanoid avatar. For my thesis, I will have to figure out how to modify everything for a non-humanoid agent. These set of video tutorials are really great, now I just need to figure out how to use Hololens Spatial Mapping and combine it with Unity NavMeshComponents https://github.com/Unity-Technologies/NavMeshComponents. FYI, the NavMesh-Tutorial folder already has the Unity NavMeshComponents imported.
Alright, if you want to dive deeper on NavMesh, check this six-part tutorial by Unity https://www.youtube.com/playlist?list=PLX2vGYjWbI0Rf0im34I2lBF4eufM-cgzQ (quite long and more advanced, you will definitely understand it if you did the previous tutorial by Brackeys.) Everything related to the navMeshAgent (agent navigation) is in the UnityEngine.AI namespace. Tutorial #3 talks about a drone, which is technically non-humanoid. They did not animate it though. Also, the scene is so dark, you can barely see the drone moving.

I wonder much large of a navMesh can the hololens 1 handle...

## 3. VoiceRecognition100 - Unity2019.2.8f1 (HoloToolkit)
This project allows you to control the 3D character by using voice input. You can command it to "dance", "stop", move the character "upward", "back", "forward", and "down".

Download 3D characters and animations from https://www.mixamo.com/ You need an Adobe account to do so.
Followed this voice recognition tutorial on youtube. https://www.youtube.com/watch?v=29vyEOgsW8s&t=319s
Added a 3D character and animation to the project. Learned about animation control for characters here: https://www.youtube.com/watch?v=q-FPR1I2B74 & https://www.youtube.com/watch?v=BEIaakl9vJE
Extracted the character skin by following this tutorial: https://www.youtube.com/watch?v=P4PrO8fHZ4E 
I combined what voice and animation control together by replacing keyboard input for voice input.

  
## 2. MRBasics - Unity2019.2.8f1 (HoloToolkit)
This is basically tutorial MR Basics 101. https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101
We did basic animation, voice command, sound, gaze. 

### Failures
I could not get spatial mapping to work on Unity2019.2.8f1. Seems like two scripts were missing for the spatialmapping function. I tried the Unity XR components "Spatial Mapping Collider (Script)" and "Spatial Mapping Renderer (Script)" instead. I was able to view the mesh using the SMR, but couldnt actually get the collider to work. Thus, I failed to do the TapToPlace section. Everything else worked fine. Will dedicate an entire project for learning spatial mapping and reasoning later since this is important.


## 1. MRBasics100 - Unity2019.2.8f1 (HoloToolkit)
This is the first tutorial I followed to develop on the Hololens 1. https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-100
Basically, I setup my Unity (Windows10) to remote into the Hololens1, so every time I hit the play button, I can see the result on the hololens. This is definitely a MUST tutorial if you are starting to prototype using a hololens device. You will literally use what you learned here in every hololens project.

### Most important take away (everything in the tutorial already, just reminding myself):
- Have "Holographic Remoting Player" installed in your hololens device. Open it up to find your hololens IP address.
- Configure your camera to have a solid black background.
- Switch Platform to Universal Windows Platform
- For deploying to Hololens using Wi-Fi:
  - Project Settings/Player/UniversalWindowsPlatform -> XR Settings -> check Virtual Reality SDKs -> add (+) Windows Mixed Reality.
  - Go to Window/XR/Holographic Emulation/Emulation Mode -> Remote to Device
    - Device Version: Hololens 1
    - Remote Machine: <Hololens IP Address>
    - Click Connect (make sure you have the "Holographic Remoting Player" open on your hololens.
- To build project and deploy in the device (install the unity program in your device) need to use Visual Studio (I am using VS 2019).
  - Make sure you paired your computer to your hololens under the Developer Mode settings of the Hololens. If first time, it will help you pair it with a PIN. https://docs.microsoft.com/en-us/windows/mixed-reality/using-visual-studio
  - After building the App from Unity, open up the .sln file with visual studio.
  - Set "Release", "x86", "Remote Machine".
  - To set the hololens IP address, go to Debug, <Project name> Properties
  - Configuration Properties/Debugging/MachineName/Locate…
  - Find hololens IP address and put in under Address
  - Authentication Mode: Universal

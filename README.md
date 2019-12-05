# LearnUnity
I am documenting everything I learn about Unity in this repository. I have started from scratch again. Hopefully this could be a rough guide for someone else who wants to pick it up today. This is not meant to be a step by step guide. 
TODO: HoloLens Spatial Mapping + NavMesh at Runtime. Found this blog post in Japanese. Not the best, but will take a closer look later. https://tarukosu.hatenablog.com/entry/2017/04/23/183546 

## 4. NavMesh101 - Unity2019.3.0f1
This project is about learning how to use Unity NavMesh Components. I literally just followed Brackeys video tutorials and downloaded his assets. I created a new 3D project using Unity2019.3.0f1 and dragged the entire NavMesh-Tutorial downloaded from github at: https://github.com/Brackeys/NavMesh-Tutorial
Thanks to this tutorial, I discovered that Unity has a ThirdPersonCharacter scripts that does the animation for navigation automatically, but this is only for a humanoid avatar. For my thesis, I will have to figure out how to modify everything for a non-humanoid agent. These set of video tutorials are really great, now I just need to figure out how to use Hololens Spatial Mapping and combine it with Unity NavMeshComponents https://github.com/Unity-Technologies/NavMeshComponents. FYI, the NavMesh-Tutorial folder already has the Unity NavMeshComponents imported.
Alright, if you want to dive deeper on NavMesh, check this six-part tutorial by Unity https://www.youtube.com/playlist?list=PLX2vGYjWbI0Rf0im34I2lBF4eufM-cgzQ (quite long and more advanced, you will definitely understand it if you did the previous tutorial by Brackeys.) Everything related to the navMeshAgent (agent navigation) is in the UnityEngine.AI namespace. Tutorial #3 talks about a drone, which is technically non-humanoid. They did not animate it though. Also, the scene is so dark, you can barely see the drone moving.

I wonder much large of a navMesh can the hololens handle...

## 3. VoiceRecognition100 - Unity2019.2.8f1
This project allows you to control the 3D character by using voice input. You can command it to "dance", "stop", move the character "upward", "back", "forward", and "down".

Download 3D characters and animations from https://www.mixamo.com/ You need an Adobe account to do so.
Followed this voice recognition tutorial on youtube. https://www.youtube.com/watch?v=29vyEOgsW8s&t=319s
Added a 3D character and animation to the project. Learned about animation control for characters here: https://www.youtube.com/watch?v=q-FPR1I2B74 & https://www.youtube.com/watch?v=BEIaakl9vJE
Extracted the character skin by following this tutorial: https://www.youtube.com/watch?v=P4PrO8fHZ4E 
I combined what voice and animation control together by replacing keyboard input for voice input.

  
## 2. MRBasics - Unity2019.2.8f1
This is basically tutorial MR Basics 101. https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101
We did basic animation, voice command, sound, gaze. 

### Failures
I could not get spatial mapping to work on Unity2019.2.8f1. Seems like two scripts were missing for the spatialmapping function. I tried the Unity XR components "Spatial Mapping Collider (Script)" and "Spatial Mapping Renderer (Script)" instead. I was able to view the mesh using the SMR, but couldnt actually get the collider to work. Thus, I failed to do the TapToPlace section. Everything else worked fine. Will dedicate an entire project for learning spatial mapping and reasoning later since this is important.


## 1. MRBasics100 - Unity2019.2.8f1
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

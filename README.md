# LearnUnity
I am documenting everything I learn about Unity in this repository. I have started from scratch again. Hopefully this could be a rough guide for someone else who wants to pick it up today. This is not meant to be a step by step guide. 


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

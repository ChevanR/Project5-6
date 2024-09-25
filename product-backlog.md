# Product Backlog

### Network Architecture Simulation


<div class="table">

| Part             | Description                                                                                          | Tasks                                                                                                                |
| ---------------- | ---------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------- |
| Setup idea       | Define the concept and framework for network architecture simulation                                 | - Research <br> - Document findings                                                                                  |
| Implement idea   | Develop the network simulation focusing on cloud-based architecture and network degradation effects  | - Learn Unity for implementation <br> - Experiment with a laptop as a server <br> - Integrate cloud-based simulation |
| Network test     | Test the network architecture under different conditions of latency and bandwidth limitations        | - Simulate network degradations <br> - Run performance tests <br> - Analyze system performance (latency, bandwidth)  |
| **MVP Creation** | Build a minimal viable product (MVP) showcasing basic functionality of cloud-based architecture      | - Implement basic cloud-based network with haptic feedback <br> - Ensure minimal functionality for presentation      |
| Demo of idea     | Present a working demo showcasing the MVP, including network effects and haptic feedback integration | - Prepare and present demo to stakeholders                                                                           |


### Haptic Interface Implementation in XR Environment

| Part            | Description                                                                    | Tasks                                                                                                          |
| --------------- | ------------------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------- |
| Setup           | Define and configure the haptic devices for XR environment                     | - Research suitable haptic devices (e.g., Sense Glove, Ultraleap) <br> - Setup Unity with XR support           |
| User experience | Investigate the user experience with haptic feedback in the XR environment     | - Test haptic feedback on different XR elements (e.g., terrain elevation) depending on the haptic device       |
| Network test    | Test how network degradation affects the haptic feedback in the XR environment | - Simulate network delays and bandwidth limitations <br> - Measure impact on user experience (visual & haptic) |

### Final MVP
| Part             | Description                                                                                                                                     | Tasks                                                                                                           |
| ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| **MVP Creation** | Build a minimal viable product (MVP) for the haptic interface in the XR environment, where the user can **see** and **touch** the terrain model | - Integrate haptic feedback with cloud-based architecture <br> - Ensure minimal functionality for demo purposes |
| Demo of idea     | Present a demo showcasing the MVP, including haptic feedback and the terrain model                                                              | - Prepare demo <br> - Present findings to stakeholders                                                          |

```mermaid
---
title: Flow of the Project
---


flowchart LR
%% styling
classDef note stroke:#0f0


    subgraph Cloud Project[cloud]
        cloudResearch(Research cloud computing, Unity, docker<img src="./images/research.png"/>)
        noteOne[[NVIDIA cloudXR, ALVR, Moonlight]]
        
        makeUnity(Make a Unity project with multiplayer features 
        <img src='../images/unity.png'/>
        <img src="../images/vr.png"/>
        Make a Unity projects with VR features) 

        Implement(Run the Unity project in a cloud-like environment<img src="../images/server.png"/>)
        noteTwo[[Basically, meaning able to introduce artificial network degredation]]
        networkTest(Research network degradation on the cloud for user experience<img src="../images/networktest.png"/>)
        demoShow(Show the demo of MVP for the 15 Nov Deadline)
        feedbackImplement(Implement any feedback given at demo time, and improve the cloud project if needed)

        cloudResearch --> makeUnity
        cloudResearch --o noteOne
        Implement --o noteTwo
        makeUnity-- Rapid implementation ---> Implement
        Implement-- Fix issues and iterate ---> makeUnity
        Implement --> networkTest --> demoShow --> feedbackImplement

        noteOne:::note
        noteTwo:::note

        
    end

    subgraph Haptic Device Integration
        setupXR(Setup and research for using the Haptic device in Unity)
        userXP(Describe the user experience with the Haptic device)
        networkTest2(Gather user experience with regards to artificial network degredation)
        MVP(Make an MVP for Haptic device implementation)

        setupXR -->  userXP
        userXP-- Implement Haptic feedback into terrain model --> MVP --> networkTest2
    end

    networkTest-- Use the network testing on the Haptic device-->networkTest2

deliverable(Deliver the deliverables, all the test data, research and MVP's)

networkTest2 --> deliverable
```
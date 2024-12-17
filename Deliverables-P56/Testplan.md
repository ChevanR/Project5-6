# Test Plan: VR and Haptic Integration in an Extended Reality Environment  

---

## Introduction  
The purpose of this document is to provide the **Test Plan** for the **VR and Haptic Cloud Integration** project. The **Test Plan** outlines the testing strategy and procedures to validate requirements, while the [Test Report](Testreport.md) documents the results and observations of each test. Together, they ensure critical functionalities are implemented correctly and meet the defined acceptance criteria.  

This document is structured as follows:  
- **Requirements**: Describes the requirements from the product backlog.
- **Test Plan**: Contains all the tests that need to be conducted for these requirements.  

---

## Requirements (Product Backlog)  

The following table summarizes the project requirements, prioritized using the **MoSCoW** method:  

| **ID** | **Requirement**                              | **Priority** |
| ------ | -------------------------------------------- | ------------ |
| 1      | VR Application Development                   | Must         |
| 2      | Use an actual VR headset for the application | Must         |
| 3      | Remote Rendering Implementation              | Must         |
| 4      | Network Degradation Simulation               | Must         |
| 5      | Performance Data Logging                     | Must         |
| 6      | Data Analysis                                | Must         |
| 7      | Users get haptic feedback                    | Must         |
| 8      | Haptic & VR user experience                  | Must         |
| 9      | MVP Creation for Stakeholders                | Should       |
| 10     | Multiplayer Feature Implementation           | Should       |
| 11     | Test with Diverse User Groups                | Should       |
| 12     | Haptic controls map movement                 | Should       |
| 13     | Switch between 1st and 3rd person            | Should       |
| 14     | Gesture-based camera switching               | Should       |
| 15     | Iterate Based on Feedback                    | Could        |
| 16     | Allow the usage for different VR headsets    | Could        |
| 17     | Usage of a dedicated server                  | Could        |
| 18     | Users can connect from all over the world    | Could        |
| 19     | Clients identification                       | Could        |
| 20     | Client communication via microphone          | Could        |

---

## Test Plan  

### Test 1: VR Application and Remote Rendering Verification  
**Purpose**  
Validate that the VR application renders correctly on a remote server, and the VR headset updates in real time.  

**Requirements Verified**  
- **1**: VR Application Development  
- **2**: Use an actual VR headset for the application  
- **3**: Remote Rendering Implementation  

**Steps**  
1. Launch the Unity VR test environment.  
2. Connect the Oculus Quest 3 headset using ALVR.  
3. Initiate a remote-rendering session.  
4. Move the VR headset and confirm corresponding camera movements in Unity.  
5. Disconnect the headset and ensure the application continues rendering at a stable frame rate (e.g., 60 FPS).  

---

### Test 2: Network Degradation and Performance Data Logging  
**Purpose**  
Evaluate VR performance under simulated latency and verify that performance metrics are logged accurately.  

**Requirements Verified**  
- **4**: Network Degradation Simulation  
- **5**: Performance Data Logging  
- **6**: Data Analysis  

**Steps**  
1. Connect the Oculus Quest 3 headset to the Unity test environment.  
2. Use **Clumsy** to simulate network latency at 50ms, 100ms, 150ms, and 200ms.  
3. Perform basic VR movements and observe frame rate and input lag.  
4. Log performance metrics (frame rates, input delay) to a JSON file.  
5. Analyze and graph the results to identify trends between latency and VR performance.  

---

### Test 3: Multiplayer and Client Identification  
**Purpose**  
Validate multiplayer connectivity and client identification features.  

**Requirements Verified**  
- **10**: Multiplayer Feature Implementation  
- **19**: Clients Identification  

**Steps**  
1. Launch the multiplayer Unity environment.  
2. Connect two Oculus Quest 3 headsets to the session.  
3. Verify that both users can see and interact with each other.  
4. Implement and test color tags and name labels to distinguish clients.  

---

### Test 4: Haptic Feedback and Gesture-Based Map Controls  
**Purpose**  
Verify the integration of haptic feedback and gesture-based map controls.  

**Requirements Verified**  
- **7**: Users get haptic feedback  
- **12**: Haptic controls map movement  

**Steps**  
1. Connect the **Ultraleap Haptic Device** to Unity.  
2. Simulate various terrain heights and observe tactile feedback.  
3. Implement gesture controls for moving the virtual map.  
4. Test haptic responses and gesture precision for map movement.  

---
# Test Plan and Test Report: VR and Haptic Integration in an Extended Reality Environment  

---

## Introduction  
The purpose of this document is to provide both the **Test Plan** and **Test Report** for the **VR and Haptic Cloud Integration** project. The **Test Plan** outlines the testing strategy and procedures to validate requirements, while the **Test Report** documents the results and observations of each test. Together, they ensure critical functionalities are implemented correctly and meet the defined acceptance criteria.  

This document is structured as follows:  
- **Test Plan**: Describes the tests to be conducted.  
- **Test Report**: Provides the results and analysis of each test.  

---

# Test Plan  

## Requirements (Product Backlog)  

The following table summarizes the project requirements, prioritized using the **MoSCoW** method:  

| **ID** | **Requirement**                                      | **Priority** |  
| ------ | ---------------------------------------------------- | ------------ |  
| 1      | VR Application Development                          | Must         |  
| 2      | Use an actual VR headset for the application         | Must         |  
| 3      | Remote Rendering Implementation                     | Must         |  
| 4      | Network Degradation Simulation                      | Must         |  
| 5      | Performance Data Logging                            | Must         |  
| 6      | Data Analysis                                       | Must         |  
| 7      | Users get haptic feedback                           | Must         |  
| 8      | Haptic & VR user experience                         | Must         |  
| 9      | MVP Creation for Stakeholders                       | Should       |  
| 10     | Multiplayer Feature Implementation                  | Should       |  
| 11     | Test with Diverse User Groups                       | Should       |  
| 12     | Haptic controls map movement                        | Should       |  
| 13     | Switch between 1st and 3rd person                   | Should       |  
| 14     | Gesture-based camera switching                      | Should       |  
| 15     | Iterate Based on Feedback                           | Could        |  
| 16     | Allow the usage for different VR headsets           | Could        |  
| 17     | Usage of a dedicated server                         | Could        |  
| 18     | Users can connect from all over the world           | Could        |  
| 19     | Clients identification                              | Could        |  
| 20     | Client communication via microphone                 | Could        |  

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

## Test Report  

### Test 1: VR Application and Remote Rendering Verification  
**Results**  
✅ The VR application rendered correctly, camera movements synced, and rendering continued seamlessly after headset disconnection.  

---

### Test 2: Network Degradation and Performance Data Logging  
**Results**  
✅ Network degradation caused expected performance drops, and JSON logs captured latency, frame rates, and input delays. Graphs highlighted the correlation.  

---

### Test 3: Multiplayer and Client Identification  
**Results**  
✅ Multiplayer functionality worked seamlessly, and identification features (Colors) displayed correctly.  

---

### Test 4: Haptic Feedback and Gesture-Based Map Controls  
**Results**  
✅ Haptic feedback worked as intended, with varied tactile responses based on terrain. Gesture controls effectively manipulated the map.  

---

### Test 5: Switching Between 1st and 3rd Person (With Gestures)  
**Results**  
✅ Switching between first-person and third-person views worked accurately, and gesture-based commands performed reliably with minimal latency.  

---

### Test 6: VR and Haptic User Experience Under Latency  
**Results**  
✅ Combined latency significantly affected user experience beyond 100ms. Feedback confirmed reduced usability at 200ms latency.  

---

## Summary and Conclusion  

### Summary  
The **Test Plan** verified all **Must Have** requirements and addressed several **Should/Could** items. Each test was systematically executed, capturing performance data and user feedback for analysis.  

### Conclusion  
- **Must Have Requirements**: ✅ Fully validated.  
- **Should/Could Requirements**: 🟡 Partially completed, pending refinements.  
- **Haptic and VR Experience**: Combined tests demonstrated expected latency limitations, confirming thresholds for usability.  

The project is on schedule, with critical features validated and user feedback incorporated. Future efforts will focus on refining haptic integration and optimizing network performance.

---

# Test Plan: VR and Haptic Integration in an Extended Reality Environment  

---

## Introduction  
The purpose of this test plan is to systematically validate the requirements outlined in the product backlog for the **VR and Haptic Cloud Integration** project. Each test ensures that critical functionalities—including VR application development, remote rendering, network degradation simulation, and haptic feedback—are implemented correctly and meet the defined acceptance criteria.  

This document provides a structured approach to testing, with requirements categorized by priority and marked **done** upon successful verification.  

---

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
| 7      | MVP Creation for Stakeholders                       | Should       |  
| 8      | Iterate Based on Feedback                           | Could        |  
| 9      | Multiplayer Feature Implementation                  | Should       |  
| 10     | Test with Diverse User Groups                       | Should       |  
| 11     | Allow the usage for different VR headsets           | Could        |  
| 12     | Usage of a dedicated server                         | Could        |  
| 13     | Users can connect from all over the world           | Could        |  
| 14     | Users get haptic feedback                           | Must         |  
| 15     | Clients identification                              | Could        |  
| 16     | Haptic controls map movement                        | Should       |  
| 17     | Client needs to go between 1st and 3rd person       | Should       |  
| 18     | 1st and 3rd person needs to be done with gestures   | Should       |  
| 19     | Client communication via microphone                 | Could        |  
| 20     | Haptic & VR user experience                         | Must         |  

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

**Results**  
✅ The VR application rendered correctly, camera movements synced, and rendering continued seamlessly after headset disconnection.  

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

**Results**  
✅ Network degradation caused expected performance drops, and JSON logs captured latency, frame rates, and input delays. Graphs highlighted the correlation.  

---

### Test 3: Multiplayer and Client Identification  
**Purpose**  
Validate multiplayer connectivity and client identification features.  

**Requirements Verified**  
- **9**: Multiplayer Feature Implementation  
- **15**: Clients Identification  

**Steps**  
1. Launch the multiplayer Unity environment.  
2. Connect two Oculus Quest 3 headsets to the session.  
3. Verify that both users can see and interact with each other.  
4. Implement and test color tags and name labels to distinguish clients.  

**Results**  
✅ Multiplayer functionality worked seamlessly, and identification features (name tags and colors) displayed correctly.  

---

### Test 4: Haptic Feedback and Gesture-Based Map Controls  
**Purpose**  
Verify the integration of haptic feedback and gesture-based map controls.  

**Requirements Verified**  
- **14**: Users get haptic feedback  
- **16**: Haptic controls map movement  

**Steps**  
1. Connect the **Ultraleap Haptic Device** to Unity.  
2. Simulate various terrain heights and observe tactile feedback.  
3. Implement gesture controls for moving the virtual map.  
4. Test haptic responses and gesture precision for map movement.  

**Results**  
✅ Haptic feedback worked as intended, with varied tactile responses based on terrain. Gesture controls effectively manipulated the map.  

---

### Test 5: Switching Between 1st and 3rd Person (With Gestures)  
**Purpose**  
Validate manual and gesture-based switching between first-person and third-person perspectives.  

**Requirements Verified**  
- **17**: Client needs to go between 1st and 3rd person  
- **18**: 1st and 3rd person needs to be done with gestures  

**Steps**  
1. Implement manual switching between first-person and third-person camera views.  
2. Configure gestures using the Ultraleap Haptic Device to trigger the camera switch.  
3. Test both manual and gesture-based switches for responsiveness and accuracy.  

**Results**  
✅ Switching between first-person and third-person views worked accurately, and gesture-based commands performed reliably with minimal latency.  

---

### Test 6: VR and Haptic User Experience Under Latency  
**Purpose**  
Assess the combined impact of latency on user experience with VR visuals and haptic feedback.  

**Requirements Verified**  
- **20**: Haptic & VR user experience  

**Steps**  
1. Connect the VR headset and Ultraleap Haptic Device.  
2. Introduce simulated latency increments of 50ms, 100ms, and 200ms using **Clumsy**.  
3. Have **3–5 participants** interact with the VR environment and haptic feedback simultaneously.  
4. Collect user feedback on usability, motion sickness, and task performance.  

**Results**  
✅ Combined latency significantly affected user experience beyond 100ms. Feedback confirmed reduced usability at 200ms latency.  

---

## Summary and Conclusion  

### Summary  
The test plan verified all **Must Have** requirements and addressed several **Should/Could** items. Each test was systematically executed, capturing performance data and user feedback for analysis.  

### Conclusion  
- **Must Have Requirements**: ✅ Fully validated.  
- **Should/Could Requirements**: 🟡 Partially completed, pending refinements.  
- **Haptic and VR Experience**: Combined tests demonstrated expected latency limitations, confirming thresholds for usability.  

The project is on schedule, with critical features validated and user feedback incorporated. Future efforts will focus on refining haptic integration and optimizing network performance.

---

# Test Plan: VR and Haptic Integration in an Extended Reality Environment  

## Introduction  
The purpose of this test plan is to systematically verify the requirements outlined in the product backlog for the VR and Haptic Cloud Integration project. Each test ensures that critical functionalities, such as VR application development, remote rendering, network degradation simulation, and haptic feedback, are implemented correctly and meet the acceptance criteria.  

This document presents an organized approach to testing, covering essential features and marking requirements as **done** upon validation.  

---

## Requirements (Product Backlog)  

The requirements are based on the **MoSCoW** prioritization method (Must, Should, Could, Want). The following table summarizes the project requirements:  

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
#### Purpose  
To verify that the VR application renders correctly on a remote server and the VR headset updates in real time.  

#### Requirements Verified  
- **1**: VR Application Development  
- **2**: Use an actual VR headset for the application  
- **3**: Remote Rendering Implementation  

#### Steps  
1. Open the Unity VR test environment.  
2. Connect the Oculus Quest 3 headset using ALVR.  
3. Start the remote-rendering session.  
4. Move the VR headset and confirm the camera movements in Unity.  
5. Disconnect the VR headset and ensure the VR application continues rendering on the server at a stable frame rate (e.g., 60 FPS).  

#### Results  
✅ The VR application rendered correctly, and camera movements were synced with the headset. Rendering continued seamlessly when the VR headset disconnected.  

---

### Test 2: Network Degradation and Performance Data Logging  
#### Purpose  
To test VR performance under simulated network latency and verify performance logging.  

#### Requirements Verified  
- **4**: Network Degradation Simulation  
- **5**: Performance Data Logging  
- **6**: Data Analysis  

#### Steps  
1. Start the Unity test environment and connect the VR headset.  
2. Use **Clumsy** to simulate latency increments: 50ms, 100ms, 150ms, and 200ms.  
3. Move the headset and observe delays in frame updates.  
4. Log latency, frame rates, and input delays in a JSON file.  
5. Analyze the logs and generate graphs to identify trends.  

#### Results  
✅ Network latency successfully degraded performance, and JSON logs captured frame rate, latency, and input lag data. Graphs demonstrated the correlation between latency and performance.  

---

### Test 3: Multiplayer and Client Identification  
#### Purpose  
To validate multiplayer functionality and user identification features.  

#### Requirements Verified  
- **9**: Multiplayer Feature Implementation  
- **15**: Clients Identification  

#### Steps  
1. Launch the multiplayer Unity environment with two Oculus Quest headsets.  
2. Connect both VR headsets to the session.  
3. Verify that both users see each other and interact in the environment.  
4. Implement color tags and name labels to identify clients.  

#### Results  
✅ Two clients connected successfully, and identification features (name tags/colors) displayed correctly.  

---

### Test 4: Haptic Feedback and Haptic Map Controls  
#### Purpose  
To confirm the integration of haptic feedback and gesture-based map control.  

#### Requirements Verified  
- **14**: Users get haptic feedback  
- **16**: Haptic controls map movement  

#### Steps  
1. Connect the **Ultraleap Haptic Device** to the Unity test environment.  
2. Simulate terrain with varying heights and observe tactile feedback.  
3. Use haptic gestures to move the map around the environment.  

#### Results  
✅ Haptic feedback worked as intended, and tactile sensations varied with terrain height. Gestures successfully controlled the map’s movement.  

---

### Test 5: Switching Between 1st and 3rd Person (Gestures Included)  
#### Purpose  
To verify switching between first and third-person perspectives using gestures.  

#### Requirements Verified  
- **17**: Client needs to go between 1st and 3rd person  
- **18**: 1st and 3rd person needs to be done with gestures  

#### Steps  
1. Implement both first-person and third-person camera views in Unity.  
2. Assign a **gesture command** using the Ultraleap haptic device to trigger the camera switch.  
3. Test the switch manually and through gestures.  

#### Results  
✅ Switching between first and third-person views functioned as expected. Gestures successfully triggered the view switch with minimal observable latency.  

---

### Test 6: VR and Haptic User Experience Under Latency  
#### Purpose  
To assess the combined impact of latency on user experience with both VR visuals and haptic feedback.  

#### Requirements Verified  
- **20**: Haptic & VR user experience  

#### Steps  
1. Connect the VR headset and Ultraleap Haptic Device.  
2. Use Clumsy to simulate network latency increments of 50ms, 100ms, and 200ms.  
3. Have **at least 3 participants** interact with both VR visuals and haptic devices under simulated latency conditions.  
4. Collect user feedback using questionnaires evaluating usability, task performance, and comfort.  

#### Results  
✅ Combined latency noticeably impacted user experience at 200ms. Users reported usability degradation beyond 100ms. Graphs confirmed the findings.

---

## Summary and Conclusion  

### Summary  
The test plan systematically verified all **Must Have** requirements and several **Should/Could** requirements. Each test addressed multiple product backlog items, ensuring efficient testing coverage. Results were collected, and any issues were resolved or noted for future iterations.  

### Conclusion  
- **Must Have Requirements**: ✅ Completed and verified through extensive testing.  
- **Should/Could Requirements**: 🟡 Partially completed; pending minor refinements.  
- **Haptic Feedback and Network Testing**: Successfully demonstrated responsiveness and limitations under varying conditions.  

The project is on track, with critical functionalities fully tested and validated for stakeholder review. Future work will focus on refining haptic features and optimizing network performance to improve overall user experience.  

---

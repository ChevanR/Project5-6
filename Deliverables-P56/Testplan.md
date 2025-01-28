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
| 2      | Use an actual VR headset for the application | Must         |
| 3      | Remote Rendering Implementation              | Must         |
| 4      | Network Degradation Simulation               | Must         |
| 5      | Performance Data Logging                     | Must         |
| 6      | Data Analysis                                | Must         |
| 7      | Users get haptic feedback                    | Must         |
| 16     | Allow the usage for different VR headsets    | Could        |
| 18     | Users can connect from all over the world    | Could        |

---

## Setup guides
Follow install and usage guides from [user guides](/Deliverables-P56/Usage-guide.md)

### global setup
1. Open the Unity project in Unity from this project.  
2. Follow the ALVR usage guide.
3. Optional steps:  
   1. Clumsy
      1. Follow the usage guide for Clumsy from the user guides
   2. Logging
      1. Follow the Logging script usage guide from the user guides
   3. Analysis
      1. Follow the Graphing script usage guide from the user guides
   4. VPN
      1. Connect both headset and laptop to the same VPN (guide not included)
      2. Use the VPN ip of the client in the ALVR discovery
   5. Unity latency
      1. Follow the Unity Haptic delay usage guide from the user guides
4. Press start in Unity

## Test Plan  

### Test 1
Requirements: 2,16  
Follow 1,2,4 from the global setup. 
To test different headsets, you can use different headsets.  

#### Results

### Test 2
Requirements: 3  
Follow 1,2,4 from the global setup. 
Now turn off ALVR on the VR headset, and you should see that the game runs on the laptop and thus remote.  

#### Results

### Test 3
Requirements: 4  
Follow 1,2,3.1,3.5,4
Test with multiple different delays and you can see how to impact the feeling.

#### Results

### Test 4
Requirements: 5,6,7  
Follow 1,2,3.2,4  
After having created the logging file follow 3.3

#### Results

### Test 5
Requirements: 18  
Follow 1,3.4,2,4  

#### Results

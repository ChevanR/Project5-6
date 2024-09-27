# Product Backlog

### Network Architecture Simulation


<div class="table">

## Research-Oriented Product Backlog: Cloud VR Project

| **Requirement**                                  | **Description**                                                                                             | **Tasks**                                                                                                                   | **MoSCoW**    |
| ------------------------------------------------ | ----------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- | ------------- |
| **Local Server Setup**                           | Configure a laptop to function as a local server for remote rendering                                       | - Install necessary software for server (e.g., Unity, networking tools) <br> - Set up local server environment              | Must          |
| **VR Application Development**                   | Create or modify a VR application to support remote rendering and multiplayer features                      | - Develop Unity project with multiplayer capabilities <br> - Implement network synchronization for users                    | Must          |
| **Use an actual VR headset for the application** | Make sure that we use an actual VR headset for the application, for now we will be focussing on the quest 3 | - Aquire a quest 3 to work with                                                                                             | must          |
| **Remote Rendering Implementation**              | Ensure that rendering is handled on the server while users connect remotely                                 | - Set up server-side rendering using Unity <br> - Test remote streaming to VR headsets                                      | Must          |
| **Network Degradation Simulation**               | Implement a tool to simulate various network conditions on the local server                                 | - Create scripts to simulate latency, packet loss, and bandwidth changes <br> - Test tool effectiveness                     | Must          |
| **Performance Data Logging**                     | Collect and log performance metrics during VR sessions (latency, frame rate, user feedback)                 | - Implement some kind of data logging <br> - Store logs locally for analysis                                                | Must          |
| **Data Analysis**                                | Analyze collected data to understand the effects of network degradation on user experience                  | - Process and visualize performance data <br> - Summarize findings related to user feedback                                 | Must          |
| **MVP Creation for Stakeholders**                | Build a minimal viable product (MVP) showcasing remote rendering and network functionality                  | - Implement core features needed for MVP <br> - Ensure stability and performance for demonstration                          | Must (should) |
| **Iterate Based on Feedback**                    | Implement improvements based on user feedback from demo and testing sessions                                | - Refine VR app and network simulation features <br> - Re-test with improved functionalities                                | Could         |
| **Multiplayer Feature Implementation**           | Implement a multiplayer feature, such that it can be tested for synchronisation issues                      | - Develop and integrate multiplayer features in the VR application <br> - Validate synchronization of actions               | Should        |
| **Test with Diverse User Groups**                | Conduct tests with various participants (family, friends, students, teachers)                               | - Prepare recruitment strategies for testers <br> - Provide clear instructions for testing sessions                         | Should        |
| **Allow the usage for different vr headsets**    | Except for only a quest 3, make sure we can use other VR headsets aswell                                    | - Aquire different VR headsets <br> - Do research about the differences between the different VR headsets, based on the API | Could         |
| **Usage of a dedicated server**                  | Use a dedicated server instead of rendering on a laptop                                                     | - Do research about the different options we have (AWS, ...)                                                                | Won't         |

![](./src/flowchart.png)
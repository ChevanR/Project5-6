# TESTPLAN

## Necessities

### VR
1. Laptop/Computer
2. ALVR
3. VR compatible device
4. STEAMVR
5. A test world (unity)

### Network
1. Clumsy
2. Unity script

### Haptic
1. Haptic device
2. Compatible unity world

### Logging & Experience
[VR](#VR), [Haptic](#Haptic) and [Network](#Network)
1. Python scripts
2. Questionaire

## Requirements 
1. **VR Application Development**              
    - The remote rendering from the game is visually available on the VR headset and interaction from the controllers and movement give feedback to the server so it can render a different scene
2. **Use an actual VR headset for the application** 
    - If we move the vr headset, the camera in 'game' should also correspond to the same movement
3. **Remote Rendering Implementation**              
    - The 'game' is rendered on the laptop, as the 'game' does not stop when the VR headset is disconnected
4. **Network Degradation Simulation**               
    - The tool used does actually increase the latency, this can be seen when moving around with the VR headset and gettings the frames later, because of the altency
5. **Performance Data Logging**                     
    - The performance data is logged into a JSON file
6. **Data Analysis**                                
    - Graphs are made from the collected user data and performance data, to show corrolations between these to, acceptence is given by product owner
7. **MVP Creation for Stakeholders**                
    - Have a MVP containing atleast a simulated network environment containig both remote VR rendering and haptic feedback
8. **Iterate Based on Feedback**                    
    - ...
9. **Multiplayer Feature Implementation**           
    - Two clients using two VR headsets can connect to the same environment and see each othe
10. **Test with Diverse User Groups**                
    - Test with different age categories, VR usage rates, ...
11. **Allow the usage for different vr headsets**    
    - Atleast 2 different VR headsets from different brands can be used for the same application
12. **Usage of a dedicated server**                  
    - Instead of a laptop an actual server in de cloud or as hardware is used for the server side rendering
13. **Users can connect from all over the world**    
    - A user can from country A connect to the server in Country B, this can be tested by using a VPN connection between the server and client
14. **Users get haptic feedback**                    
    - The user can feel the difference between the height of different buildings or terrain
15. **Clients identification**
    - A client can be identified based on name tag or color
16. **Haptic controls map movement**
    - The map moves around based on the input of the user
17. **Client needs to go between 1st and 3rd person**
    - The user can switch their camera between 1st and 3rd person
18. **1st and 3rd person needs to be done with gestures (haptic)**
    - The switching between 1st and 3rd person, can now be done using gestures
19. **Client communication via microphone**
    - Clients can communicate with one another using their microphones
20. **Haptic & VR user experience**
    - Acceptence is given by the product owner, but should include all three combinations of latency with VR & Haptic


## Testing

Template:
#### Test purpose
#### Necessities
#### Steps
#### Results

### Use an actual VR headset for the application
#### Test purpose
To test if the VR device is the device controlling the camera and not something else
#### Necessities
[VR](#VR)
#### Steps
1. Press play in Unity ![](unity-play.png)
2. Observe if moving the VR device changes the camera in game
#### Results

### VR Application Development
#### Test purpose
To test if the VR device functions as it should for the remote rendered simulation

#### Necessities
[VR](#VR)

#### Steps
1. Press play in Unity ![](unity-play.png)
2. Observe if moving the VR device changes the camera in game and we get the rendered scene on the VR headset

#### Results
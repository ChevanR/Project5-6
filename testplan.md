# TESTPLAN

## Setup
You need to have access to the Github/Gitlab

### VR
LAPTOP
ALVR
VR
STEAMVR
UNITY (WORLD)

### Network
CLUMSY

### Haptic
PLUGINS
HAPTIC DEVICE

### Logging & Experience
Scripts
Questionaire
Graphing script

## Requirements 
- **VR Application Development**              
    - The remote rendering from the game is visually available on the VR headset and interaction from the controllers and movement give feedback to the server so it can render a different scene
- **Use an actual VR headset for the application** 
    - If we move the vr headset, the camera in 'game' should also correspond to the same movement
- **Remote Rendering Implementation**              
    - The 'game' is rendered on the laptop, as the 'game' does not stop when the VR headset is disconnected
- **Network Degradation Simulation**               
    - The tool used does actually increase the latency, this can be seen when moving around with the VR headset and gettings the frames later, because of the altency
- **Performance Data Logging**                     
    - The performance data is logged into a JSON file
- **Data Analysis**                                
    - Graphs are made from the collected user data and performance data, to show corrolations between these to, acceptence is given by product owner
- **MVP Creation for Stakeholders**                
    - ...
- **Iterate Based on Feedback**                    
    - ...
- **Multiplayer Feature Implementation**           
    - Two clients using two VR headsets can connect to the same environment and see each othe
- **Test with Diverse User Groups**                
    - Test with different age categories, VR usage rates, ...
- **Allow the usage for different vr headsets**    
    - Atleast 2 different VR headsets from different brands can be used for the same application
- **Usage of a dedicated server**                  
    - Instead of a laptop an actual server in de cloud or as hardware is used for the server side rendering
- **Users can connect from all over the world**    
    - A user can from country A connect to the server in Country B, this can be tested by using a VPN connection between the server and client
- **Users get haptic feedback**                    
    - The user can feel the difference between the height of different buildings or terrain